#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the tyre temperature simulation settings in the F1 game.
/// </summary>
public enum TyreTemperatureSettings : byte
{
	SurfaceOnly = 0,
	SurfaceAndCarcass = 1
}
