using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// The lap data packet gives details of all the cars in the session.
/// <para>Frequency: Rate as specified in menus</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct LapDataPacket() : IByteParsable<LapDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1285;

	public PacketHeader Header { get; init; }
	public Array22<LapData> LapData { get; init; }
	/// <summary>
	/// Index of Personal Best car in time trial (255 if invalid)
	/// </summary>
	public byte TimeTrialPBCarIdx { get; init; }
	/// <summary>
	///  Index of Rival car in time trial (255 if invalid)
	/// </summary>
	public byte TimeTrialRivalCarIdx { get; init; }

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
