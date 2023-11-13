using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

public sealed record LobbyInfoData : IByteParsable<LobbyInfoData>, IByteWritable
{
	public bool IsAiControlled { get; init; } // Whether the vehicle is AI (1) or Human (0) controlled
	public Team Team { get; init; } // Team id - see appendix (255 if no team currently selected)
	public Nationality Nationality { get; init; } // Nationality of the driver
	public Platform Platform { get; init; }
	public string Name { get; init; } = string.Empty;
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
			Name = reader.GetNextString(48),
			CarNumber = reader.GetNextByte(),
			ReadyStatus = reader.GetNextEnum<ReadyStatus>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteBoolean(IsAiControlled);
		writer.WriteEnum(Team);
		writer.WriteEnum(Nationality);
		writer.WriteEnum(Platform);
		writer.WriteString(Name, 48);
		writer.WriteByte(CarNumber);
		writer.WriteEnum(ReadyStatus);
	}
}
