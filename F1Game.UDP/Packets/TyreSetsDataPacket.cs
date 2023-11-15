using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record TyreSetsDataPacket : IPacket, IByteParsable<TyreSetsDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 231;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	public byte CarIndex { get; init; } //Index of the car this packet relates to
	public TyreSetData[] TyreSetDatas { get; init; } = []; // 13 dry - 7 wet
	public byte FittedIndex { get; init; } // Index into array of fitted tyre

	static TyreSetsDataPacket IByteParsable<TyreSetsDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarIndex = reader.GetNextByte(),
			TyreSetDatas = reader.GetNextObjects<TyreSetData>(20),
			FittedIndex = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteObject(Header);
		writer.WriteByte(CarIndex);
		writer.WriteObjects(TyreSetDatas);
		writer.WriteByte(FittedIndex);
	}
}
