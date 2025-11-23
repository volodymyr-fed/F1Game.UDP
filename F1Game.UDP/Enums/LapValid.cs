#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the validity of a lap and its sectors in the F1 game.
/// </summary>
[Flags]
public enum LapValid : byte
{
	LapValid = 1,
	Sector1Valid = 2,
	Sector2Valid = 4,
	Sector3Valid = 8,
}
