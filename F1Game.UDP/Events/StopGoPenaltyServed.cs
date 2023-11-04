namespace F1Game.UDP.Events;

public sealed record StopGoPenaltyServed : IEventDetails, IByteParsable<StopGoPenaltyServed>
{
	public byte VehicleIdx { get; init; } // Vehicle index of the vehicle serving stop go

	static StopGoPenaltyServed IByteParsable<StopGoPenaltyServed>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}
}
