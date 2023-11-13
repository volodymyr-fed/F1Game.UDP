namespace F1Game.UDP.Events;

public sealed record StopGoPenaltyServedEvent : IEventDetails, IByteParsable<StopGoPenaltyServedEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of the vehicle serving stop go

	static StopGoPenaltyServedEvent IByteParsable<StopGoPenaltyServedEvent>.Parse(ref BytesReader reader)
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
