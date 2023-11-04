namespace F1Game.UDP.Enums;

public enum SessionLength : byte
{
	// 0 = None, 2 = Very Short, 3 = Short, 4 = Medium, 5 = Medium Long, 6 = Long, 7 = Full
	None = 0,
	VeryShort = 2,
	Short = 1,
	Medium = 4,
	MediumLong = 5,
	Long = 6,
	Full = 7
}
