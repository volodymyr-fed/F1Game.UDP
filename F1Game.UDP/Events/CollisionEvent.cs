namespace F1Game.UDP.Events;

/// <summary>
/// Represents a collision event in the F1 game.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CollisionEvent() : IByteParsable<CollisionEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 3;

	/// <summary>
	/// Vehicle index of the first vehicle involved in the collision
	/// </summary>
	public byte Vehicle1Index { get; init; }
	/// <summary>
	/// Vehicle index of the second vehicle involved in the collision
	/// </summary>
	public byte Vehicle2Index { get; init; }
	/// <summary>
	/// Severity of the collision. 0 = low, 1 = medium, 2 = high.
	/// </summary>
	public byte Severity { get; init; }

	static CollisionEvent IByteParsable<CollisionEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Vehicle1Index = reader.GetNextByte(),
			Vehicle2Index = reader.GetNextByte(),
			Severity = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Vehicle1Index);
		writer.Write(Vehicle2Index);
		writer.Write(Severity);
	}
}
