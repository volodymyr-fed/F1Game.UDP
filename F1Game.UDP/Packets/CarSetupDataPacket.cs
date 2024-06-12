using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1107)]
public readonly record struct CarSetupDataPacket() : IByteParsable<CarSetupDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1107;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Array22<CarSetupData> CarSetups { get; init; }

	static CarSetupDataPacket IByteParsable<CarSetupDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarSetups = reader.GetNextArray22<CarSetupData>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarSetups);
	}
}
