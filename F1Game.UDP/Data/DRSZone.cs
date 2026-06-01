namespace F1Game.UDP.Data;

/// <summary>
/// Represents a DRS zone on the track.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct DRSZone() : IByteParsable<DRSZone>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 8;

	/// <summary>
	/// Fraction of the lap where the zone starts.
	/// </summary>
	public float ZoneStart { get; init; }
	/// <summary>
	/// Fraction of the lap where the zone ends.
	/// </summary>
	public float ZoneEnd { get; init; }

	static DRSZone IByteParsable<DRSZone>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ZoneStart = reader.GetNextFloat(),
			ZoneEnd = reader.GetNextFloat(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(ZoneStart);
		writer.Write(ZoneEnd);
	}
}