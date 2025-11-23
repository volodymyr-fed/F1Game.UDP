#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the flashback limit options in the F1 game.
/// </summary>
public enum FlashbackLimit : byte
{
	Low = 0,
	Medium = 1,
	High = 2,
	Unlimited = 3,
}
