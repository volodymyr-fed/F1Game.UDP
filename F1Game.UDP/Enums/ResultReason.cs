#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the reason for a race result.
/// </summary>
public enum ResultReason : byte
{
	Invalid = 0,
	Retired = 1,
	Finished = 2,
	TerminalDamage = 3,
	Inactive = 4,
	NotEnoughLapsCompleted = 5,
	BlackFlagged = 6,
	RedFlagged = 7,
	MechanicalFailure = 8,
	SessionSkipped = 9,
	SessionSimulated = 10,
}
