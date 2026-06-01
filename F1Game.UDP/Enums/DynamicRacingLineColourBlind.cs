#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the colour-blind modes for the dynamic racing line assist.
/// </summary>
public enum DynamicRacingLineColourBlind : byte
{
	Off = 0,
	Protanopia = 1,
	Deuteranopia = 2,
	Tritanopia = 3
}
