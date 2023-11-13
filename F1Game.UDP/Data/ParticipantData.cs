using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

public sealed record ParticipantData : IByteParsable<ParticipantData>, IByteWritable
{
	public bool IsAiControlled { get; init; } // Whether the vehicle is AI (1) or Human (0) controlled
	public Driver Driver { get; init; } // Driver id - see appendix, ifnetworkhuman = 255,
	public byte NetworkId { get; init; } // Network id – unique identifier for network players
	public Team Team { get; init; } // Team id - see appendix
	public bool IsMyTeam { get; init; } // My team flag – 1 = My Team, 0 = otherwise
	public byte RaceNumber { get; init; } // Race number of the car
	public Nationality Nationality { get; init; } // Nationality of the driver
	public string Name { get; init; } = string.Empty; // Name of participant in UTF-8 format – null terminated Will be truncated with ... (U+2026) if too long; 48 chars
	public bool TelemetryIsNotRestricted { get; init; } // The player's UDP setting, 0 = restricted, 1 = public
	public bool ShowOnlineNames { get; init; } // The player's show online names setting, 0 = off, 1 = o
	public Platform Platform { get; init; }

	static ParticipantData IByteParsable<ParticipantData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			IsAiControlled = reader.GetNextBoolean(),
			Driver = reader.GetNextEnum<Driver>(),
			NetworkId = reader.GetNextByte(),
			Team = reader.GetNextEnum<Team>(),
			IsMyTeam = reader.GetNextBoolean(),
			RaceNumber = reader.GetNextByte(),
			Nationality = reader.GetNextEnum<Nationality>(),
			Name = reader.GetNextString(48),
			TelemetryIsNotRestricted = reader.GetNextBoolean(),
			ShowOnlineNames = reader.GetNextBoolean(),
			Platform = reader.GetNextEnum<Platform>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteBoolean(IsAiControlled);
		writer.WriteEnum(Driver);
		writer.WriteByte(NetworkId);
		writer.WriteEnum(Team);
		writer.WriteBoolean(IsMyTeam);
		writer.WriteByte(RaceNumber);
		writer.WriteEnum(Nationality);
		writer.WriteString(Name, 48);
		writer.WriteBoolean(TelemetryIsNotRestricted);
		writer.WriteBoolean(ShowOnlineNames);
		writer.WriteEnum(Platform);
	}
}
