#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the MFD (Multi-Function Display) panel options in the F1 game.
/// May vary depending on game mode
/// </summary>
public enum MfdPanel : byte
{
	Closed = 255,
	CarSetup = 0,
	Pits = 1,
	Damage = 2,
	Engine = 3,
	Temperatures = 4
}
