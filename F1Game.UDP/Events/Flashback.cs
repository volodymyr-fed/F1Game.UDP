namespace F1Game.UDP.Events;

public sealed record Flashback : IEventDetails, IByteParsable<Flashback>
{
	public uint FlashbackFrameIdentifier { get; init; } // Frame identifier flashed back to
	public float FlashbackSessionTime { get; init; } // Session time flashed back to

	static Flashback IByteParsable<Flashback>.Parse(ref BytesReader reader)
	{
		return new()
		{
			FlashbackFrameIdentifier = reader.GetNextUInt(),
			FlashbackSessionTime = reader.GetNextFloat(),
		};
	}
}
