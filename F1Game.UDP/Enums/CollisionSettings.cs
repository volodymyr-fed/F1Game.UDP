#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the collision settings in the F1 game.
/// </summary>
public enum CollisionSettings : byte
{
	Off = 0,
	PlayerToPlayerOff = 1,
	On = 2
}
