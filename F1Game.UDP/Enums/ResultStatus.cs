namespace F1Game.UDP.Enums;

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
