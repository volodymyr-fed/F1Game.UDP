using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details car statuses for all the cars in the race.
/// <para>Frequency: Rate as specified in menus</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarStatusDataPacket() : IByteParsable<CarStatusDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1239;

	public PacketHeader Header { get; init; }
	public Array22<CarStatusData> CarStatusData { get; init; }

	static CarStatusDataPacket IByteParsable<CarStatusDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarStatusData = reader.GetNextObjects<CarStatusData>(22)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarStatusData.AsReadOnlySpan());
	}
}
