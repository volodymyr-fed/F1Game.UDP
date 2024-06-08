using BenchmarkDotNet.Attributes;

using F1Game.UDP.Enums;
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
		PacketType.FinalClassification,
		PacketType.LapData,
		PacketType.LobbyInfo,
		PacketType.Motion,
		PacketType.MotionEx,
		PacketType.Participants,
		PacketType.Session,
		PacketType.SessionHistory,
		PacketType.TyreSets,
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
			_ => throw new NotImplementedException()
		};

		data = new byte[size];

		new Random(42).NextBytes(data);
		data[6] = (byte)Type;
	}

	[Benchmark]
	public IPacket ReadF1GameUDPReader()
	{
		return data.ToPacketWithReader();
	}

	[Benchmark(Baseline = true)]
	public IPacket ReadF1GameUDPMarshal()
	{
		return data.ToPacketWithMarshal();
	}
}
