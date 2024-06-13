namespace F1Game.UDP.Enums;

public enum PenaltyType : byte
{
	DriveThrough = 0,
	StopGo = 1,
	GridPenalty = 2,
	PenaltyReminder = 3,
	TimePenalty = 4,
	Warning = 5,
	Disqualified = 6,
	RemovedFromFormationLap = 7,
	ParkedTooLongTimer = 8,
	TyreRegulations = 9,
	ThisLapInvalidated = 10,
	ThisAndNextLapInvalidated = 11,
	ThisLapInvalidatedWithoutReason = 12,
	ThisAndNextLapInvalidatedWithoutReason = 13,
	ThisAndPreviousLapInvalidated = 14,
	ThisAndPreviousLapInvalidatedWithoutReason = 15,
	Retired = 16,
	BlackFlagTimer = 17,
}
