using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 231)]
public readonly record struct TyreSetsDataPacket() : IByteParsable<TyreSetsDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 231;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	public byte CarIndex { get; init; } //Index of the car this packet relates to
	public Array20<TyreSetData> TyreSetDatas { get; init; } // 13 dry - 7 wet
	public byte FittedIndex { get; init; } // Index into array of fitted tyre

	static TyreSetsDataPacket IByteParsable<TyreSetsDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarIndex = reader.GetNextByte(),
			TyreSetDatas = reader.GetNextArray20<TyreSetData>(),
			FittedIndex = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarIndex);
		writer.Write(TyreSetDatas);
		writer.Write(FittedIndex);
	}
}
