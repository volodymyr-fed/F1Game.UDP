using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record CarSetupDataPacket : IPacket, IByteParsable<CarSetupDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1107;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
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
		writer.WriteObject(Header);
		writer.WriteObjects(CarSetups);
	}
}
