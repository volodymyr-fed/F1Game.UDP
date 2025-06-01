using System.Buffers.Binary;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Internal;
using F1Game.UDP.Packets;

namespace F1Game.UDP.Benchmarks.Helpers;

static class PacketGenerator
{
	public static byte[] GeneratePacket(PacketType packetType)
	{
		var data = new byte[GetPacketSize(packetType)];
		var random = new Random(42);
		random.NextBytes(data);
		data[PacketHeader.PacketTypeIndex] = (byte)packetType;

		return packetType switch
		{
			PacketType.Session => SetupSessionPacket(data, random),
			PacketType.Event => SetupEventPacket(data),
			PacketType.CarStatus => SetupCarStatusPacket(data, random),
			PacketType.CarTelemetry => SetupCarTelemetryPacket(data, random),
			_ => data
		};
	}

	static byte[] SetupCarTelemetryPacket(byte[] data, Random random)
	{
		if (!data.ToPacket().TryGetCarTelemetryDataPacket(out var packet))
			return data;

		var updatedPacket = packet with
		{
			CarTelemetryData = packet.CarTelemetryData.AsEnumerable().Select(x => x with
			{
				Gear = random.GetItems(new sbyte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)[0],
			}).ToArray(),
			SuggestedGear = random.GetItems(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)[0]
		};

		var writer = new BytesWriter(data);
		writer.Write(updatedPacket);

		return data;
	}

	static byte[] SetupCarStatusPacket(byte[] data, Random random)
	{
		if (!data.ToPacket().TryGetCarStatusDataPacket(out var packet))
			return data;

		var updatedPacket = packet with
		{
			CarStatusData = packet.CarStatusData.AsEnumerable().Select(x => x with
			{
				VehicleFiaFlags = random.GetItems([FiaFlag.Green, FiaFlag.Yellow, FiaFlag.None, FiaFlag.Blue], 1)[0]
			}).ToArray()
		};

		var writer = new BytesWriter(data);
		writer.Write(updatedPacket);

		return data;
	}

	static byte[] SetupEventPacket(byte[] data)
	{
		BinaryPrimitives.WriteUInt32LittleEndian(data.AsSpan()[PacketHeader.Size..], (uint)EventType.SpeedTrapTriggered);

		return data;
	}

	static byte[] SetupSessionPacket(byte[] data, Random random)
	{
		if (!data.ToPacket().TryGetSessionDataPacket(out var packet))
			return data;

		var updatedPacket = packet with
		{
			AirTemperature = (sbyte)random.Next(127),
			TrackTemperature = (sbyte)random.Next(127),
			Track = (Track)random.Next(127),
			MarshalZones = packet.MarshalZones.AsEnumerable().Select(x => x with
			{
				ZoneFlag = random.GetItems([FiaFlag.Green, FiaFlag.Yellow, FiaFlag.Blue, FiaFlag.None], 1)[0]
			}).ToArray(),
			WeatherForecastSamples = packet.WeatherForecastSamples.AsEnumerable().Select(x => x with
			{
				AirTemperature = (sbyte)random.Next(127),
				TrackTemperature = (sbyte)random.Next(127),
				AirTemperatureChange = random.GetItems(Enum.GetValues<TemperatureChange>(), 1)[0],
				TrackTemperatureChange = random.GetItems(Enum.GetValues<TemperatureChange>(), 1)[0],
			}).ToArray()
		};

		var writer = new BytesWriter(data);
		writer.Write(updatedPacket);

		return data;
	}

	static int GetPacketSize(PacketType packetType)
	{
		return packetType switch
		{
			PacketType.Motion => GetSize<MotionDataPacket>(),
			PacketType.Session => GetSize<SessionDataPacket>(),
			PacketType.LapData => GetSize<LapDataPacket>(),
			PacketType.Event => GetSize<EventDataPacket>(),
			PacketType.Participants => GetSize<ParticipantsDataPacket>(),
			PacketType.CarSetups => GetSize<CarSetupDataPacket>(),
			PacketType.CarTelemetry => GetSize<CarTelemetryDataPacket>(),
			PacketType.CarStatus => GetSize<CarStatusDataPacket>(),
			PacketType.FinalClassification => GetSize<FinalClassificationDataPacket>(),
			PacketType.LobbyInfo => GetSize<LobbyInfoDataPacket>(),
			PacketType.CarDamage => GetSize<CarDamageDataPacket>(),
			PacketType.SessionHistory => GetSize<SessionHistoryDataPacket>(),
			PacketType.TyreSets => GetSize<TyreSetsDataPacket>(),
			PacketType.MotionEx => GetSize<MotionExDataPacket>(),
			PacketType.TimeTrial => GetSize<TimeTrialDataPacket>(),
			PacketType.LapPositions => GetSize<LapPositionsDataPacket>(),
			_ => throw new ArgumentOutOfRangeException(nameof(packetType), packetType, null)
		};
	}

	static int GetSize<T>() where T : ISizeable => T.Size;
}
