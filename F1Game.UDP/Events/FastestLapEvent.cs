namespace F1Game.UDP.Events;

// The event details packet is different for each type of event.
// Make sure only the correct type is interpreted.
[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
public readonly record struct FastestLapEvent() : IByteParsable<FastestLapEvent>, IByteWritable
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
		writer.Write(VehicleIdx);
		writer.Write(LapTime);
	}
}
