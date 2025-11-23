#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the rule set options in the F1 game.
/// </summary>
public enum RuleSet : byte
{
	PracticeAndQualifying = 0,
	Race = 1,
	TimeTrial = 2,
	TimeAttack = 4,
	CheckpointChallenge = 6,
	Autocross = 8,
	Drift = 9,
	AverageSpeedZone = 10,
	RivalDuel = 11,
}
