using BenchmarkDotNet.Attributes;

using F1Game.UDP.Benchmarks.Helpers;
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

	[Benchmark]
	public UnionPacket ReadF1GameUDPReader()
	{
		return data.ToPacketWithReader();
	}

	[Benchmark(Baseline = true)]
	public UnionPacket ReadF1GameUDPMarshal()
	{
		return data.ToPacket();
	}
}
