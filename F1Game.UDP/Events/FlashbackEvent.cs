namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public readonly record struct FlashbackEvent() : IByteParsable<FlashbackEvent>, IByteWritable
{
	public uint FlashbackFrameIdentifier { get; init; } // Frame identifier flashed back to
	public float FlashbackSessionTime { get; init; } // Session time flashed back to

	static FlashbackEvent IByteParsable<FlashbackEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			FlashbackFrameIdentifier = reader.GetNextUInt(),
			FlashbackSessionTime = reader.GetNextFloat(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(FlashbackFrameIdentifier);
		writer.Write(FlashbackSessionTime);
	}
}
