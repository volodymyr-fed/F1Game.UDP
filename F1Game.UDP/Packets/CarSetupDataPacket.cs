using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1133)]
public readonly record struct CarSetupDataPacket() : IByteParsable<CarSetupDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1133;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Array22<CarSetupData> CarSetups { get; init; }
	public float NextFrontWingValue { get; init; } // Value of front wing after next pit stop - player only

	static CarSetupDataPacket IByteParsable<CarSetupDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarSetups = reader.GetNextArray22<CarSetupData>(),
			NextFrontWingValue = reader.GetNextFloat()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarSetups);
		writer.Write(NextFrontWingValue);
	}
}
