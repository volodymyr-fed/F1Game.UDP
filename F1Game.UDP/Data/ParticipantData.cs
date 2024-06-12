using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 58)]
public readonly record struct ParticipantData() : IByteParsable<ParticipantData>, IByteWritable
{
	public bool IsAiControlled { get; init; } // Whether the vehicle is AI (1) or Human (0) controlled
	public Driver Driver { get; init; } // Driver id - see appendix, ifnetworkhuman = 255,
	public byte NetworkId { get; init; } // Network id – unique identifier for network players
	public Team Team { get; init; } // Team id - see appendix
	public bool IsMyTeam { get; init; } // My team flag – 1 = My Team, 0 = otherwise
	public byte RaceNumber { get; init; } // Race number of the car
	public Nationality Nationality { get; init; } // Nationality of the driver
	public Array48<byte> NameBytes { get; init; }
	// Name of participant in UTF-8 format – null terminated Will be truncated with ... (U+2026) if too long; 48 chars
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsArray48Bytes(); }
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
			NameBytes = reader.GetNextArray48Bytes(),
			TelemetryIsNotRestricted = reader.GetNextBoolean(),
			ShowOnlineNames = reader.GetNextBoolean(),
			Platform = reader.GetNextEnum<Platform>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(IsAiControlled);
		writer.WriteEnum(Driver);
		writer.Write(NetworkId);
		writer.WriteEnum(Team);
		writer.Write(IsMyTeam);
		writer.Write(RaceNumber);
		writer.WriteEnum(Nationality);
		writer.Write(Name, 48);
		writer.Write(TelemetryIsNotRestricted);
		writer.Write(ShowOnlineNames);
		writer.WriteEnum(Platform);
	}
}
