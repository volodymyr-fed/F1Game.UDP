namespace F1Game.UDP.Events;

// The event details packet is different for each type of event.
// Make sure only the correct type is interpreted.
public sealed record FastestLapEvent : IEventDetails, IByteParsable<FastestLapEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of car achieving fastest lap
	public float LapTime { get; init; } // Lap time is in seconds

	static FastestLapEvent IByteParsable<FastestLapEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
			LapTime = reader.GetNextFloat()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteByte(VehicleIdx);
		writer.WriteFloat(LapTime);
	}
}
