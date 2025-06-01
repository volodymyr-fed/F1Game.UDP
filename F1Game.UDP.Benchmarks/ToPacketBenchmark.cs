using BenchmarkDotNet.Attributes;

using F1Game.UDP.Benchmarks.Helpers;
using F1Game.UDP.Enums;
using F1Game.UDP.Packets;

namespace F1Game.UDP.Benchmarks;

[MemoryDiagnoser(true)]
public class ToPacketBenchmark
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
		PacketType.TimeTrial,
		PacketType.LapPositions
	])]
	public PacketType Type { get; set; }

	byte[] data = [];

	[GlobalSetup]
	public void GlobalSetup()
	{
		data = PacketGenerator.GeneratePacket(Type);
	}

	[Benchmark(Baseline = true)]
	public UnionPacket ReadPacket()
	{
		return data.ToPacket();
	}
}
