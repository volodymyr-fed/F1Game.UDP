using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1349)]
public readonly record struct MotionDataPacket() : IByteParsable<MotionDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1349;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Array22<CarMotionData> CarMotionData { get; init; } // Data for all cars on track

	static MotionDataPacket IByteParsable<MotionDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarMotionData = reader.GetNextArray22<CarMotionData>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarMotionData);
	}
}
