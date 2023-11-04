namespace F1Game.UDP.Enums;

public enum DriverStatus : byte
{
	// Status of driver - 0 = in garage, 1 = flying lap
	// 2 = in lap, 3 = out lap, 4 = on track
	InGarage = 0,
	FlyingLap = 1,
	InLap = 2,
	OutLap = 3,
	OnTrack = 4
}
