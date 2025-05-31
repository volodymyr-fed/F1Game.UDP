namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct FastestLapEvent() : IByteParsable<FastestLapEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 5;

	/// <summary>
	/// Vehicle index of car achieving fastest lap
	/// </summary>
	public byte VehicleIdx { get; init; }
	/// <summary>
	/// Lap time is in seconds
	/// </summary>
	public float LapTime { get; init; }

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
