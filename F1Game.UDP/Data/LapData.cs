using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 57)]
public readonly record struct LapData() : IByteParsable<LapData>, IByteWritable
{
	public uint LastLapTimeInMS { get; init; } // Last lap time in milliseconds
	public uint CurrentLapTimeInMS { get; init; } // Current time around the lap in milliseconds
	public ushort Sector1TimeInMS { get; init; } // Sector 1 time in milliseconds
	public byte Sector1TimeInMinutes { get; init; } // Sector 1 whole minute part
	public ushort Sector2TimeInMS { get; init; } // Sector 2 time in milliseconds
	public byte Sector2TimeInMinutes { get; init; } // Sector 2 whole minute part
	public ushort DeltaToCarInFrontInMS { get; init; } // Time delta to car in front in milliseconds
	public byte DeltaToCarInFrontInMinutes { get; init; } // Time delta to car in front in minutes
	public ushort DeltaToRaceLeaderInMS { get; init; } // Time delta to race leader in milliseconds
	public byte DeltaToRaceLeaderInMinutes { get; init; } // Time delta to race leader in whole minutes
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
	public bool CurrentLapInvalid { get; init; } // Current lap invalid - 0 = valid, 1 = invalid
	public byte Penalties { get; init; } // Accumulated time penalties in seconds to be added
	public byte TotalWarnings { get; init; } // Accumulated number of warnings issued
	public byte CornerCuttingWarnings { get; init; } // Accumulated number of corner cutting warnings issued
	public byte NumUnservedDriveThroughPens { get; init; } // Num drive through pens left to serve
	public byte NumUnservedStopGoPens { get; init; } // Num stop go pens left to serve
	public byte GridPosition { get; init; } // Grid position the vehicle started the race in
	public DriverStatus DriverStatus { get; init; }
	public ResultStatus ResultStatus { get; init; }
	public bool PitLaneTimerActive { get; init; } // Pit lane timing, 0 = inactive, 1 = active
	public ushort PitLaneTimeInLaneInMS { get; init; } // If active, the current time spent in the pit lane in ms
	public ushort PitStopTimerInMS { get; init; } // Time of the actual pit stop in ms
	public bool PitStopShouldServePen { get; init; } // Whether the car should serve a penalty at this stop
	public float SpeedTrapFastestSpeed { get; init; } // Fastest speed through speed trap for this car in kmph
	public byte SpeedTrapFastestLap { get; init; } // Lap no the fastest speed was achieved, 255 = not set

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
			DeltaToCarInFrontInMinutes = reader.GetNextByte(),
			DeltaToRaceLeaderInMS = reader.GetNextUShort(),
			DeltaToRaceLeaderInMinutes = reader.GetNextByte(),
			LapDistance = reader.GetNextFloat(),
			TotalDistance = reader.GetNextFloat(),
			SafetyCarDelta = reader.GetNextFloat(),
			CarPosition = reader.GetNextByte(),
			CurrentLapNum = reader.GetNextByte(),
			PitStatus = reader.GetNextEnum<PitStatus>(),
			NumPitStops = reader.GetNextByte(),
			Sector = reader.GetNextEnum<Sector>(),
			CurrentLapInvalid = reader.GetNextBoolean(),
			Penalties = reader.GetNextByte(),
			TotalWarnings = reader.GetNextByte(),
			CornerCuttingWarnings = reader.GetNextByte(),
			NumUnservedDriveThroughPens = reader.GetNextByte(),
			NumUnservedStopGoPens = reader.GetNextByte(),
			GridPosition = reader.GetNextByte(),
			DriverStatus = reader.GetNextEnum<DriverStatus>(),
			ResultStatus = reader.GetNextEnum<ResultStatus>(),
			PitLaneTimerActive = reader.GetNextBoolean(),
			PitLaneTimeInLaneInMS = reader.GetNextUShort(),
			PitStopTimerInMS = reader.GetNextUShort(),
			PitStopShouldServePen = reader.GetNextBoolean(),
			SpeedTrapFastestSpeed = reader.GetNextFloat(),
			SpeedTrapFastestLap = reader.GetNextByte()
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
		writer.Write(DeltaToCarInFrontInMinutes);
		writer.Write(DeltaToRaceLeaderInMS);
		writer.Write(DeltaToRaceLeaderInMinutes);
		writer.Write(LapDistance);
		writer.Write(TotalDistance);
		writer.Write(SafetyCarDelta);
		writer.Write(CarPosition);
		writer.Write(CurrentLapNum);
		writer.WriteEnum(PitStatus);
		writer.Write(NumPitStops);
		writer.WriteEnum(Sector);
		writer.Write(CurrentLapInvalid);
		writer.Write(Penalties);
		writer.Write(TotalWarnings);
		writer.Write(CornerCuttingWarnings);
		writer.Write(NumUnservedDriveThroughPens);
		writer.Write(NumUnservedStopGoPens);
		writer.Write(GridPosition);
		writer.WriteEnum(DriverStatus);
		writer.WriteEnum(ResultStatus);
		writer.Write(PitLaneTimerActive);
		writer.Write(PitLaneTimeInLaneInMS);
		writer.Write(PitStopTimerInMS);
		writer.Write(PitStopShouldServePen);
		writer.Write(SpeedTrapFastestSpeed);
		writer.Write(SpeedTrapFastestLap);
	}
}
