using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

public sealed record SessionDataPacket : IPacket, IByteParsable<SessionDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 644;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Weather Weather { get; init; } // Weather - 0 = clear, 1 = light cloud, 2 = overcast, 3 = light rain, 4 = heavy rain, 5 = storm
	public sbyte TrackTemperature { get; init; } // Track temp. in degrees celsius
	public sbyte AirTemperature { get; init; } // Air temp. in degrees celsius
	public byte TotalLaps { get; init; } // Total number of laps in this race
	public ushort TrackLength { get; init; } // Track length in metres
	public SessionType SessionType { get; init; }
	public Track Track { get; init; } // -1 for unknown, see appendix
	public FormulaType Formula { get; init; }
	public ushort SessionTimeLeft { get; init; } // Time left in session in seconds
	public ushort SessionDuration { get; init; } // Session duration in seconds
	public byte PitSpeedLimit { get; init; } // Pit speed limit in kilometres per hour
	public bool GamePaused { get; init; } // Whether the game is paused – network game only
	public bool IsSpectating { get; init; } // Whether the player is spectating
	public byte SpectatorCarIndex { get; init; } // Index of the car being spectated
	public bool IsSliProNativeSupport { get; init; } // SLI Pro support, 0 = inactive, 1 = active
	public byte NumMarshalZones { get; init; } // Number of marshal zones to follow
	public MarshalZone[] MarshalZones { get; init; } = Array.Empty<MarshalZone>(); // List of marshal zones – max 21
	public SafetyCarStatus SafetyCarStatus { get; init; } // 0 = no safety car, 1 = full, 2 = virtual, 3 = formation lap
	public bool IsNetworkGame { get; init; } // 0 = offline, 1 = online
	public byte NumWeatherForecastSamples { get; init; } // Number of weather samples to follow
	public WeatherForecastSample[] WeatherForecastSamples { get; init; } = Array.Empty<WeatherForecastSample>(); // Array of weather forecast samples 56 cells
	public ForecastAccuracy ForecastAccuracy { get; init; } // 0 = Perfect, 1 = Approximate
	public byte AIDifficulty { get; init; } // AI Difficulty rating – 0-110
	public uint SeasonLinkIdentifier { get; init; } // Identifier for season - persists across saves
	public uint WeekendLinkIdentifier { get; init; } // Identifier for weekend - persists across saves
	public uint SessionLinkIdentifier { get; init; } // Identifier for session - persists across saves
	public byte PitStopWindowIdealLap { get; init; } // Ideal lap to pit on for current strategy (player)
	public byte PitStopWindowLatestLap { get; init; } // Latest lap to pit on for current strategy (player)
	public byte PitStopRejoinPosition { get; init; } // Predicted position to rejoin at (player)
	public bool IsSteeringAssistOn { get; init; } // 0 = off, 1 = on
	public BrakingAssist BrakingAssist { get; init; } // 0 = off, 1 = low, 2 = medium, 3 = high
	public GearboxAssist GearboxAssist { get; init; } // 1 = manual, 2 = manual & suggested gear, 3 = auto
	public bool PitAssist { get; init; } // 0 = off, 1 = on
	public bool PitReleaseAssist { get; init; } // 0 = off, 1 = on
	public bool ERSAssist { get; init; } // 0 = off, 1 = on
	public bool DRSAssist { get; init; } // 0 = off, 1 = on
	public RacingLine DynamicRacingLine { get; init; } // 0 = off, 1 = corners only, 2 = full
	public RacingLineType DynamicRacingLineType { get; init; } // 0 = 2D, 1 = 3D
	public GameMode GameMode { get; init; } // Game mode id - see appendix
	public RuleSet RuleSet { get; init; } // Ruleset - see appendix
	public uint TimeOfDay { get; init; } // Local time of day - minutes since midnight
	public SessionLength SessionLength { get; init; } // 0 = None, 2 = Very Short, 3 = Short, 4 = Medium, 5 = Medium Long, 6 = Long, 7 = Full
	public SpeedUnit SpeedUnitsLeadPlayer { get; init; }  // 0 = MPH, 1 = KPH
	public TemperatureUnit TemperatureUnitsLeadPlayer { get; init; }  // 0 = Celsius, 1 = Fahrenheit
	public SpeedUnit SpeedUnitsSecondaryPlayer { get; init; }  // 0 = MPH, 1 = KPH
	public TemperatureUnit TemperatureUnitsSecondaryPlayer { get; init; }  // 0 = Celsius, 1 = Fahrenheit
	public byte NumSafetyCarPeriods { get; init; } // Number of safety cars called during session
	public byte NumVirtualSafetyCarPeriods { get; init; } // Number of virtual safety cars called
	public byte NumRedFlagPeriods { get; init; } // Number of red flags called during sessio

	static SessionDataPacket IByteParsable<SessionDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			Weather = reader.GetNextEnum<Weather>(),
			TrackTemperature = reader.GetNextSbyte(),
			AirTemperature = reader.GetNextSbyte(),
			TotalLaps = reader.GetNextByte(),
			TrackLength = reader.GetNextUShort(),
			SessionType = reader.GetNextEnum<SessionType>(),
			Track = reader.GetNextEnum<Track>(),
			Formula = reader.GetNextEnum<FormulaType>(),
			SessionTimeLeft = reader.GetNextUShort(),
			SessionDuration = reader.GetNextUShort(),
			PitSpeedLimit = reader.GetNextByte(),
			GamePaused = reader.GetNextBoolean(),
			IsSpectating = reader.GetNextBoolean(),
			SpectatorCarIndex = reader.GetNextByte(),
			IsSliProNativeSupport = reader.GetNextBoolean(),
			NumMarshalZones = reader.GetNextByte(),
			MarshalZones = reader.GetNextObjects<MarshalZone>(21),
			SafetyCarStatus = reader.GetNextEnum<SafetyCarStatus>(),
			IsNetworkGame = reader.GetNextBoolean(),
			NumWeatherForecastSamples = reader.GetNextByte(),
			WeatherForecastSamples = reader.GetNextObjects<WeatherForecastSample>(56),
			ForecastAccuracy = reader.GetNextEnum<ForecastAccuracy>(),
			AIDifficulty = reader.GetNextByte(),
			SeasonLinkIdentifier = reader.GetNextUInt(),
			WeekendLinkIdentifier = reader.GetNextUInt(),
			SessionLinkIdentifier = reader.GetNextUInt(),
			PitStopWindowIdealLap = reader.GetNextByte(),
			PitStopWindowLatestLap = reader.GetNextByte(),
			PitStopRejoinPosition = reader.GetNextByte(),
			IsSteeringAssistOn = reader.GetNextBoolean(),
			BrakingAssist = reader.GetNextEnum<BrakingAssist>(),
			GearboxAssist = reader.GetNextEnum<GearboxAssist>(),
			PitAssist = reader.GetNextBoolean(),
			PitReleaseAssist = reader.GetNextBoolean(),
			ERSAssist = reader.GetNextBoolean(),
			DRSAssist = reader.GetNextBoolean(),
			DynamicRacingLine = reader.GetNextEnum<RacingLine>(),
			DynamicRacingLineType = reader.GetNextEnum<RacingLineType>(),
			GameMode = reader.GetNextEnum<GameMode>(),
			RuleSet = reader.GetNextEnum<RuleSet>(),
			TimeOfDay = reader.GetNextUInt(),
			SessionLength = reader.GetNextEnum<SessionLength>(),
			SpeedUnitsLeadPlayer = reader.GetNextEnum<SpeedUnit>(),
			TemperatureUnitsLeadPlayer = reader.GetNextEnum<TemperatureUnit>(),
			SpeedUnitsSecondaryPlayer = reader.GetNextEnum<SpeedUnit>(),
			TemperatureUnitsSecondaryPlayer = reader.GetNextEnum<TemperatureUnit>(),
			NumSafetyCarPeriods = reader.GetNextByte(),
			NumVirtualSafetyCarPeriods = reader.GetNextByte(),
			NumRedFlagPeriods = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteObject(Header);
		writer.WriteEnum(Weather);
		writer.WriteSByte(TrackTemperature);
		writer.WriteSByte(AirTemperature);
		writer.WriteByte(TotalLaps);
		writer.WriteUShort(TrackLength);
		writer.WriteEnum(SessionType);
		writer.WriteEnum(Track);
		writer.WriteEnum(Formula);
		writer.WriteUShort(SessionTimeLeft);
		writer.WriteUShort(SessionDuration);
		writer.WriteByte(PitSpeedLimit);
		writer.WriteBoolean(GamePaused);
		writer.WriteBoolean(IsSpectating);
		writer.WriteByte(SpectatorCarIndex);
		writer.WriteBoolean(IsSliProNativeSupport);
		writer.WriteByte(NumMarshalZones);
		writer.WriteObjects(MarshalZones);
		writer.WriteEnum(SafetyCarStatus);
		writer.WriteBoolean(IsNetworkGame);
		writer.WriteByte(NumWeatherForecastSamples);
		writer.WriteObjects(WeatherForecastSamples);
		writer.WriteEnum(ForecastAccuracy);
		writer.WriteByte(AIDifficulty);
		writer.WriteUInt(SeasonLinkIdentifier);
		writer.WriteUInt(WeekendLinkIdentifier);
		writer.WriteUInt(SessionLinkIdentifier);
		writer.WriteByte(PitStopWindowIdealLap);
		writer.WriteByte(PitStopWindowLatestLap);
		writer.WriteByte(PitStopRejoinPosition);
		writer.WriteBoolean(IsSteeringAssistOn);
		writer.WriteEnum(BrakingAssist);
		writer.WriteEnum(GearboxAssist);
		writer.WriteBoolean(PitAssist);
		writer.WriteBoolean(PitReleaseAssist);
		writer.WriteBoolean(ERSAssist);
		writer.WriteBoolean(DRSAssist);
		writer.WriteEnum(DynamicRacingLine);
		writer.WriteEnum(DynamicRacingLineType);
		writer.WriteEnum(GameMode);
		writer.WriteEnum(RuleSet);
		writer.WriteUInt(TimeOfDay);
		writer.WriteEnum(SessionLength);
		writer.WriteEnum(SpeedUnitsLeadPlayer);
		writer.WriteEnum(TemperatureUnitsLeadPlayer);
		writer.WriteEnum(SpeedUnitsSecondaryPlayer);
		writer.WriteEnum(TemperatureUnitsSecondaryPlayer);
		writer.WriteByte(NumSafetyCarPeriods);
		writer.WriteByte(NumVirtualSafetyCarPeriods);
		writer.WriteByte(NumRedFlagPeriods);
	}
}
