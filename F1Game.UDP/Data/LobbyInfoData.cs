using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

public readonly record struct LobbyInfoData() : IByteParsable<LobbyInfoData>, IByteWritable
{
	public bool IsAiControlled { get; init; } // Whether the vehicle is AI (1) or Human (0) controlled
	public Team Team { get; init; } // Team id - see appendix (255 if no team currently selected)
	public Nationality Nationality { get; init; } // Nationality of the driver
	public Platform Platform { get; init; }
	public Array48<byte> NameBytes { get; init; }
	// Name of participant in UTF-8 format – null terminated Will be truncated with ... (U+2026) if too long; 48 chars
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsArray48Bytes(); }
	public byte CarNumber { get; init; } // Car number of the player
	public ReadyStatus ReadyStatus { get; init; } // 0 = not ready, 1 = ready, 2 = spectating

	static LobbyInfoData IByteParsable<LobbyInfoData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			IsAiControlled = reader.GetNextBoolean(),
			Team = reader.GetNextEnum<Team>(),
			Nationality = reader.GetNextEnum<Nationality>(),
			Platform = reader.GetNextEnum<Platform>(),
			NameBytes = reader.GetNextArray48Bytes(),
			CarNumber = reader.GetNextByte(),
			ReadyStatus = reader.GetNextEnum<ReadyStatus>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(IsAiControlled);
		writer.WriteEnum(Team);
		writer.WriteEnum(Nationality);
		writer.WriteEnum(Platform);
		writer.Write(Name, 48);
		writer.Write(CarNumber);
		writer.WriteEnum(ReadyStatus);
	}
}
