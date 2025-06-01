using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct FinalClassificationData() : IByteParsable<FinalClassificationData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 45;

	/// <summary>
	/// The finishing position.
	/// </summary>
	public byte Position { get; init; }
	/// <summary>
	/// The number of laps completed.
	/// </summary>
	public byte NumLaps { get; init; }
	/// <summary>
	/// The grid position of the car.
	/// </summary>
	public byte GridPosition { get; init; }
	/// <summary>
	/// The number of points scored.
	/// </summary>
	public byte Points { get; init; }
	/// <summary>
	/// The number of pit stops made.
	/// </summary>
	public byte NumPitStops { get; init; }
	/// <summary>
	/// The result status of the driver.
	/// </summary>
	public ResultStatus ResultStatus { get; init; }
	/// <summary>
	/// The best lap time of the session in milliseconds.
	/// </summary>
	public uint BestLapTimeInMS { get; init; }
	/// <summary>
	/// The total race time in seconds without penalties.
	/// </summary>
	public double TotalRaceTime { get; init; }
	/// <summary>
	/// The total penalties accumulated in seconds.
	/// </summary>
	public byte PenaltiesTime { get; init; }
	/// <summary>
	/// The number of penalties applied to this driver.
	/// </summary>
	public byte NumPenalties { get; init; }
	/// <summary>
	/// The number of tyre stints up to maximum.
	/// </summary>
	public byte NumTyreStints { get; init; }
	/// <summary>
	/// The actual tyres used by this driver (8 stints).
	/// </summary>
	public Array8<ActualCompound> TyreStintsActual { get; init; }
	/// <summary>
	/// The visual tyres used by this driver (8 stints).
	/// </summary>
	public Array8<VisualCompound> TyreStintsVisual { get; init; }
	/// <summary>
	/// The lap number stints end on (8 stints).
	/// </summary>
	public Array8<byte> TyreStintsEndLaps { get; init; }

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
			TyreStintsEndLaps = reader.GetNextBytes(8),
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
		writer.WriteEnums(TyreStintsActual.AsReadOnlySpan());
		writer.WriteEnums(TyreStintsVisual.AsReadOnlySpan());
		writer.Write(TyreStintsEndLaps.AsReadOnlySpan());
	}
}
