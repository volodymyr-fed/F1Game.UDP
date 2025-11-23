#pragma warning disable 1591

namespace F1Game.UDP.Enums;

/// <summary>
/// Represents the different types of packets in the F1 game UDP telemetry data.
/// </summary>
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
	MotionEx = 13,
	TimeTrial = 14,
	LapPositions = 15,
}
