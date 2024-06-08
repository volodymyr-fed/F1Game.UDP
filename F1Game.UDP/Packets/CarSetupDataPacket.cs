using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1107)]
public sealed record CarSetupDataPacket() : IPacket, IByteParsable<CarSetupDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1107;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public CarSetupData[] CarSetups { get; init; } = [];

	static CarSetupDataPacket IByteParsable<CarSetupDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarSetups = reader.GetNextObjects<CarSetupData>(22)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarSetups);
	}
}
