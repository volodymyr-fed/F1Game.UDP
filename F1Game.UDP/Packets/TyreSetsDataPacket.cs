using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packets gives a more in-depth details about tyre sets assigned to a vehicle during the session.
/// <para>Frequency: 20 per second but cycling through cars</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct TyreSetsDataPacket() : IByteParsable<TyreSetsDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 231;

	public PacketHeader Header { get; init; }
	/// <summary>
	/// Index of the car this packet relates to
	/// </summary>
	public byte CarIndex { get; init; }
	/// <summary>
	/// 13 dry - 7 wet
	/// </summary>
	public Array20<TyreSetData> TyreSetDatas { get; init; }
	/// <summary>
	/// Index into array of fitted tyre
	/// </summary>
	public byte FittedIndex { get; init; }

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
		writer.Write(Header);
		writer.Write(CarIndex);
		writer.Write(TyreSetDatas.AsReadOnlySpan());
		writer.Write(FittedIndex);
	}
}
