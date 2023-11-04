namespace F1Game.UDP.Enums;

public enum ActualCompound : byte
{
	// F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
	// 7 = inter, 8 = wet
	// F1 Classic - 9 = dry, 10 = wet
	// F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
	// 15 = wet
	F1C5 = 16,
	F1C4 = 17,
	F1C3 = 18,
	F1C2 = 19,
	F1C1 = 20,
	F1C0 = 21,
	F1Inter = 7,
	F1Wet = 8,
	F1ClassicDry = 9,
	F1ClassicWet = 10,
	F2SuperSoft = 11,
	F2Soft = 12,
	F2Medium = 13,
	F2Hard = 14,
	F2Wet = 15,
}
