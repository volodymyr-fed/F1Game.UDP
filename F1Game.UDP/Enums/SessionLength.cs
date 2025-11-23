namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the session length options in the F1 game.
/// </summary>
public enum SessionLength : byte
{
	/// <summary>No session length</summary>
	None = 0,
	/// <summary>
    /// Very short session length: 3 laps
    /// </summary>
	VeryShort = 2,
	/// <summary>
    /// Short session length: 5 laps
    /// </summary>
	Short = 1,
	/// <summary>
    /// Medium session length: 25% of race distance
    /// </summary>
	Medium = 4,
	/// <summary>
	/// Medium long session length: 35% of race distance
	/// </summary>
	MediumLong = 5,
	/// <summary>
	/// Long session length: 50% of race distance
	/// </summary>
	Long = 6,
	/// <summary>
	/// Full session length: 100% of race distance
	/// </summary>
	Full = 7
}
