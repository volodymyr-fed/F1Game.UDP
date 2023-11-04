namespace F1Game.UDP.Events;

public sealed record RaceWinner : IEventDetails, IByteParsable<RaceWinner>
{
	public byte VehicleIdx { get; init; } // Vehicle index of the race winner

	static RaceWinner IByteParsable<RaceWinner>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}
}
