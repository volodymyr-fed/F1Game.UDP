using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 953)]
public readonly record struct CarDamageDataPacket() : IByteParsable<CarDamageDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 953;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	public Array22<CarDamageData> CarDamageData { get; init; }

	static CarDamageDataPacket IByteParsable<CarDamageDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarDamageData = reader.GetNextArray22<CarDamageData>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarDamageData);
	}
}
