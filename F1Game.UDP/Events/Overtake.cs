namespace F1Game.UDP.Events;

public sealed record Overtake : IEventDetails, IByteParsable<Overtake>
{
	public byte OvertakingVehicleIdx { get; init; } // Vehicle index of the vehicle overtaking
	public byte BeingOvertakenVehicleIdx { get; init; }  // Vehicle index of the vehicle being overtaken

	static Overtake IByteParsable<Overtake>.Parse(ref BytesReader reader)
	{
		return new()
		{
			OvertakingVehicleIdx = reader.GetNextByte(),
			BeingOvertakenVehicleIdx = reader.GetNextByte(),
		};
	}
}
