using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct TimeTrialDataSet() : IByteParsable<TimeTrialDataSet>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 24;

	/// <summary>
	/// Index of the car this data relates to.
	/// </summary>
	public byte CarIndex { get; init; }
	/// <summary>
	/// Team
	/// </summary>
	public Team Team { get; init; }
	/// <summary>
	/// Lap time in milliseconds.
	/// </summary>
	public uint LapTimeInMS { get; init; }
	/// <summary>
	/// Sector 1 time in milliseconds.
	/// </summary>
	public uint Sector1TimeInMS { get; init; }
	/// <summary>
	/// Sector 2 time in milliseconds.
	/// </summary>
	public uint Sector2TimeInMS { get; init; }
	/// <summary>
	/// Sector 3 time in milliseconds.
	/// </summary>
	public uint Sector3TimeInMS { get; init; }
	/// <summary>
	/// Traction control setting.
	/// </summary>
	public TractionOptions TractionControl { get; init; }
	/// <summary>
	/// Gearbox assist.
	/// </summary>
	public GearboxAssist GearboxAssist { get; init; }
	/// <summary>
	/// Anti-lock brakes.
	/// </summary>
	public AntiLockBrakesOptions AntiLockBrakes { get; init; }
	/// <summary>
	/// Is car performance equal.
	/// </summary>
	public bool IsEqualCarPerformance { get; init; }
	/// <summary>
	/// Custom setup enabled.
	/// </summary>
	public bool IsCustomSetupEnabled { get; init; }
	/// <summary>
	/// Lap validity.
	/// </summary>
	public bool IsValid { get; init; }

	static TimeTrialDataSet IByteParsable<TimeTrialDataSet>.Parse(ref BytesReader reader)
	{
		return new()
		{
			CarIndex = reader.GetNextByte(),
			Team = reader.GetNextEnum<Team>(),
			LapTimeInMS = reader.GetNextUInt(),
			Sector1TimeInMS = reader.GetNextUInt(),
			Sector2TimeInMS = reader.GetNextUInt(),
			Sector3TimeInMS = reader.GetNextUInt(),
			TractionControl = reader.GetNextEnum<TractionOptions>(),
			GearboxAssist = reader.GetNextEnum<GearboxAssist>(),
			AntiLockBrakes = reader.GetNextEnum<AntiLockBrakesOptions>(),
			IsEqualCarPerformance = reader.GetNextBoolean(),
			IsCustomSetupEnabled = reader.GetNextBoolean(),
			IsValid = reader.GetNextBoolean(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(CarIndex);
		writer.WriteEnum(Team);
		writer.Write(LapTimeInMS);
		writer.Write(Sector1TimeInMS);
		writer.Write(Sector2TimeInMS);
		writer.Write(Sector3TimeInMS);
		writer.WriteEnum(TractionControl);
		writer.WriteEnum(GearboxAssist);
		writer.WriteEnum(AntiLockBrakes);
		writer.Write(IsEqualCarPerformance);
		writer.Write(IsCustomSetupEnabled);
		writer.Write(IsValid);
	}
}
