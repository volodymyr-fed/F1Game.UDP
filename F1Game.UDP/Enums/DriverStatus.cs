#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the driver status in the F1 game.
/// </summary>
public enum DriverStatus : byte
{
	InGarage = 0,
	FlyingLap = 1,
	InLap = 2,
	OutLap = 3,
	OnTrack = 4
}
