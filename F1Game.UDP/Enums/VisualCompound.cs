namespace F1Game.UDP.Enums;

public enum VisualCompound : byte
{
	// F1 visual (can be different from actual compound)
	// 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
	// F1 Classic – same as above
	// F2 ‘19, 15 = wet, 19 – super soft, 20 = soft
	// 21 = medium , 22 = hard
	F1Soft = 16,
	F1Medium = 17,
	F1Hard = 18,
	F1Inter = 7,
	F1Wet = 8,
	F1ClassicDry = 9,
	F1ClassicWet = 10,
	F2Wet = 15,
	F2SuperSoft = 19,
	F2Soft = 20,
	F2Medium = 21,
	F2Hard = 22
}
