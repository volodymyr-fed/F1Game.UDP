namespace F1Game.UDP.Events;

public enum EventType : uint
{
	SessionStarted = 'S' * 0x1U + 'S' * 0x100U + 'T' * 0x10000U + 'A' * 0x1000000U,
	SessionEnded = 'S' * 0x1U + 'E' * 0x100U + 'N' * 0x10000U + 'D' * 0x1000000U,
	FastestLap = 'F' * 0x1U + 'T' * 0x100U + 'L' * 0x10000U + 'P' * 0x1000000U,
	Retirement = 'R' * 0x1U + 'T' * 0x100U + 'M' * 0x10000U + 'T' * 0x1000000U,
	DRSEnabled = 'D' * 0x1U + 'R' * 0x100U + 'S' * 0x10000U + 'E' * 0x1000000U,
	DRSDisabled = 'D' * 0x1U + 'R' * 0x100U + 'S' * 0x10000U + 'D' * 0x1000000U,
	TeamMateInPits = 'T' * 0x1U + 'M' * 0x100U + 'P' * 0x10000U + 'T' * 0x1000000U,
	ChequeredFlag = 'C' * 0x1U + 'H' * 0x100U + 'Q' * 0x10000U + 'F' * 0x1000000U,
	RaceWinner = 'R' * 0x1U + 'C' * 0x100U + 'W' * 0x10000U + 'N' * 0x1000000U,
	PenaltyIssued = 'P' * 0x1U + 'E' * 0x100U + 'N' * 0x10000U + 'A' * 0x1000000U,
	SpeedTrapTriggered = 'S' * 0x1U + 'P' * 0x100U + 'T' * 0x10000U + 'P' * 0x1000000U,
	StartLights = 'S' * 0x1U + 'T' * 0x100U + 'L' * 0x10000U + 'G' * 0x1000000U,
	LightsOut = 'L' * 0x1U + 'G' * 0x100U + 'O' * 0x10000U + 'T' * 0x1000000U,
	DriveThroughServed = 'D' * 0x1U + 'T' * 0x100U + 'S' * 0x10000U + 'V' * 0x1000000U,
	StopGoServed = 'S' * 0x1U + 'G' * 0x100U + 'S' * 0x10000U + 'V' * 0x1000000U,
	Flashback = 'F' * 0x1U + 'L' * 0x100U + 'B' * 0x10000U + 'K' * 0x1000000U,
	ButtonStatus = 'B' * 0x1U + 'U' * 0x100U + 'T' * 0x10000U + 'N' * 0x1000000U,
	RedFlag = 'R' * 0x1U + 'D' * 0x100U + 'F' * 0x10000U + 'L' * 0x1000000U,
	Overtake = 'O' * 0x1U + 'V' * 0x100U + 'T' * 0x10000U + 'K' * 0x1000000U,
}
