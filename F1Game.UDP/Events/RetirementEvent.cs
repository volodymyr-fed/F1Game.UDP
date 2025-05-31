namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct RetirementEvent() : IByteParsable<RetirementEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	/// <summary>
	/// Vehicle index of car retiring
	/// </summary>
	public byte VehicleIdx { get; init; }

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
