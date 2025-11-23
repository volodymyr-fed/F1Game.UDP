#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the weather conditions in the F1 game.
/// </summary>
public enum Weather : byte
{
	Clear = 0,
	LightCloud = 1,
	Overcast = 2,
	LightRain = 3,
	HeavyRain = 4,
	Storm = 5
}
