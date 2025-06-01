using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details the final classification at the end of the race, and the data will match with the post race results screen.
/// <para>This is especially useful for multiplayer games where it is not always possible to send lap times on the final frame because of network delay.</para>
/// <para>Frequency: Once at the end of a race</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct FinalClassificationDataPacket() : IByteParsable<FinalClassificationDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1042;

	public PacketHeader Header { get; init; }
	/// <summary>
	/// Number of cars in the <see cref="ClassificationData" />
	/// </summary>
	public byte NumCars { get; init; }
	public Array22<FinalClassificationData> ClassificationData { get; init; }

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
		writer.Write(ClassificationData.AsReadOnlySpan());
	}
}
