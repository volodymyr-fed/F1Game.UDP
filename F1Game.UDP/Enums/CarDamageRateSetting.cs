#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the car damage rate settings in the F1 game.
/// </summary>
public enum CarDamageRateSetting : byte
{
	Reduced = 0,
	Standard = 1,
	Simulation = 2
}
