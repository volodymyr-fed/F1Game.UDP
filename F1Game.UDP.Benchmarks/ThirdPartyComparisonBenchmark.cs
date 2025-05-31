using BenchmarkDotNet.Attributes;

using F1Game.UDP.Benchmarks.Helpers;
using F1Game.UDP.Enums;
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
		PacketType.TimeTrial
	])]
	public PacketType Type { get; set; }

	byte[] data = [];

	[GlobalSetup]
	public void GlobalSetup()
	{
		data = PacketGenerator.GeneratePacket(Type);
	}

	// Not applicable, no libraries that support F1 24 UDP telemetry
	//[Benchmark(Baseline = true)]
	public UnionPacket ReadF1GameUDP()
	{
		return data.ToPacket();
	}

	//[Benchmark]
	public void ReadF1Sharp()
	{
		F1SharpHelper.ReadPacket(data);
	}

	//[Benchmark]
	public Packet ReadF1Simracing()
	{
		return SimRacingHelpers.ReadPacket(data);
	}
}
