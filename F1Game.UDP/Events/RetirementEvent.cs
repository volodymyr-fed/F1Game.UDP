namespace F1Game.UDP.Events;

public readonly record struct RetirementEvent() : IEventDetails, IByteParsable<RetirementEvent>, IByteWritable
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
		writer.WriteByte(VehicleIdx);
	}
}
