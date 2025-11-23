#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the type of safety car in the F1 game.
/// </summary>
public enum SafetyCarType : byte
{
	NoSafetyCar = 0,
	FullSafetyCar = 1,
	VirtualSafetyCar = 2,
	FormationLap = 3
}
