using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct TyreSetData() : IByteParsable<TyreSetData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 10;

	/// <summary>
	/// Gets the actual tyre compound used.
	/// </summary>
	public ActualCompound ActualTyreCompound { get; init; }
	/// <summary>
	/// Gets the visual tyre compound used.
	/// </summary>
	public VisualCompound VisualTyreCompound { get; init; }
	/// <summary>
	/// Gets the tyre wear as a percentage.
	/// </summary>
	public byte Wear { get; init; }
	/// <summary>
	/// Gets a value indicating whether this set is currently available.
	/// </summary>
	public bool IsAvailable { get; init; }
	/// <summary>
	/// Gets the recommended session for this tyre set.
	/// </summary>
	public SessionType RecommendedSession { get; init; }
	/// <summary>
	/// Gets the number of laps left in this tyre set.
	/// </summary>
	public byte LifeSpan { get; init; }
	/// <summary>
	/// Gets the maximum number of laps recommended for this compound.
	/// </summary>
	public byte UsableLife { get; init; }
	/// <summary>
	/// Gets the lap delta time in milliseconds compared to the fitted set.
	/// </summary>
	public short LapDeltaTime { get; init; }
	/// <summary>
	/// Gets a value indicating whether the set is fitted or not.
	/// </summary>
	public bool IsFitted { get; init; }

	static TyreSetData IByteParsable<TyreSetData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ActualTyreCompound = reader.GetNextEnum<ActualCompound>(),
			VisualTyreCompound = reader.GetNextEnum<VisualCompound>(),
			Wear = reader.GetNextByte(),
			IsAvailable = reader.GetNextBoolean(),
			RecommendedSession = reader.GetNextEnum<SessionType>(),
			LifeSpan = reader.GetNextByte(),
			UsableLife = reader.GetNextByte(),
			LapDeltaTime = reader.GetNextShort(),
			IsFitted = reader.GetNextBoolean(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(ActualTyreCompound);
		writer.WriteEnum(VisualTyreCompound);
		writer.Write(Wear);
		writer.Write(IsAvailable);
		writer.WriteEnum(RecommendedSession);
		writer.Write(LifeSpan);
		writer.Write(UsableLife);
		writer.Write(LapDeltaTime);
		writer.Write(IsFitted);
	}
}
