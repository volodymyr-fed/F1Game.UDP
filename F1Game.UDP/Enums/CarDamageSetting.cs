#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the car damage settings in the F1 game.
/// </summary>
public enum CarDamageSetting : byte
{
	Off = 0,
	Reduced = 1,
	Standard = 2,
	Simulation = 3
}
