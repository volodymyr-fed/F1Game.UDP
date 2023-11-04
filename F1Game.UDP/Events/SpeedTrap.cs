namespace F1Game.UDP.Events;

public sealed record SpeedTrap : IEventDetails, IByteParsable<SpeedTrap>
{
	public byte VehicleIdx { get; init; } // Vehicle index of the vehicle triggering speed trap
	public float Speed { get; init; } // Top speed achieved in kilometres per hour
	public bool IsOverallFastestInSession { get; init; } // Overall fastest speed in session = 1, otherwise 0
	public bool IsDriverFastestInSession { get; init; } // Fastest speed for driver in session = 1, otherwise 0
	public byte FastestVehicleIdxInSession { get; init; }// Vehicle index of the vehicle that is the fastest
														 // in this session
	public float FastestSpeedInSession { get; init; } // Speed of the vehicle that is the fastest in this session

	static SpeedTrap IByteParsable<SpeedTrap>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
			Speed = reader.GetNextFloat(),
			IsOverallFastestInSession = reader.GetNextBoolean(),
			IsDriverFastestInSession = reader.GetNextBoolean(),
			FastestVehicleIdxInSession = reader.GetNextByte(),
			FastestSpeedInSession = reader.GetNextFloat(),
		};
	}
}
