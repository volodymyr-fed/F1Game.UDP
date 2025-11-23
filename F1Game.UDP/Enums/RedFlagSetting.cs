#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the red flag setting options in the F1 game.
/// </summary>
public enum RedFlagSetting : byte
{
	Off = 0,
	Reduced = 1,
	Standard = 2,
	Increased = 3
}
