namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct TeamMateInPitsEvent() : IByteParsable<TeamMateInPitsEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	/// <summary>
	/// Vehicle index of team mate
	/// </summary>
	public byte VehicleIdx { get; init; }

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
