namespace F1Game.UDP.Events;

public sealed record DriveThroughPenaltyServed : IEventDetails, IByteParsable<DriveThroughPenaltyServed>
{
	public byte VehicleIdx { get; init; } // Vehicle index of the vehicle serving drive through

	static DriveThroughPenaltyServed IByteParsable<DriveThroughPenaltyServed>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}
}
