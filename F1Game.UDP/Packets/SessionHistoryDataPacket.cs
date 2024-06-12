using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1460)]
public readonly record struct SessionHistoryDataPacket() : IByteParsable<SessionHistoryDataPacket>, ISizeable, IByteWritable, IHaveHeader
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
	public Array100<LapHistoryData> LapHistoryData { get; init; } // 100 laps of data max
	public Array8<TyreStintHistoryData> TyreStintsHistoryData { get; init; } // max 8

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
			LapHistoryData = reader.GetNextArray100<LapHistoryData>(),
			TyreStintsHistoryData = reader.GetNextArray8<TyreStintHistoryData>()
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
		writer.Write(LapHistoryData);
		writer.Write(TyreStintsHistoryData);
	}
}
