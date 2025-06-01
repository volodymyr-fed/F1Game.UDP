using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details car damage parameters for all the cars in the race.
/// <para>Frequency: 10 per second</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarDamageDataPacket() : IByteParsable<CarDamageDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 953;

	public PacketHeader Header { get; init; }
	public Array22<CarDamageData> CarDamageData { get; init; }

	static CarDamageDataPacket IByteParsable<CarDamageDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarDamageData = reader.GetNextObjects<CarDamageData>(22)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarDamageData.AsReadOnlySpan());
	}
}
