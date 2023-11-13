using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record FinalClassificationDataPacket : IPacket, IByteParsable<FinalClassificationDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1020;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumCars { get; init; } // Number of cars in the final classification
	public FinalClassificationData[] ClassificationData { get; init; } = Array.Empty<FinalClassificationData>();

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
		writer.WriteObject(Header);
		writer.WriteByte(NumCars);
		writer.WriteObjects(ClassificationData);
	}
}
