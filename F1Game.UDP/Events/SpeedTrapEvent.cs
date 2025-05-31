namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct SpeedTrapEvent() : IByteParsable<SpeedTrapEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 12;

	/// <summary>
	/// Vehicle index of the vehicle triggering speed trap
	/// </summary>
	public byte VehicleIdx { get; init; }
	/// <summary>
	/// Top speed achieved in kilometres per hour
	/// </summary>
	public float Speed { get; init; }
	/// <summary>
	/// Is overall fastest speed in session
	/// </summary>
	public bool IsOverallFastestInSession { get; init; }
	/// <summary>
	/// Is fastest speed for driver in session
	/// </summary>
	public bool IsDriverFastestInSession { get; init; }
	/// <summary>
	/// Vehicle index of the vehicle that is the fastest in this session
	/// </summary>
	public byte FastestVehicleIdxInSession { get; init; }
	/// <summary>
	/// Speed of the vehicle that is the fastest in this session
	/// </summary>
	public float FastestSpeedInSession { get; init; }

	static SpeedTrapEvent IByteParsable<SpeedTrapEvent>.Parse(ref BytesReader reader)
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

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(VehicleIdx);
		writer.Write(Speed);
		writer.Write(IsOverallFastestInSession);
		writer.Write(IsDriverFastestInSession);
		writer.Write(FastestVehicleIdxInSession);
		writer.Write(FastestSpeedInSession);
	}
}
