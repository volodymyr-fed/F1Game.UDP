using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1285)]
public readonly record struct LapDataPacket() : IByteParsable<LapDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1285;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Array22<LapData> LapData { get; init; } // Lap data for all cars on track
	public byte TimeTrialPBCarIdx { get; init; } // Index of Personal Best car in time trial (255 if invalid)
	public byte TimeTrialRivalCarIdx { get; init; } // Index of Rival car in time trial (255 if invalid)

	static LapDataPacket IByteParsable<LapDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			LapData = reader.GetNextArray22<LapData>(),
			TimeTrialPBCarIdx = reader.GetNextByte(),
			TimeTrialRivalCarIdx = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(LapData);
		writer.Write(TimeTrialPBCarIdx);
		writer.Write(TimeTrialRivalCarIdx);
	}
}
