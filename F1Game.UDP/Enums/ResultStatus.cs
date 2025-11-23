#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the result status options in the F1 game.
/// </summary>
public enum ResultStatus : byte
{
	Invalid = 0,
	Inactive = 1,
	Active = 2,
	Finished = 3,
	DidNotFinish = 4,
	Disqualified = 5,
	NotClassified = 6,
	Retired = 7
}
