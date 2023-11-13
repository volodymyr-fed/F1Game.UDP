namespace F1Game.UDP.Events;

public sealed record RaceWinnerEvent : IEventDetails, IByteParsable<RaceWinnerEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of the race winner

	static RaceWinnerEvent IByteParsable<RaceWinnerEvent>.Parse(ref BytesReader reader)
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
