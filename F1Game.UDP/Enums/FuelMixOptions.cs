#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the fuel mix options in the F1 game.
/// </summary>
public enum FuelMixOptions : byte
{
	Lean = 0,
	Standard = 1,
	Rich = 2,
	Max = 3
}
