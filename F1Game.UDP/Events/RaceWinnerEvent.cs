namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
public readonly record struct RaceWinnerEvent() : IByteParsable<RaceWinnerEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of the race winner

	static RaceWinnerEvent IByteParsable<RaceWinnerEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(VehicleIdx);
	}
}
