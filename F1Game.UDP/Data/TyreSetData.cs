using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 10)]
public readonly record struct TyreSetData() : IByteParsable<TyreSetData>, IByteWritable
{
	public ActualCompound ActualTyreCompound { get; init; } // Actual tyre compound used
	public VisualCompound VisualTyreCompound { get; init; } // Visual tyre compound used
	public byte Wear { get; init; } // Tyre wear (percentage)
	private byte IsAvailableByte { get; init; } // Whether this set is currently available
	public bool IsAvailable { get => IsAvailableByte.AsBool(); init => IsAvailableByte = value.AsByte(); }
	public SessionType RecommendedSession { get; init; } // Recommended session for tyre set
	public byte LifeSpan { get; init; } // Laps left in this tyre set
	public byte UsableLife { get; init; } // Max number of laps recommended for this compound
	public short LapDeltaTime { get; init; } // Lap delta time in milliseconds compared to fitted set
	private byte IsFittedByte { get; init; } // Whether the set is fitted or not
	public bool IsFitted { get => IsFittedByte.AsBool(); init => IsFittedByte = value.AsByte(); }

	static TyreSetData IByteParsable<TyreSetData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ActualTyreCompound = reader.GetNextEnum<ActualCompound>(),
			VisualTyreCompound = reader.GetNextEnum<VisualCompound>(),
			Wear = reader.GetNextByte(),
			IsAvailableByte = reader.GetNextByte(),
			RecommendedSession = reader.GetNextEnum<SessionType>(),
			LifeSpan = reader.GetNextByte(),
			UsableLife = reader.GetNextByte(),
			LapDeltaTime = reader.GetNextShort(),
			IsFittedByte = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(ActualTyreCompound);
		writer.WriteEnum(VisualTyreCompound);
		writer.Write(Wear);
		writer.Write(IsAvailableByte);
		writer.WriteEnum(RecommendedSession);
		writer.Write(LifeSpan);
		writer.Write(UsableLife);
		writer.Write(LapDeltaTime);
		writer.Write(IsFittedByte);
	}
}
