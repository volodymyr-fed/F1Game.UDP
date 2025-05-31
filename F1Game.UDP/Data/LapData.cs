using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct LapData() : IByteParsable<LapData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 57;

	/// <summary>
	/// Last lap time in milliseconds.
	/// </summary>
	public uint LastLapTimeInMS { get; init; }
	/// <summary>
	/// Current time around the lap in milliseconds.
	/// </summary>
	public uint CurrentLapTimeInMS { get; init; }
	/// <summary>
	/// Sector 1 time in milliseconds.
	/// </summary>
	public ushort Sector1TimeInMS { get; init; }
	/// <summary>
	/// Sector 1 whole minute part.
	/// </summary>
	public byte Sector1TimeInMinutes { get; init; }
	/// <summary>
	/// Sector 2 time in milliseconds.
	/// </summary>
	public ushort Sector2TimeInMS { get; init; }
	/// <summary>
	/// Sector 2 whole minute part.
	/// </summary>
	public byte Sector2TimeInMinutes { get; init; }
	/// <summary>
	/// Time delta to car in front in milliseconds.
	/// </summary>
	public ushort DeltaToCarInFrontInMS { get; init; }
	/// <summary>
	/// Time delta to car in front in minutes.
	/// </summary>
	public byte DeltaToCarInFrontInMinutes { get; init; }
	/// <summary>
	/// Time delta to race leader in milliseconds.
	/// </summary>
	public ushort DeltaToRaceLeaderInMS { get; init; }
	/// <summary>
	/// Time delta to race leader in whole minutes.
	/// </summary>
	public byte DeltaToRaceLeaderInMinutes { get; init; }
	/// <summary>
	/// Distance vehicle is around current lap in metres – could be negative if line hasn’t been crossed yet.
	/// </summary>
	public float LapDistance { get; init; }
	/// <summary>
	/// Total distance travelled in session in metres – could be negative if line hasn’t been crossed yet.
	/// </summary>
	public float TotalDistance { get; init; }
	/// <summary>
	/// Delta in seconds for safety car.
	/// </summary>
	public float SafetyCarDelta { get; init; }
	/// <summary>
	/// Car race position.
	/// </summary>
	public byte CarPosition { get; init; }
	/// <summary>
	/// Current lap number.
	/// </summary>
	public byte CurrentLapNum { get; init; }
	/// <summary>
	/// Pit status
	/// </summary>
	public PitStatus PitStatus { get; init; }
	/// <summary>
	/// Number of pit stops taken in this race.
	/// </summary>
	public byte NumPitStops { get; init; }
	/// <summary>
	/// Sector.
	/// </summary>
	public Sector Sector { get; init; }
	/// <summary>
	/// Validity of the current lap.
	/// </summary>
	public bool IsCurrentLapInvalid { get; init; }
	/// <summary>
	/// Accumulated time penalties in seconds to be added.
	/// </summary>
	public byte Penalties { get; init; }
	/// <summary>
	/// Accumulated number of warnings issued.
	/// </summary>
	public byte TotalWarnings { get; init; }
	/// <summary>
	/// Accumulated number of corner cutting warnings issued.
	/// </summary>
	public byte CornerCuttingWarnings { get; init; }
	/// <summary>
	/// Number of drive through penalties left to serve.
	/// </summary>
	public byte NumUnservedDriveThroughPens { get; init; }
	/// <summary>
	/// Number of stop go penalties left to serve.
	/// </summary>
	public byte NumUnservedStopGoPens { get; init; }
	/// <summary>
	/// Grid position the vehicle started the race in.
	/// </summary>
	public byte GridPosition { get; init; }
	/// <summary>
	/// Status of the driver.
	/// </summary>
	public DriverStatus DriverStatus { get; init; }
	/// <summary>
	/// Result status of the driver.
	/// </summary>
	public ResultStatus ResultStatus { get; init; }
	/// <summary>
	/// Pit lane timer status
	/// </summary>
	public bool PitLaneTimerActive { get; init; }
	/// <summary>
	/// If active, the current time spent in the pit lane in milliseconds.
	/// </summary>
	public ushort PitLaneTimeInLaneInMS { get; init; }
	/// <summary>
	/// Time of the actual pit stop in milliseconds.
	/// </summary>
	public ushort PitStopTimerInMS { get; init; }
	/// <summary>
	/// Whether the car should serve a penalty at this stop.
	/// </summary>
	public bool PitStopShouldServePen { get; init; }
	/// <summary>
	/// Fastest speed through speed trap for this car in km/h.
	/// </summary>
	public float SpeedTrapFastestSpeed { get; init; }
	/// <summary>
	/// Lap number the fastest speed was achieved, 255 = not set.
	/// </summary>
	public byte SpeedTrapFastestLap { get; init; }

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
			IsCurrentLapInvalid = reader.GetNextBoolean(),
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
		writer.Write(IsCurrentLapInvalid);
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
