#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the reasons why DRS is disabled in the F1 game.
/// </summary>
public enum DrsDisabledReason : byte
{
	WetTrack =0,
	SafetyCarDeployed = 1,
	RedFlag = 2,
	MinLapNotReached = 3,
}
