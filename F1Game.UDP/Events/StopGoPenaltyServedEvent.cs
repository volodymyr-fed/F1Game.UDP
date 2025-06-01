namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct StopGoPenaltyServedEvent() : IByteParsable<StopGoPenaltyServedEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 5;

	/// <summary>
	/// Vehicle index of the vehicle serving stop go
	/// </summary>
	public byte VehicleIdx { get; init; }
	/// <summary>
	/// Time spent serving stop go in seconds
	/// </summary>
	public float StopTime { get; init; }

	static StopGoPenaltyServedEvent IByteParsable<StopGoPenaltyServedEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
			StopTime = reader.GetNextFloat()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(VehicleIdx);
		writer.Write(StopTime);
	}
}
