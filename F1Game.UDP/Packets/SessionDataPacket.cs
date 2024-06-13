using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 753)]
public readonly record struct SessionDataPacket() : IByteParsable<SessionDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 753;
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
	public Array21<MarshalZone> MarshalZones { get; init; } // List of marshal zones – max 21
	public SafetyCarStatus SafetyCarStatus { get; init; } // 0 = no safety car, 1 = full, 2 = virtual, 3 = formation lap
	public bool IsNetworkGame { get; init; } // 0 = offline, 1 = online
	public byte NumWeatherForecastSamples { get; init; } // Number of weather samples to follow
	public Array64<WeatherForecastSample> WeatherForecastSamples { get; init; } // Array of weather forecast samples 64 cells
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
	public byte NumRedFlagPeriods { get; init; } // Number of red flags called during session

	public bool EqualCarPerformance { get; init; } // 0 = off, 1 = on
	public RecoveryMode RecoveryMode { get; init; } // 0 = None, 1 = Flashbacks, 2 = Auto-recovery
	public FlashbackLimit FlashbackLimit { get; init; } // 0 = Low, 1 = Medium, 2 = High, 3 = Unlimited
	public SurfaceSettings SurfaceTypeSettings { get; init; } // 0 = Simplified, 1 = Realistic
	public LowFuelMode LowFuelMode { get; init; }// 0 = Easy, 1 = Hard
	public RaceStarts RaceStarts { get; init; } // 0 = Manual, 1 = Assisted
	public TyreTemperatureSettings TyreTemperature { get; init; } // 0 = Surface only, 1 = Surface & Carcass
	private bool PitLaneTyreSimDisabled { get; init; } // PitLaneTyreSim 0 = On, 1 = Off
	public bool PitLaneTyreSim { get => !PitLaneTyreSimDisabled; init => PitLaneTyreSimDisabled = !value; }
	public CarDamageSetting CarDamage { get; init; } // 0 = Off, 1 = Reduced, 2 = Standard, 3 = Simulation
	public CarDamageRateSetting CarDamageRate { get; init; } // 0 = Reduced, 1 = Standard, 2 = Simulation
	public CollisionSettings Collisions { get; init; } // 0 = Off, 1 = Player-to-Player Off, 2 = On
	public bool CollisionsOffForFirstLapOnly { get; init; } // 0 = Disabled, 1 = Enabled
	private bool UnsafePitReleaseDisabled { get; init; } //UnsafePitRelease 0 = On, 1 = Off (Multiplayer)
	public bool UnsafePitRelease { get => !UnsafePitReleaseDisabled; init => UnsafePitReleaseDisabled = !value; }
	public bool OffForGriefing { get; init; } // 0 = Disabled, 1 = Enabled (Multiplayer)
	public CornerCuttingSettings CornerCuttingStringency { get; init; } // 0 = Regular, 1 = Strict
	public bool ParcFermeRules { get; init; } // 0 = Off, 1 = On
	public PitStopExperienceSetting PitStopExperience { get; init; } // 0 = Automatic, 1 = Broadcast, 2 = Immersive
	public SafetyCarSetting SafetyCarSetting { get; init; } // 0 = Off, 1 = Reduced, 2 = Standard, 3 = Increased
	public ExperienceSetting SafetyCarExperience { get; init; } // 0 = Broadcast, 1 = Immersive
	public bool FormationLap { get; init; } // 0 = Off, 1 = On
	public ExperienceSetting FormationLapExperience { get; init; } // 0 = Broadcast, 1 = Immersive
	public RedFlagSetting RedFlags { get; init; } // 0 = Off, 1 = Reduced, 2 = Standard, 3 = Increased
	public bool AffectsLicenceLevelSolo { get; init; } // 0 = Off, 1 = On
	public bool AffectsLicenceLevelMP { get; init; } // 0 = Off, 1 = On
	public byte NumSessionsInWeekend { get; init; } // Number of session in following array
	public Array12<SessionType> WeekendStructure { get; init; } // List of session types to show weekend

	public float Sector2LapDistanceStart { get; init; } // Distance in m around track where sector 2 starts
	public float Sector3LapDistanceStart { get; init; } // Distance in m around track where sector 3 start

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
			MarshalZones = reader.GetNextArray21<MarshalZone>(),
			SafetyCarStatus = reader.GetNextEnum<SafetyCarStatus>(),
			IsNetworkGame = reader.GetNextBoolean(),
			NumWeatherForecastSamples = reader.GetNextByte(),
			WeatherForecastSamples = reader.GetNextArray64<WeatherForecastSample>(),
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
			EqualCarPerformance = reader.GetNextBoolean(),
			RecoveryMode = reader.GetNextEnum<RecoveryMode>(),
			FlashbackLimit = reader.GetNextEnum<FlashbackLimit>(),
			SurfaceTypeSettings = reader.GetNextEnum<SurfaceSettings>(),
			LowFuelMode = reader.GetNextEnum<LowFuelMode>(),
			RaceStarts = reader.GetNextEnum<RaceStarts>(),
			TyreTemperature = reader.GetNextEnum<TyreTemperatureSettings>(),
			PitLaneTyreSimDisabled = reader.GetNextBoolean(),
			CarDamage = reader.GetNextEnum<CarDamageSetting>(),
			CarDamageRate = reader.GetNextEnum<CarDamageRateSetting>(),
			Collisions = reader.GetNextEnum<CollisionSettings>(),
			CollisionsOffForFirstLapOnly = reader.GetNextBoolean(),
			UnsafePitReleaseDisabled = reader.GetNextBoolean(),
			OffForGriefing = reader.GetNextBoolean(),
			CornerCuttingStringency = reader.GetNextEnum<CornerCuttingSettings>(),
			ParcFermeRules = reader.GetNextBoolean(),
			PitStopExperience = reader.GetNextEnum<PitStopExperienceSetting>(),
			SafetyCarSetting = reader.GetNextEnum<SafetyCarSetting>(),
			SafetyCarExperience = reader.GetNextEnum<ExperienceSetting>(),
			FormationLap = reader.GetNextBoolean(),
			FormationLapExperience = reader.GetNextEnum<ExperienceSetting>(),
			RedFlags = reader.GetNextEnum<RedFlagSetting>(),
			AffectsLicenceLevelSolo = reader.GetNextBoolean(),
			AffectsLicenceLevelMP = reader.GetNextBoolean(),
			NumSessionsInWeekend = reader.GetNextByte(),
			WeekendStructure = reader.GetNextArray12Enum<SessionType>(),
			Sector2LapDistanceStart = reader.GetNextFloat(),
			Sector3LapDistanceStart = reader.GetNextFloat()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.WriteEnum(Weather);
		writer.Write(TrackTemperature);
		writer.Write(AirTemperature);
		writer.Write(TotalLaps);
		writer.Write(TrackLength);
		writer.WriteEnum(SessionType);
		writer.WriteEnum(Track);
		writer.WriteEnum(Formula);
		writer.Write(SessionTimeLeft);
		writer.Write(SessionDuration);
		writer.Write(PitSpeedLimit);
		writer.Write(GamePaused);
		writer.Write(IsSpectating);
		writer.Write(SpectatorCarIndex);
		writer.Write(IsSliProNativeSupport);
		writer.Write(NumMarshalZones);
		writer.Write(MarshalZones);
		writer.WriteEnum(SafetyCarStatus);
		writer.Write(IsNetworkGame);
		writer.Write(NumWeatherForecastSamples);
		writer.Write(WeatherForecastSamples);
		writer.WriteEnum(ForecastAccuracy);
		writer.Write(AIDifficulty);
		writer.Write(SeasonLinkIdentifier);
		writer.Write(WeekendLinkIdentifier);
		writer.Write(SessionLinkIdentifier);
		writer.Write(PitStopWindowIdealLap);
		writer.Write(PitStopWindowLatestLap);
		writer.Write(PitStopRejoinPosition);
		writer.Write(IsSteeringAssistOn);
		writer.WriteEnum(BrakingAssist);
		writer.WriteEnum(GearboxAssist);
		writer.Write(PitAssist);
		writer.Write(PitReleaseAssist);
		writer.Write(ERSAssist);
		writer.Write(DRSAssist);
		writer.WriteEnum(DynamicRacingLine);
		writer.WriteEnum(DynamicRacingLineType);
		writer.WriteEnum(GameMode);
		writer.WriteEnum(RuleSet);
		writer.Write(TimeOfDay);
		writer.WriteEnum(SessionLength);
		writer.WriteEnum(SpeedUnitsLeadPlayer);
		writer.WriteEnum(TemperatureUnitsLeadPlayer);
		writer.WriteEnum(SpeedUnitsSecondaryPlayer);
		writer.WriteEnum(TemperatureUnitsSecondaryPlayer);
		writer.Write(NumSafetyCarPeriods);
		writer.Write(NumVirtualSafetyCarPeriods);
		writer.Write(NumRedFlagPeriods);
		writer.Write(EqualCarPerformance);
		writer.WriteEnum(RecoveryMode);
		writer.WriteEnum(FlashbackLimit);
		writer.WriteEnum(SurfaceTypeSettings);
		writer.WriteEnum(LowFuelMode);
		writer.WriteEnum(RaceStarts);
		writer.WriteEnum(TyreTemperature);
		writer.Write(PitLaneTyreSimDisabled);
		writer.WriteEnum(CarDamage);
		writer.WriteEnum(CarDamageRate);
		writer.WriteEnum(Collisions);
		writer.Write(CollisionsOffForFirstLapOnly);
		writer.Write(UnsafePitReleaseDisabled);
		writer.Write(OffForGriefing);
		writer.WriteEnum(CornerCuttingStringency);
		writer.Write(ParcFermeRules);
		writer.WriteEnum(PitStopExperience);
		writer.WriteEnum(SafetyCarSetting);
		writer.WriteEnum(SafetyCarExperience);
		writer.Write(FormationLap);
		writer.WriteEnum(FormationLapExperience);
		writer.WriteEnum(RedFlags);
		writer.Write(AffectsLicenceLevelSolo);
		writer.Write(AffectsLicenceLevelMP);
		writer.Write(NumSessionsInWeekend);
		writer.WriteEnums(WeekendStructure);
		writer.Write(Sector2LapDistanceStart);
		writer.Write(Sector3LapDistanceStart);
	}
}
