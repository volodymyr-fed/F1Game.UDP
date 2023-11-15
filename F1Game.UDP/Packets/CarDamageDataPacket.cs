using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record CarDamageDataPacket : IPacket, IByteParsable<CarDamageDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 953;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
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
		writer.WriteObject(Header);
		writer.WriteObjects(CarDamageData);
	}
}
