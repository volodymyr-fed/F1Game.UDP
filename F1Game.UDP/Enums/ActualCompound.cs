namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the actual tyre compound used in the game.
/// </summary>
public enum ActualCompound : byte
{
	/// <summary>
	/// F1 compound C6 (softest dry compound).
	/// </summary>
	F1C6 = 22,
	/// <summary>
	/// F1 compound C5.
	/// </summary>
	F1C5 = 16,
	/// <summary>
	/// F1 compound C4.
	/// </summary>
	F1C4 = 17,
	/// <summary>
	/// F1 compound C3.
	/// </summary>
	F1C3 = 18,
	/// <summary>
	/// F1 compound C2.
	/// </summary>
	F1C2 = 19,
	/// <summary>
	/// F1 compound C1.
	/// </summary>
	F1C1 = 20,
	/// <summary>
	/// F1 compound C0 (hardest dry compound).
	/// </summary>
	F1C0 = 21,
	/// <summary>
	/// F1 intermediate (wet weather) tyres.
	/// </summary>
	F1Inter = 7,
	/// <summary>
	/// F1 wet (full wet weather) tyres.
	/// </summary>
	F1Wet = 8,
	/// <summary>
	/// F1 classic dry tyres.
	/// </summary>
	F1ClassicDry = 9,
	/// <summary>
	/// F1 classic wet tyres.
	/// </summary>
	F1ClassicWet = 10,
	/// <summary>
	/// F2 super soft tyres.
	/// </summary>
	F2SuperSoft = 11,
	/// <summary>
	/// F2 soft tyres.
	/// </summary>
	F2Soft = 12,
	/// <summary>
	/// F2 medium tyres.
	/// </summary>
	F2Medium = 13,
	/// <summary>
	/// F2 hard tyres.
	/// </summary>
	F2Hard = 14,
	/// <summary>
	/// F2 wet tyres.
	/// </summary>
	F2Wet = 15,
}
