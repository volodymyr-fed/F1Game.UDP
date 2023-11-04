namespace F1Game.UDP.Enums;

public enum PacketType : byte
{
	Motion = 0,
	Session = 1,
	LapData = 2,
	Event = 3,
	Participants = 4,
	CarSetups = 5,
	CarTelemetry = 6,
	CarStatus = 7,
	FinalClassification = 8,
	LobbyInfo = 9,
	CarDamage = 10,
	SessionHistory = 11,
	TyreSets = 12,
	MotionEx = 13
}
