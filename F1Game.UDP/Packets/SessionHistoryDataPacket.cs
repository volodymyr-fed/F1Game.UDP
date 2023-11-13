using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record SessionHistoryDataPacket : IPacket, IByteParsable<SessionHistoryDataPacket>, ISizeable
{
	public static int Size => 1460;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte CarIndex { get; init; } // Index of the car this lap data relates to
	public byte NumLaps { get; init; } // Num laps in the data (including current partial lap)
	public byte NumTyreStints { get; init; } // Number of tyre stints in the data
	public byte BestLapTimeLapNum { get; init; } // Lap the best lap time was achieved on
	public byte BestSector1LapNum { get; init; } // Lap the best Sector 1 time was achieved on
	public byte BestSector2LapNum { get; init; } // Lap the best Sector 2 time was achieved on
	public byte BestSector3LapNum { get; init; } // Lap the best Sector 3 time was achieved on
	public LapHistoryData[] LapHistoryData { get; init; } = Array.Empty<LapHistoryData>(); // 100 laps of data max
	public TyreStintHistoryData[] TyreStintsHistoryData { get; init; } = Array.Empty<TyreStintHistoryData>(); // max 8

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
}
