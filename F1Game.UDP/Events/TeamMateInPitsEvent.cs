namespace F1Game.UDP.Events;

public readonly record struct TeamMateInPitsEvent() : IEventDetails, IByteParsable<TeamMateInPitsEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of team mate

	static TeamMateInPitsEvent IByteParsable<TeamMateInPitsEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteByte(VehicleIdx);
	}
}
