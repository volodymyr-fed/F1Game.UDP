namespace F1Game.UDP.Events;

public sealed record StartLights : IEventDetails, IByteParsable<StartLights>
{
	public byte NumLights { get; init; } // Number of lights showing

	static StartLights IByteParsable<StartLights>.Parse(ref BytesReader reader)
	{
		return new()
		{
			NumLights = reader.GetNextByte(),
		};
	}
}
