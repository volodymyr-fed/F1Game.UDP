using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 953)]
public sealed record CarDamageDataPacket() : IPacket, IByteParsable<CarDamageDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 953;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public CarDamageData[] CarDamageData { get; init; } = [];

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
		writer.Write(CarDamageData);
	}
}
