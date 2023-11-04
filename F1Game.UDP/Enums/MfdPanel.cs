namespace F1Game.UDP.Enums;

public enum MfdPanel : byte
{
	// Index of MFD panel open - 255 = MFD closed
	// Single player, race – 0 = Car setup, 1 = Pits
	// 2 = Damage, 3 = Engine, 4 = Temperatures
	// May vary depending on game mode
	CarSetup = 0,
	Pits = 1,
	Damage = 2,
	Engine = 3,
	Temperatures = 4
}
