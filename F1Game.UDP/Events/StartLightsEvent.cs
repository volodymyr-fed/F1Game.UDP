namespace F1Game.UDP.Events;

public sealed record StartLightsEvent : IEventDetails, IByteParsable<StartLightsEvent>, IByteWritable
{
	public byte NumLights { get; init; } // Number of lights showing

	static StartLightsEvent IByteParsable<StartLightsEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			NumLights = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteByte(NumLights);
	}
}
