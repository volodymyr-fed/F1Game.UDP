using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record LapDataPacket : IPacket, IByteParsable<LapDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1131;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public LapData[] LapData { get; init; } = Array.Empty<LapData>(); // Lap data for all cars on track
	public byte TimeTrialPBCarIdx { get; init; } // Index of Personal Best car in time trial (255 if invalid)
	public byte TimeTrialRivalCarIdx { get; init; } // Index of Rival car in time trial (255 if invalid)

	static LapDataPacket IByteParsable<LapDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			LapData = reader.GetNextObjects<LapData>(22),
			TimeTrialPBCarIdx = reader.GetNextByte(),
			TimeTrialRivalCarIdx = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteObject(Header);
		writer.WriteObjects(LapData);
		writer.WriteByte(TimeTrialPBCarIdx);
		writer.WriteByte(TimeTrialRivalCarIdx);
	}
}
