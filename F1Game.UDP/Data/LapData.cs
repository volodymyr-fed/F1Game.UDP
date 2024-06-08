using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 50)]
public readonly record struct LapData() : IByteParsable<LapData>, IByteWritable
{
	public uint LastLapTimeInMS { get; init; } // Last lap time in milliseconds
	public uint CurrentLapTimeInMS { get; init; } // Current time around the lap in milliseconds
	public ushort Sector1TimeInMS { get; init; } // Sector 1 time in milliseconds
	public byte Sector1TimeInMinutes { get; init; } // Sector 1 whole minute part
	public ushort Sector2TimeInMS { get; init; } // Sector 2 time in milliseconds
	public byte Sector2TimeInMinutes { get; init; } // Sector 2 whole minute part
	public ushort DeltaToCarInFrontInMS { get; init; } // Time delta to car in front in milliseconds
	public ushort DeltaToRaceLeaderInMS { get; init; } // Time delta to race leader in milliseconds
	public float LapDistance { get; init; } // Distance vehicle is around current lap in metres – could
											// be negative if line hasn’t been crossed yet
	public float TotalDistance { get; init; } // Total distance travelled in session in metres – could
											  // be negative if line hasn’t been crossed yet
	public float SafetyCarDelta { get; init; } // Delta in seconds for safety car
	public byte CarPosition { get; init; } // Car race position
	public byte CurrentLapNum { get; init; } // Current lap number
	public PitStatus PitStatus { get; init; } // 0 = none, 1 = pitting, 2 = in pit area
	public byte NumPitStops { get; init; } // Number of pit stops taken in this race
	public Sector Sector { get; init; } // 0 = sector1, 1 = sector2, 2 = sector3
	private byte CurrentLapInvalidByte { get; init; } // Current lap invalid - 0 = valid, 1 = invalid
	public bool CurrentLapInvalid { get => CurrentLapInvalidByte.AsBool(); init => CurrentLapInvalidByte = value.AsByte(); }
	public byte Penalties { get; init; } // Accumulated time penalties in seconds to be added
	public byte TotalWarnings { get; init; } // Accumulated number of warnings issued
	public byte CornerCuttingWarnings { get; init; } // Accumulated number of corner cutting warnings issued
	public byte NumUnservedDriveThroughPens { get; init; } // Num drive through pens left to serve
	public byte NumUnservedStopGoPens { get; init; } // Num stop go pens left to serve
	public byte GridPosition { get; init; } // Grid position the vehicle started the race in
	public DriverStatus DriverStatus { get; init; }
	public ResultStatus ResultStatus { get; init; }
	private byte PitLaneTimerActiveByte { get; init; } // Pit lane timing, 0 = inactive, 1 = active
	public bool PitLaneTimerActive { get => PitLaneTimerActiveByte.AsBool(); init => PitLaneTimerActiveByte = value.AsByte(); }
	public ushort PitLaneTimeInLaneInMS { get; init; } // If active, the current time spent in the pit lane in ms
	public ushort PitStopTimerInMS { get; init; } // Time of the actual pit stop in ms
	public byte PitStopShouldServePen { get; init; } // Whether the car should serve a penalty at this stop

	static LapData IByteParsable<LapData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			LastLapTimeInMS = reader.GetNextUInt(),
			CurrentLapTimeInMS = reader.GetNextUInt(),
			Sector1TimeInMS = reader.GetNextUShort(),
			Sector1TimeInMinutes = reader.GetNextByte(),
			Sector2TimeInMS = reader.GetNextUShort(),
			Sector2TimeInMinutes = reader.GetNextByte(),
			DeltaToCarInFrontInMS = reader.GetNextUShort(),
			DeltaToRaceLeaderInMS = reader.GetNextUShort(),
			LapDistance = reader.GetNextFloat(),
			TotalDistance = reader.GetNextFloat(),
			SafetyCarDelta = reader.GetNextFloat(),
			CarPosition = reader.GetNextByte(),
			CurrentLapNum = reader.GetNextByte(),
			PitStatus = reader.GetNextEnum<PitStatus>(),
			NumPitStops = reader.GetNextByte(),
			Sector = reader.GetNextEnum<Sector>(),
			CurrentLapInvalidByte = reader.GetNextByte(),
			Penalties = reader.GetNextByte(),
			TotalWarnings = reader.GetNextByte(),
			CornerCuttingWarnings = reader.GetNextByte(),
			NumUnservedDriveThroughPens = reader.GetNextByte(),
			NumUnservedStopGoPens = reader.GetNextByte(),
			GridPosition = reader.GetNextByte(),
			DriverStatus = reader.GetNextEnum<DriverStatus>(),
			ResultStatus = reader.GetNextEnum<ResultStatus>(),
			PitLaneTimerActiveByte = reader.GetNextByte(),
			PitLaneTimeInLaneInMS = reader.GetNextUShort(),
			PitStopTimerInMS = reader.GetNextUShort(),
			PitStopShouldServePen = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(LastLapTimeInMS);
		writer.Write(CurrentLapTimeInMS);
		writer.Write(Sector1TimeInMS);
		writer.Write(Sector1TimeInMinutes);
		writer.Write(Sector2TimeInMS);
		writer.Write(Sector2TimeInMinutes);
		writer.Write(DeltaToCarInFrontInMS);
		writer.Write(DeltaToRaceLeaderInMS);
		writer.Write(LapDistance);
		writer.Write(TotalDistance);
		writer.Write(SafetyCarDelta);
		writer.Write(CarPosition);
		writer.Write(CurrentLapNum);
		writer.WriteEnum(PitStatus);
		writer.Write(NumPitStops);
		writer.WriteEnum(Sector);
		writer.Write(CurrentLapInvalidByte);
		writer.Write(Penalties);
		writer.Write(TotalWarnings);
		writer.Write(CornerCuttingWarnings);
		writer.Write(NumUnservedDriveThroughPens);
		writer.Write(NumUnservedStopGoPens);
		writer.Write(GridPosition);
		writer.WriteEnum(DriverStatus);
		writer.WriteEnum(ResultStatus);
		writer.Write(PitLaneTimerActiveByte);
		writer.Write(PitLaneTimeInLaneInMS);
		writer.Write(PitStopTimerInMS);
		writer.Write(PitStopShouldServePen);
	}
}
