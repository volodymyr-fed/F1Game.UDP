namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct LiveryColor() : IByteParsable<LiveryColor>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 3;

	/// <summary>
	/// The red component of the livery color.
	/// </summary>
	public byte Red { get; init; }
	/// <summary>
	/// The green component of the livery color.
	/// </summary>
	public byte Green { get; init; }
	/// <summary>
	/// The blue component of the livery color.
	/// </summary>
	public byte Blue { get; init; }

	static LiveryColor IByteParsable<LiveryColor>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Red = reader.GetNextByte(),
			Green = reader.GetNextByte(),
			Blue = reader.GetNextByte()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Red);
		writer.Write(Green);
		writer.Write(Blue);
	}
}
