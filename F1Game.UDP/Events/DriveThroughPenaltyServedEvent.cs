namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct DriveThroughPenaltyServedEvent() : IByteParsable<DriveThroughPenaltyServedEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	/// <summary>
	/// Vehicle index of the vehicle serving drive through
	/// </summary>
	public byte VehicleIdx { get; init; }

	static DriveThroughPenaltyServedEvent IByteParsable<DriveThroughPenaltyServedEvent>.Parse(ref BytesReader reader)
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
