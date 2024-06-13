namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
public readonly record struct CollisionEvent() : IByteParsable<CollisionEvent>, IByteWritable
{
	public byte Vehicle1Index { get; init; }
	public byte Vehicle2Index { get; init; }

	static CollisionEvent IByteParsable<CollisionEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Vehicle1Index = reader.GetNextByte(),
			Vehicle2Index = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Vehicle1Index);
		writer.Write(Vehicle2Index);
	}
}
