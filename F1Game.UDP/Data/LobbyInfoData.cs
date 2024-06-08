using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

public readonly record struct LobbyInfoData() : IByteParsable<LobbyInfoData>, IByteWritable
{
	private byte IsAiControlledByte { get; init; } // Whether the vehicle is AI (1) or Human (0) controlled
	public bool IsAiControlled { get => IsAiControlledByte.AsBool(); init => IsAiControlledByte = value.AsByte(); }
	public Team Team { get; init; } // Team id - see appendix (255 if no team currently selected)
	public Nationality Nationality { get; init; } // Nationality of the driver
	public Platform Platform { get; init; }
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] NameBytes { get; init; }
	// Name of participant in UTF-8 format – null terminated Will be truncated with ... (U+2026) if too long; 48 chars
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsBytes(); }
	public byte CarNumber { get; init; } // Car number of the player
	public ReadyStatus ReadyStatus { get; init; } // 0 = not ready, 1 = ready, 2 = spectating

	static LobbyInfoData IByteParsable<LobbyInfoData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			IsAiControlledByte = reader.GetNextByte(),
			Team = reader.GetNextEnum<Team>(),
			Nationality = reader.GetNextEnum<Nationality>(),
			Platform = reader.GetNextEnum<Platform>(),
			NameBytes = reader.GetNextStringBytes(48),
			CarNumber = reader.GetNextByte(),
			ReadyStatus = reader.GetNextEnum<ReadyStatus>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(IsAiControlledByte);
		writer.WriteEnum(Team);
		writer.WriteEnum(Nationality);
		writer.WriteEnum(Platform);
		writer.Write(Name, 48);
		writer.Write(CarNumber);
		writer.WriteEnum(ReadyStatus);
	}
}
