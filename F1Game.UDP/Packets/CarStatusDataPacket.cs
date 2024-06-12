using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1239)]
public readonly record struct CarStatusDataPacket() : IByteParsable<CarStatusDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1239;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Array22<CarStatusData> CarStatusData { get; init; }

	static CarStatusDataPacket IByteParsable<CarStatusDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarStatusData = reader.GetNextArray22<CarStatusData>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarStatusData);
	}
}
