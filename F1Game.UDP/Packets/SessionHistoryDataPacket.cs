using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet contains lap times and tyre usage for the session.
/// <para>
/// This packet works slightly differently to other packets.
/// To reduce CPU and bandwidth, each packet relates to a specific vehicle and is sent every 1/20 s, and the vehicle being sent is cycled through.
/// Therefore in a 20 car race you should receive an update for each vehicle at least once per second.
/// </para>
/// <para>
/// Note that at the end of the race, after the final classification packet has been sent,
/// a final bulk update of all the session histories for the vehicles in that session will be sent.
/// </para>
/// <para>Frequency: 20 per second but cycling through cars</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct SessionHistoryDataPacket() : IByteParsable<SessionHistoryDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1460;

	public PacketHeader Header { get; init; }
	/// <summary>
	/// Index of the car this lap data relates to
	/// </summary>
	public byte CarIndex { get; init; }
	/// <summary>
	/// Num laps in the data (including current partial lap)
	/// </summary>
	public byte NumLaps { get; init; }
	/// <summary>
	/// Number of tyre stints in the data
	/// </summary>
	public byte NumTyreStints { get; init; }
	/// <summary>
	/// Lap the best lap time was achieved on
	/// </summary>
	public byte BestLapTimeLapNum { get; init; }
	/// <summary>
	/// Lap the best Sector 1 time was achieved on
	/// </summary>
	public byte BestSector1LapNum { get; init; }
	/// <summary>
	/// Lap the best Sector 2 time was achieved on
	/// </summary>
	public byte BestSector2LapNum { get; init; }
	/// <summary>
	/// Lap the best Sector 3 time was achieved on
	/// </summary>
	public byte BestSector3LapNum { get; init; }
	public Array100<LapHistoryData> LapHistoryData { get; init; }
	public Array8<TyreStintHistoryData> TyreStintsHistoryData { get; init; }

	static SessionHistoryDataPacket IByteParsable<SessionHistoryDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarIndex = reader.GetNextByte(),
			NumLaps = reader.GetNextByte(),
			NumTyreStints = reader.GetNextByte(),
			BestLapTimeLapNum = reader.GetNextByte(),
			BestSector1LapNum = reader.GetNextByte(),
			BestSector2LapNum = reader.GetNextByte(),
			BestSector3LapNum = reader.GetNextByte(),
			LapHistoryData = reader.GetNextObjects<LapHistoryData>(100),
			TyreStintsHistoryData = reader.GetNextObjects<TyreStintHistoryData>(8)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarIndex);
		writer.Write(NumLaps);
		writer.Write(NumTyreStints);
		writer.Write(BestLapTimeLapNum);
		writer.Write(BestSector1LapNum);
		writer.Write(BestSector2LapNum);
		writer.Write(BestSector3LapNum);
		writer.Write(LapHistoryData.AsReadOnlySpan());
		writer.Write(TyreStintsHistoryData.AsReadOnlySpan());
	}
}
