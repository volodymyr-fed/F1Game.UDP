using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record CarStatusDataPacket : IPacket, IByteParsable<CarStatusDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1239;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
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
		writer.WriteObject(Header);
		writer.WriteObjects(CarStatusData);
	}
}
