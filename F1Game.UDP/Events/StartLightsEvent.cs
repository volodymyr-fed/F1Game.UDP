namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct StartLightsEvent() : IByteParsable<StartLightsEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	/// <summary>
	/// Number of lights showing
	/// </summary>
	public byte NumLights { get; init; }

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
