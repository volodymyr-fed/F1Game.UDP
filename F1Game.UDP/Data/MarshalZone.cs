using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
public readonly record struct MarshalZone() : IByteParsable<MarshalZone>, IByteWritable
{
	public float ZoneStart { get; init; } // Fraction (0..1) of way through the lap the marshal zone starts
	public FiaFlag ZoneFlag { get; init; } // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow

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
