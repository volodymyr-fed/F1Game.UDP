using System.Runtime.InteropServices;

using BenchmarkDotNet.Attributes;

using F1_22_UDP_Telemetry_Receiver.Packets;

using F1Game.UDP.Packets;

using SharpSessionHistoryPacket = F1Sharp.Packets.SessionHistoryPacket;

namespace F1Game.UDP.Benchmarks;

[MemoryDiagnoser(true)]
public class ToPacketBenchmark
{
	readonly byte[] data;

	public ToPacketBenchmark()
	{
		data = new byte[SessionHistoryDataPacket.Size];
		new Random(42).NextBytes(data);
		data[6] = 11;
	}

	[Benchmark]
	public SessionHistoryDataPacket ReadSessionHistoryDataPacketMy()
	{
		var bytes = new BytesReader(data);
		return bytes.GetNextObject<SessionHistoryDataPacket>();
	}

	[Benchmark]
	public SharpSessionHistoryPacket ReadSessionHistoryPacketF1Sharp()
	{
		GCHandle handle = new();
		try
		{
			handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			return (SharpSessionHistoryPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SharpSessionHistoryPacket))!;
		}
		finally
		{
			if (handle.IsAllocated)
				handle.Free();
		}
	}

	[Benchmark]
	public PacketSessionHistoryData ReadPacketSessionHistoryDataF1Sim()
	{
		return new PacketSessionHistoryData(data);
	}
}
