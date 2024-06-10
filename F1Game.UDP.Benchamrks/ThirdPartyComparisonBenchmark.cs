using System.Buffers.Binary;

using BenchmarkDotNet.Attributes;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Packets;

using Packet = F1_22_UDP_Telemetry_Receiver.Packets.Packet;

namespace F1Game.UDP.Benchmarks;

[MemoryDiagnoser(true)]
public class ThirdPartyComparisonBenchmark
{
	[Params([
		PacketType.CarDamage,
		PacketType.CarSetups,
		PacketType.CarStatus,
		PacketType.CarTelemetry,
		PacketType.FinalClassification,
		PacketType.LapData,
		PacketType.LobbyInfo,
		PacketType.Motion,
		PacketType.MotionEx,
		PacketType.Participants,
		PacketType.Session,
		PacketType.SessionHistory,
		PacketType.TyreSets,
		PacketType.Event,
		])]
	public PacketType Type { get; set; }

	byte[] data = [];

	[GlobalSetup]
	public void GlobalSetup()
	{
		var size = GetPacketSize(Type);

		data = new byte[size];
		var random = new Random(42);
		random.NextBytes(data);
		data[6] = (byte)Type;

		if (Type == PacketType.Session)
			SetupSessionPacket(data, random);
		if (Type == PacketType.Event)
			SetupEventPacket(data);
		if (Type == PacketType.CarStatus)
			SetupCarStatusPacket(data, random);
		if (Type == PacketType.CarTelemetry)
			SetupCarTelemetryPacket(data, random);
	}

	[Benchmark(Baseline = true)]
	public IPacket ReadF1GameUDP()
	{
		return data.ToPacket();
	}

	[Benchmark]
	public void ReadF1Sharp()
	{
		F1SharpHelper.ReadPacket(data);
	}

	[Benchmark]
	public Packet ReadF1Simracing()
	{
		return SimRacingHelpers.ReadPacket(data);
	}

	static void SetupCarTelemetryPacket(byte[] data, Random random)
	{
		var packet = (CarTelemetryDataPacket)data.ToPacket();
		var updatedPacket = packet with
		{
			CarTelemetryData = packet.CarTelemetryData.Select(x => x with
			{
				Gear = random.GetItems(new sbyte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)[0],
			}).ToArray(),
			SuggestedGear = random.GetItems(new sbyte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)[0]
		};

		var writer = new BytesWriter(data);
		writer.Write(updatedPacket);
	}

	static void SetupCarStatusPacket(byte[] data, Random random)
	{
		var packet = (CarStatusDataPacket)data.ToPacket();
		var updatedPacket = packet with
		{
			CarStatusData = packet.CarStatusData.Select(x => x with
			{
				VehicleFiaFlags = random.GetItems([FiaFlag.Green, FiaFlag.Yellow, FiaFlag.None, FiaFlag.Blue], 1)[0]
			}).ToArray()
		};

		var writer = new BytesWriter(data);
		writer.Write(updatedPacket);
	}

	static void SetupEventPacket(byte[] data)
	{
		BinaryPrimitives.WriteUInt32LittleEndian(data.AsSpan()[PacketHeader.Size..], (uint)EventType.SpeedTrapTriggered);
	}

	static void SetupSessionPacket(byte[] data, Random random)
	{
		var packet = (SessionDataPacket)data.ToPacket();
		var updatedPacket = packet with
		{
			AirTemperature = (sbyte)random.Next(127),
			TrackTemperature = (sbyte)random.Next(127),
			Track = (Track)random.Next(127),
			MarshalZones = packet.MarshalZones.Select(x => x with
			{
				ZoneFlag = random.GetItems([FiaFlag.Green, FiaFlag.Yellow, FiaFlag.Blue, FiaFlag.None], 1)[0]
			}).ToArray(),
			WeatherForecastSamples = packet.WeatherForecastSamples.Select(x => x with
			{
				AirTemperature = (sbyte)random.Next(127),
				TrackTemperature = (sbyte)random.Next(127),
				AirTemperatureChange = (sbyte)random.Next(127),
				TrackTemperatureChange = (sbyte)random.Next(127),
			}).ToArray()
		};

		var writer = new BytesWriter(data);
		writer.Write(updatedPacket);
	}

	static int GetPacketSize(PacketType packetType)
	{
		return packetType switch
		{
			PacketType.Motion => MotionDataPacket.Size,
			PacketType.Session => SessionDataPacket.Size,
			PacketType.LapData => LapDataPacket.Size,
			PacketType.Event => EventDataPacket.Size,
			PacketType.Participants => ParticipantsDataPacket.Size,
			PacketType.CarSetups => CarSetupDataPacket.Size,
			PacketType.CarTelemetry => CarTelemetryDataPacket.Size,
			PacketType.CarStatus => CarStatusDataPacket.Size,
			PacketType.FinalClassification => FinalClassificationDataPacket.Size,
			PacketType.LobbyInfo => LobbyInfoDataPacket.Size,
			PacketType.CarDamage => CarDamageDataPacket.Size,
			PacketType.SessionHistory => SessionHistoryDataPacket.Size,
			PacketType.TyreSets => TyreSetsDataPacket.Size,
			PacketType.MotionEx => MotionExDataPacket.Size,
			_ => throw new NotImplementedException()
		};
	}
}
