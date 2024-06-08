using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1349)]
public sealed record MotionDataPacket() : IPacket, IByteParsable<MotionDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1349;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public CarMotionData[] CarMotionData { get; init; } = []; // Data for all cars on track

	static MotionDataPacket IByteParsable<MotionDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarMotionData = reader.GetNextObjects<CarMotionData>(22),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarMotionData);
	}
}
