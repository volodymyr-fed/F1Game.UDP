using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

public sealed record TyreSetData : IByteParsable<TyreSetData>
{
	public ActualCompound ActualTyreCompound { get; init; } // Actual tyre compound used
	public VisualCompound VisualTyreCompound { get; init; } // Visual tyre compound used
	public byte Wear { get; init; } // Tyre wear (percentage)
	public bool IsAvailable { get; init; } // Whether this set is currently available
	public SessionType RecommendedSession { get; init; } // Recommended session for tyre set
	public byte LifeSpan { get; init; } // Laps left in this tyre set
	public byte UsableLife { get; init; } // Max number of laps recommended for this compound
	public short LapDeltaTime { get; init; } // Lap delta time in milliseconds compared to fitted set
	public bool IsFitted { get; init; } // Whether the set is fitted or not

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
}
