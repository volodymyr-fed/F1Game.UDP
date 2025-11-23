#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the gearbox assist options in the F1 game.
/// </summary>
public enum GearboxAssist : byte
{
	Manual = 1,
	ManualWithSuggestedGears = 2,
	Auto = 3
}
