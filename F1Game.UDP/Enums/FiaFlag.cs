#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the FIA flag status in the F1 game.
/// </summary>
public enum FiaFlag : sbyte
{
	Unknown = -1,
	None = 0,
	Green = 1,
	Blue = 2,
	Yellow = 3,
}
