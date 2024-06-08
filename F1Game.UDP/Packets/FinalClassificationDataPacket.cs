using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1020)]
public sealed record FinalClassificationDataPacket() : IPacket, IByteParsable<FinalClassificationDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1020;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumCars { get; init; } // Number of cars in the final classification
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public FinalClassificationData[] ClassificationData { get; init; } = [];

	static FinalClassificationDataPacket IByteParsable<FinalClassificationDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumCars = reader.GetNextByte(),
			ClassificationData = reader.GetNextObjects<FinalClassificationData>(22)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(NumCars);
		writer.Write(ClassificationData);
	}
}
