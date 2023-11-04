namespace F1Game.UDP.Enums;

public enum ResultStatus : byte
{
	// Result status - 0 = invalid, 1 = inactive, 2 = active
	// 3 = finished, 4 = didnotfinish, 5 = disqualified
	// 6 = not classified, 7 = retired
	Invalid = 0,
	Inactive = 1,
	Active = 2,
	Finished = 3,
	DidNotFinish = 4,
	Disqualified = 5,
	NotClassified = 6,
	Retired = 7
}
