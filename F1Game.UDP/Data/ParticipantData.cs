using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ParticipantData() : IByteParsable<ParticipantData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 57;

	/// <summary>
	/// Whether the vehicle is AI or Human.
	/// </summary>
	public bool IsAiControlled { get; init; }
	/// <summary>
	/// The driver id.
	/// </summary>
	public Driver Driver { get; init; }
	/// <summary>
	/// The network id – unique identifier for network players.
	/// </summary>
	public byte NetworkId { get; init; }
	/// <summary>
	/// The team.
	/// </summary>
	public Team Team { get; init; }
	/// <summary>
	/// A value indicating whether this is the player's team (true = My Team, false = otherwise).
	/// </summary>
	public bool IsMyTeam { get; init; }
	/// <summary>
	/// The race number of the car.
	/// </summary>
	public byte RaceNumber { get; init; }
	/// <summary>
	/// The nationality of the driver.
	/// </summary>
	public Nationality Nationality { get; init; }
	/// <summary>
	/// The name of participant in UTF-8 bytes – null terminated. Will be truncated with ... (U+2026) if too long; 32 bytes maximum.
	/// </summary>
	public Array32<byte> NameBytes { get; init; }
	/// <summary>
	/// The name of participant in UTF-8 format – null terminated. Will be truncated with ... (U+2026) if too long; 32 bytes maximum.
	/// </summary>
	public string Name { get => NameBytes.AsString(); init => NameBytes = value.AsArray32Bytes(); }
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
	/// <summary>
	/// Number of colors valid for this car in <see cref="LiveryColors"/>
	/// </summary>
	public byte LiveryNumberOfColors { get; init; }
	/// <summary>
	/// Colors for the car
	/// </summary>
	public Array4<LiveryColor> LiveryColors { get; init; }

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
			NameBytes = reader.GetNextBytes(32),
			IsTelemetryPublic = reader.GetNextBoolean(),
			ShowOnlineNames = reader.GetNextBoolean(),
			TechLevel = reader.GetNextUShort(),
			Platform = reader.GetNextEnum<Platform>(),
			LiveryNumberOfColors = reader.GetNextByte(),
			LiveryColors = reader.GetNextObjects<LiveryColor>(4)
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
		writer.Write(NameBytes.AsReadOnlySpan());
		writer.Write(IsTelemetryPublic);
		writer.Write(ShowOnlineNames);
		writer.Write(TechLevel);
		writer.WriteEnum(Platform);
		writer.Write(LiveryNumberOfColors);
		writer.Write(LiveryColors.AsReadOnlySpan());
	}
}
