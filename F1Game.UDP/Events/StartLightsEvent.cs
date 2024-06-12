namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
public readonly record struct StartLightsEvent() : IByteParsable<StartLightsEvent>, IByteWritable
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
		writer.Write(NumLights);
	}
}
