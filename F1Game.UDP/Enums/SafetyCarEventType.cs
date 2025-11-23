#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the type of safety car event in the F1 game.
/// </summary>
public enum SafetyCarEventType : byte
{
	Deployed = 0,
	Returning = 1,
	Returned = 2,
	ResumeRace = 3
}
