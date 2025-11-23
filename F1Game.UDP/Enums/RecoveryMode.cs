#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the recovery mode options in the F1 game.
/// </summary>
public enum RecoveryMode : byte
{
	None = 0,
	Flashbacks = 1,
	AutoRecovery = 2,
}
