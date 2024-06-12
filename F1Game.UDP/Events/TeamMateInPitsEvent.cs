namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
public readonly record struct TeamMateInPitsEvent() : IByteParsable<TeamMateInPitsEvent>, IByteWritable
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
		writer.Write(VehicleIdx);
	}
}
