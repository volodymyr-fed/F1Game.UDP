#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the pit status of a car in the F1 game.
/// </summary>
public enum PitStatus : byte
{
	None = 0,
	Pitting = 1,
	InPitArea = 2
}
