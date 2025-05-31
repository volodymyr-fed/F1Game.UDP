namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct FlashbackEvent() : IByteParsable<FlashbackEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 8;

	/// <summary>
	/// Frame identifier flashed back to
	/// </summary>
	public uint FlashbackFrameIdentifier { get; init; }
	/// <summary>
	/// Session time flashed back to
	/// </summary>
	public float FlashbackSessionTime { get; init; }

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
