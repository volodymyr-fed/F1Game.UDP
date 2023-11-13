namespace F1Game.UDP.Events;

public sealed record DriveThroughPenaltyServedEvent : IEventDetails, IByteParsable<DriveThroughPenaltyServedEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of the vehicle serving drive through

	static DriveThroughPenaltyServedEvent IByteParsable<DriveThroughPenaltyServedEvent>.Parse(ref BytesReader reader)
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
