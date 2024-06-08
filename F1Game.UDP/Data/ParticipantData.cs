using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 58)]
public readonly record struct ParticipantData() : IByteParsable<ParticipantData>, IByteWritable
{
	private byte IsAiControlledByte { get; init; } // Whether the vehicle is AI (1) or Human (0) controlled
	public bool IsAiControlled { get => IsAiControlledByte.AsBool(); init => IsAiControlledByte = value.AsByte(); }
	public Driver Driver { get; init; } // Driver id - see appendix, ifnetworkhuman = 255,
	public byte NetworkId { get; init; } // Network id – unique identifier for network players
	public Team Team { get; init; } // Team id - see appendix
	private byte IsMyTeamByte { get; init; } // My team flag – 1 = My Team, 0 = otherwise
	public bool IsMyTeam { get => IsMyTeamByte.AsBool(); init => IsMyTeamByte = value.AsByte(); }
	public byte RaceNumber { get; init; } // Race number of the car
	public Nationality Nationality { get; init; } // Nationality of the driver
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] NameBytes { get; init; }
	// Name of participant in UTF-8 format – null terminated Will be truncated with ... (U+2026) if too long; 48 chars
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsBytes(); }
	private byte TelemetryIsNotRestrictedByte { get; init; } // The player's UDP setting, 0 = restricted, 1 = public
	public bool TelemetryIsNotRestricted { get => TelemetryIsNotRestrictedByte.AsBool(); init => TelemetryIsNotRestrictedByte = value.AsByte(); }
	private byte ShowOnlineNamesByte { get; init; } // The player's show online names setting, 0 = off, 1 = o
	public bool ShowOnlineNames { get => ShowOnlineNamesByte.AsBool(); init => ShowOnlineNamesByte = value.AsByte(); }
	public Platform Platform { get; init; }

	static ParticipantData IByteParsable<ParticipantData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			IsAiControlledByte = reader.GetNextByte(),
			Driver = reader.GetNextEnum<Driver>(),
			NetworkId = reader.GetNextByte(),
			Team = reader.GetNextEnum<Team>(),
			IsMyTeamByte = reader.GetNextByte(),
			RaceNumber = reader.GetNextByte(),
			Nationality = reader.GetNextEnum<Nationality>(),
			NameBytes = reader.GetNextStringBytes(48),
			TelemetryIsNotRestrictedByte = reader.GetNextByte(),
			ShowOnlineNamesByte = reader.GetNextByte(),
			Platform = reader.GetNextEnum<Platform>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(IsAiControlledByte);
		writer.WriteEnum(Driver);
		writer.Write(NetworkId);
		writer.WriteEnum(Team);
		writer.Write(IsMyTeamByte);
		writer.Write(RaceNumber);
		writer.WriteEnum(Nationality);
		writer.Write(Name, 48);
		writer.Write(TelemetryIsNotRestrictedByte);
		writer.Write(ShowOnlineNamesByte);
		writer.WriteEnum(Platform);
	}
}
