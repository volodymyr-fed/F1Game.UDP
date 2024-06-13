using System.Buffers.Binary;

using BenchmarkDotNet.Attributes;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Packets;

namespace F1Game.UDP.Benchmarks;

[MemoryDiagnoser(true)]
public class InternalBenchmark
{
	[Params([
		PacketType.CarDamage,
		PacketType.CarSetups,
		PacketType.CarStatus,
		PacketType.CarTelemetry,
		PacketType.Event,
		PacketType.FinalClassification,
		PacketType.LapData,
		PacketType.LobbyInfo,
		PacketType.Motion,
		PacketType.MotionEx,
		PacketType.Participants,
		PacketType.Session,
		PacketType.SessionHistory,
		PacketType.TyreSets,
		PacketType.TimeTrial
		])]
	public PacketType Type { get; set; }

	byte[] data = [];

	[GlobalSetup]
	public void GlobalSetup()
	{
		var size = Type switch
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
			PacketType.TimeTrial => TimeTrialDataPacket.Size,
			_ => throw new NotImplementedException()
		};

		data = new byte[size];

		new Random(42).NextBytes(data);
		data[6] = (byte)Type;

		if (Type == PacketType.Event)
			BinaryPrimitives.WriteUInt32LittleEndian(data.AsSpan()[PacketHeader.Size..], (uint) EventType.SpeedTrapTriggered);
	}

	[Benchmark]
	public UnionPacket ReadF1GameUDPReader()
	{
		return data.ToPacketWithReader();
	}

	[Benchmark(Baseline = true)]
	public UnionPacket ReadF1GameUDPMarshal()
	{
		return data.ToPacketWithMarshal();
	}
}
