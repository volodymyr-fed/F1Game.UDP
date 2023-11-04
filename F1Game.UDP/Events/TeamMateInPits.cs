namespace F1Game.UDP.Events;

public sealed record TeamMateInPits : IEventDetails, IByteParsable<TeamMateInPits>
{
	public byte VehicleIdx { get; init; } // Vehicle index of team mate

	static TeamMateInPits IByteParsable<TeamMateInPits>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}
}
