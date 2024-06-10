using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
public readonly record struct TimeTrialDataSet() : IByteParsable<TimeTrialDataSet>, IByteWritable
{
	public byte CarIndex { get; init; } // Index of the car this data relates to
	public Team Team { get; init; } // Team id - see appendix
	public uint LapTimeInMS { get; init; } // Lap time in milliseconds
	public uint Sector1TimeInMS { get; init; } // Sector 1 time in milliseconds
	public uint Sector2TimeInMS { get; init; } // Sector 2 time in milliseconds
	public uint Sector3TimeInMS { get; init; } // Sector 3 time in milliseconds
	public TractionOptions TractionControl { get; init; } // 0 = off, 1 = medium, 2 = full
	public GearboxAssist GearboxAssist { get; init; } // 1 = manual, 2 = manual & suggested gear, 3 = auto
	public AntiLockBrakesOptions AntiLockBrakes { get; init; } // 0 (off) - 1 (on)
	public bool EqualCarPerformance { get; init; } // 0 = Realistic, 1 = Equal
	public bool CustomSetup { get; init; } // 0 = No, 1 = Yes
	public bool Valid { get; init; } // 0 = Invalid, 1 = Valid

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
			EqualCarPerformance = reader.GetNextBoolean(),
			CustomSetup = reader.GetNextBoolean(),
			Valid = reader.GetNextBoolean(),
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
		writer.Write(EqualCarPerformance);
		writer.Write(CustomSetup);
		writer.Write(Valid);
	}
}
