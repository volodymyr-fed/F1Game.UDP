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
	Elimination = 12,
}
