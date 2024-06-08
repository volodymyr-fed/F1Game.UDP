using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 45)]
public readonly record struct FinalClassificationData() : IByteParsable<FinalClassificationData>, IByteWritable
{
	public byte Position { get; init; } // Finishing position
	public byte NumLaps { get; init; } // Number of laps completed
	public byte GridPosition { get; init; } // Grid position of the car
	public byte Points { get; init; } // Number of points scored
	public byte NumPitStops { get; init; } // Number of pit stops made
	public ResultStatus ResultStatus { get; init; } // Result status - 0 = invalid, 1 = inactive, 2 = active
													// 3 = finished, 4 = didnotfinish, 5 = disqualified
													// 6 = not classified, 7 = retired
	public uint BestLapTimeInMS { get; init; } // Best lap time of the session in milliseconds
	public double TotalRaceTime { get; init; } // Total race time in seconds without penalties
	public byte PenaltiesTime { get; init; } // Total penalties accumulated in seconds
	public byte NumPenalties { get; init; } // Number of penalties applied to this driver
	public byte NumTyreStints { get; init; } // Number of tyres stints up to maximum
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public ActualCompound[] TyreStintsActual { get; init; } = []; // Actual tyres used by this driver 8
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public VisualCompound[] TyreStintsVisual { get; init; } = []; // Visual tyres used by this driver 8
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] TyreStintsEndLaps { get; init; } = []; // The lap number stints end on 8

	static FinalClassificationData IByteParsable<FinalClassificationData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Position = reader.GetNextByte(),
			NumLaps = reader.GetNextByte(),
			GridPosition = reader.GetNextByte(),
			Points = reader.GetNextByte(),
			NumPitStops = reader.GetNextByte(),
			ResultStatus = reader.GetNextEnum<ResultStatus>(),
			BestLapTimeInMS = reader.GetNextUInt(),
			TotalRaceTime = reader.GetNextDouble(),
			PenaltiesTime = reader.GetNextByte(),
			NumPenalties = reader.GetNextByte(),
			NumTyreStints = reader.GetNextByte(),
			TyreStintsActual = reader.GetNextEnums<ActualCompound>(8),
			TyreStintsVisual = reader.GetNextEnums<VisualCompound>(8),
			TyreStintsEndLaps = reader.GetNextBytes(8).ToArray(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Position);
		writer.Write(NumLaps);
		writer.Write(GridPosition);
		writer.Write(Points);
		writer.Write(NumPitStops);
		writer.WriteEnum(ResultStatus);
		writer.Write(BestLapTimeInMS);
		writer.Write(TotalRaceTime);
		writer.Write(PenaltiesTime);
		writer.Write(NumPenalties);
		writer.Write(NumTyreStints);
		writer.WriteEnums(TyreStintsActual);
		writer.WriteEnums(TyreStintsVisual);
		writer.Write(TyreStintsEndLaps);
	}
}
