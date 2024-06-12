using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1020)]
public readonly record struct FinalClassificationDataPacket() : IByteParsable<FinalClassificationDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1020;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumCars { get; init; } // Number of cars in the final classification
	public Array22<FinalClassificationData> ClassificationData { get; init; }

	static FinalClassificationDataPacket IByteParsable<FinalClassificationDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumCars = reader.GetNextByte(),
			ClassificationData = reader.GetNextArray22<FinalClassificationData>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(NumCars);
		writer.Write(ClassificationData);
	}
}
