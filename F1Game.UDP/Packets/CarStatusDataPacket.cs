using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1239)]
public sealed record CarStatusDataPacket() : IPacket, IByteParsable<CarStatusDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1239;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public CarStatusData[] CarStatusData { get; init; } = [];

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
		writer.Write(CarStatusData);
	}
}
