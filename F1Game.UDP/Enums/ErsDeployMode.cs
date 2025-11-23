#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the ERS deploy mode options in the F1 game.
/// </summary>
public enum ErsDeployMode : byte
{
	None = 0,
	Medium = 1,
	Hotlap = 2,
	Overtake = 3
}
