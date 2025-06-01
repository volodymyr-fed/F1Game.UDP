using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct LobbyInfoData() : IByteParsable<LobbyInfoData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 42;

	/// <summary>
	/// Gets whether the vehicle is AI or Human.
	/// </summary>
	public bool IsAiControlled { get; init; }
	/// <summary>
	/// Gets the team.
	/// </summary>
	public Team Team { get; init; }
	/// <summary>
	/// Gets the nationality of the driver.
	/// </summary>
	public Nationality Nationality { get; init; }
	/// <summary>
	/// Gets the platform.
	/// </summary>
	public Platform Platform { get; init; }
	/// <summary>
	/// The name of participant in UTF-8 bytes – null terminated. Will be truncated with ... (U+2026) if too long; 32 bytes maximum.
	/// </summary>
	public Array32<byte> NameBytes { get; init; }
	/// <summary>
	/// The name of participant in UTF-8 format – null terminated. Will be truncated with ... (U+2026) if too long; 32 bytes maximum.
	/// </summary>
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsArray32Bytes(); }
	/// <summary>
	/// Car number of the player.
	/// </summary>
	public byte CarNumber { get; init; }
	/// <summary>
	/// The player's telemetry publicity setting.
	/// </summary>
	public bool IsTelemetryPublic { get; init; }
	/// <summary>
	/// The player's show online names setting.
	/// </summary>
	public bool ShowOnlineNames { get; init; }
	/// <summary>
	/// F1 World tech level.
	/// </summary>
	public ushort TechLevel { get; init; }
	/// <summary>
	/// Ready status.
	/// </summary>
	public ReadyStatus ReadyStatus { get; init; }

	static LobbyInfoData IByteParsable<LobbyInfoData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			IsAiControlled = reader.GetNextBoolean(),
			Team = reader.GetNextEnum<Team>(),
			Nationality = reader.GetNextEnum<Nationality>(),
			Platform = reader.GetNextEnum<Platform>(),
			NameBytes = reader.GetNextBytes(32),
			CarNumber = reader.GetNextByte(),
			IsTelemetryPublic = reader.GetNextBoolean(),
			ShowOnlineNames = reader.GetNextBoolean(),
			TechLevel = reader.GetNextUShort(),
			ReadyStatus = reader.GetNextEnum<ReadyStatus>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(IsAiControlled);
		writer.WriteEnum(Team);
		writer.WriteEnum(Nationality);
		writer.WriteEnum(Platform);
		writer.Write(NameBytes.AsReadOnlySpan());
		writer.Write(CarNumber);
		writer.Write(IsTelemetryPublic);
		writer.Write(ShowOnlineNames);
		writer.Write(TechLevel);
		writer.WriteEnum(ReadyStatus);
	}
}
