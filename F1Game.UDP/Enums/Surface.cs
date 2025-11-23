#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// These types are from physics data and show what type of contact each wheel is experiencing.
/// </summary>
public enum Surface : byte
{
	Tarmac = 0,
	RumbleStrip = 1,
	Concrete = 2,
	Rock = 3,
	Gravel = 4,
	Mud = 5,
	Sand = 6,
	Grass = 7,
	Water = 8,
	Cobblestone = 9,
	Metal = 10,
	Ridged = 11,
}
