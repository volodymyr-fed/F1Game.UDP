namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CollisionEvent() : IByteParsable<CollisionEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 2;

	/// <summary>
	/// Vehicle index of the first vehicle involved in the collision
	/// </summary>
	public byte Vehicle1Index { get; init; }
	/// <summary>
	/// Vehicle index of the second vehicle involved in the collision
	/// </summary>
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
