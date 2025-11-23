#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the ready status options in the F1 game.
/// </summary>
public enum ReadyStatus : byte
{
	NotReady = 0,
	Ready = 1,
	Spectating = 2
}
