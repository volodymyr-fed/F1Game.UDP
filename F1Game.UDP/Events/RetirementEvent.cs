namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
public readonly record struct RetirementEvent() : IByteParsable<RetirementEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of car retiring

	static RetirementEvent IByteParsable<RetirementEvent>.Parse(ref BytesReader reader)
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
