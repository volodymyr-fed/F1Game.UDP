using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct MarshalZone() : IByteParsable<MarshalZone>, IByteWritable, ISizeable
{
	/// <inheritdoc/>
	static int ISizeable.Size => 5;

	/// <summary>
	/// Fraction (0..1) of way through the lap the marshal zone starts.
	/// </summary>
	public float ZoneStart { get; init; }
	/// <summary>
	/// The flag status of the marshal zone.
	/// </summary>
	public FiaFlag ZoneFlag { get; init; }

	static MarshalZone IByteParsable<MarshalZone>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ZoneStart = reader.GetNextFloat(),
			ZoneFlag = reader.GetNextEnum<FiaFlag>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(ZoneStart);
		writer.WriteEnum(ZoneFlag);
	}
}
