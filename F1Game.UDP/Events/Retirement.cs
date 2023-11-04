namespace F1Game.UDP.Events;

public sealed record Retirement : IEventDetails, IByteParsable<Retirement>
{
	public byte VehicleIdx { get; init; } // Vehicle index of car retiring

	static Retirement IByteParsable<Retirement>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}
}
