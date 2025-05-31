namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct RaceWinnerEvent() : IByteParsable<RaceWinnerEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	/// <summary>
	/// Vehicle index of the race winner
	/// </summary>
	public byte VehicleIdx { get; init; }

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
