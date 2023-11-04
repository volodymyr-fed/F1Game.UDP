namespace F1Game.UDP.Enums;

[Flags]
public enum LapValid : byte
{
	LapValid = 1,
	Sector1Valid = 2,
	Sector2Valid = 4,
	Sector3Valid = 8,
}
