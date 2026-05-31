#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the game modes available in the F1 game.
/// </summary>
public enum GameMode : byte
{
	GrandPrix23 = 4,
	TimeTrial = 5,
	SplitScreen = 6,
	OnlineCustom = 7,
	OnlineWeeklyEvent = 15,
	StoryMode = 17,
	MyTeamCareer25 = 27,
	DriverCareer25 = 28,
	Career25Online = 29,
	ChallengeCareer25 = 30,
	StoryModeApxGp = 75,
	Benchmark = 127,
}
