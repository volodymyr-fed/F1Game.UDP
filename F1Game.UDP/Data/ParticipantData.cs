using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ParticipantData() : IByteParsable<ParticipantData>, IByteWritable, ISizeable
{
	/// <inheritdoc/>
	static int ISizeable.Size => 60;

	/// <summary>
	/// Gets whether the vehicle is AI or Human.
	/// </summary>
	public bool IsAiControlled { get; init; }
	/// <summary>
	/// Gets the driver id.
	/// </summary>
	public Driver Driver { get; init; }
	/// <summary>
	/// Gets the network id – unique identifier for network players.
	/// </summary>
	public byte NetworkId { get; init; }
	/// <summary>
	/// Gets the team.
	/// </summary>
	public Team Team { get; init; }
	/// <summary>
	/// Gets a value indicating whether this is the player's team (true = My Team, false = otherwise).
	/// </summary>
	public bool IsMyTeam { get; init; }
	/// <summary>
	/// Gets the race number of the car.
	/// </summary>
	public byte RaceNumber { get; init; }
	/// <summary>
	/// Gets the nationality of the driver.
	/// </summary>
	public Nationality Nationality { get; init; }
	/// <summary>
	/// The name of participant in UTF-8 bytes – null terminated. Will be truncated with ... (U+2026) if too long; 48 chars.
	/// </summary>
	public Array48<byte> NameBytes { get; init; }
	/// <summary>
	/// The name of participant in UTF-8 format – null terminated. Will be truncated with ... (U+2026) if too long; 48 chars.
	/// </summary>
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsArray48Bytes(); }
	/// <summary>
	/// The player's telemetry publicity setting.
	/// </summary>
	public bool IsTelemetryPublic { get; init; }
	/// <summary>
	/// The player's show online names setting.
	/// </summary>
	public bool ShowOnlineNames { get; init; }
	/// <summary>
	/// Gets the F1 World tech level.
	/// </summary>
	public ushort TechLevel { get; init; }
	/// <summary>
	/// Gets the platform.
	/// </summary>
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
			IsTelemetryPublic = reader.GetNextBoolean(),
			ShowOnlineNames = reader.GetNextBoolean(),
			TechLevel = reader.GetNextUShort(),
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
		writer.Write(IsTelemetryPublic);
		writer.Write(ShowOnlineNames);
		writer.Write(TechLevel);
		writer.WriteEnum(Platform);
	}
}
