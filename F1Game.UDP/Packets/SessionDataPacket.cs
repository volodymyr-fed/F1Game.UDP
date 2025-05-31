using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

/// <summary>
/// The session packet includes details about the current session in progress.
/// <para>Frequency: 2 per second</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct SessionDataPacket() : IByteParsable<SessionDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 753;

	public PacketHeader Header { get; init; }
	public Weather Weather { get; init; }
	/// <summary>
	/// Track temp. in degrees celsius
	/// </summary>
	public sbyte TrackTemperature { get; init; }
	/// <summary>
	/// Air temp. in degrees celsius
	/// </summary>
	public sbyte AirTemperature { get; init; }
	/// <summary>
	/// Total number of laps in this race
	/// </summary>
	public byte TotalLaps { get; init; }
	/// <summary>
	/// Track length in metres
	/// </summary>
	public ushort TrackLength { get; init; }
	public SessionType SessionType { get; init; }
	public Track Track { get; init; }
	public FormulaType Formula { get; init; }
	/// <summary>
	/// Time left in session in seconds
	/// </summary>
	public ushort SessionTimeLeft { get; init; }
	/// <summary>
	/// Session duration in seconds
	/// </summary>
	public ushort SessionDuration { get; init; }
	/// <summary>
	/// Pit speed limit in kilometres per hour
	/// </summary>
	public byte PitSpeedLimit { get; init; }
	/// <summary>
	/// Whether the game is paused – network game only
	/// </summary>
	public bool GamePaused { get; init; }
	/// <summary>
	/// Whether the player is spectating
	/// </summary>
	public bool IsSpectating { get; init; }
	/// <summary>
	/// Index of the car being spectated
	/// </summary>
	public byte SpectatorCarIndex { get; init; }
	/// <summary>
	/// SLI Pro support
	/// </summary>
	public bool IsSliProNativeSupportActive { get; init; }
	/// <summary>
	/// Number of marshal zones to follow in <see cref="MarshalZones"/>
	/// </summary>
	public byte NumMarshalZones { get; init; }
	/// <summary>
	/// List of marshal zones – max 21
	/// </summary>
	public Array21<MarshalZone> MarshalZones { get; init; }
	public SafetyCarType SafetyCarStatus { get; init; }
	public bool IsNetworkGame { get; init; }
	/// <summary>
	/// Number of weather samples to follow in <see cref="WeatherForecastSamples"/>
	/// </summary>
	public byte NumWeatherForecastSamples { get; init; }
	/// <summary>
	/// Array of weather forecast samples 64 cells
	/// </summary>
	public Array64<WeatherForecastSample> WeatherForecastSamples { get; init; }
	public ForecastAccuracy ForecastAccuracy { get; init; }
	/// <summary>
	/// AI Difficulty rating – 0-110
	/// </summary>
	public byte AIDifficulty { get; init; }
	/// <summary>
	/// Identifier for season - persists across saves
	/// </summary>
	public uint SeasonLinkIdentifier { get; init; }
	/// <summary>
	/// Identifier for weekend - persists across saves
	/// </summary>
	public uint WeekendLinkIdentifier { get; init; }
	/// <summary>
	/// Identifier for session - persists across saves
	/// </summary>
	public uint SessionLinkIdentifier { get; init; }
	/// <summary>
	/// Ideal lap to pit on for current strategy (player)
	/// </summary>
	public byte PitStopWindowIdealLap { get; init; }
	/// <summary>
	/// Latest lap to pit on for current strategy (player)
	/// </summary>
	public byte PitStopWindowLatestLap { get; init; }
	/// <summary>
	/// Predicted position to rejoin at (player)
	/// </summary>
	public byte PitStopRejoinPosition { get; init; }
	public bool IsSteeringAssistOn { get; init; }
	public BrakingAssist BrakingAssist { get; init; }
	public GearboxAssist GearboxAssist { get; init; }
	public bool PitAssist { get; init; }
	public bool PitReleaseAssist { get; init; } 
	public bool ERSAssist { get; init; }
	public bool DRSAssist { get; init; }
	public RacingLine DynamicRacingLine { get; init; }
	public RacingLineType DynamicRacingLineType { get; init; }
	public GameMode GameMode { get; init; }
	public RuleSet RuleSet { get; init; }
	/// <summary>
	/// Local time of day - minutes since midnight
	/// </summary>
	public uint TimeOfDay { get; init; }
	public SessionLength SessionLength { get; init; }
	public SpeedUnit SpeedUnitsLeadPlayer { get; init; }
	public TemperatureUnit TemperatureUnitsLeadPlayer { get; init; }
	public SpeedUnit SpeedUnitsSecondaryPlayer { get; init; }
	public TemperatureUnit TemperatureUnitsSecondaryPlayer { get; init; }
	/// <summary>
	/// Number of safety cars called during session
	/// </summary>
	public byte NumSafetyCarPeriods { get; init; }
	/// <summary>
	/// Number of virtual safety cars called
	/// </summary>
	public byte NumVirtualSafetyCarPeriods { get; init; }
	/// <summary>
	/// Number of red flags called during session
	/// </summary>
	public byte NumRedFlagPeriods { get; init; }

	public bool IsEqualCarPerformance { get; init; } 
	public RecoveryMode RecoveryMode { get; init; }
	public FlashbackLimit FlashbackLimit { get; init; }
	public SurfaceSettings SurfaceTypeSettings { get; init; }
	public LowFuelMode LowFuelMode { get; init; }
	public RaceStarts RaceStarts { get; init; }
	public TyreTemperatureSettings TyreTemperature { get; init; }
	private bool PitLaneTyreSimDisabled { get; init; }
	public bool PitLaneTyreSim { get => !PitLaneTyreSimDisabled; init => PitLaneTyreSimDisabled = !value; }
	public CarDamageSetting CarDamage { get; init; }
	public CarDamageRateSetting CarDamageRate { get; init; }
	public CollisionSettings Collisions { get; init; }
	public bool IsCollisionsOffForFirstLapOnlyEnabled { get; init; }
	private bool UnsafePitReleaseDisabled { get; init; }
	public bool UnsafePitRelease { get => !UnsafePitReleaseDisabled; init => UnsafePitReleaseDisabled = !value; }
	public bool OffForGriefing { get; init; }
	public CornerCuttingSettings CornerCuttingStringency { get; init; }
	public bool ParcFermeRules { get; init; }
	public PitStopExperienceSetting PitStopExperience { get; init; }
	public SafetyCarSetting SafetyCarSetting { get; init; }
	public ExperienceSetting SafetyCarExperience { get; init; }
	public bool FormationLap { get; init; }
	public ExperienceSetting FormationLapExperience { get; init; }
	public RedFlagSetting RedFlags { get; init; }
	public bool AffectsLicenceLevelSolo { get; init; }
	public bool AffectsLicenceLevelMP { get; init; }
	/// <summary>
	/// Number of session in <see cref="WeekendStructure"/>
	/// </summary>
	public byte NumSessionsInWeekend { get; init; }
	/// <summary>
	/// List of session types to show weekend
	/// </summary>
	public Array12<SessionType> WeekendStructure { get; init; }
	/// <summary>
	/// Distance in m around track where sector 2 starts
	/// </summary>
	public float Sector2LapDistanceStart { get; init; }
	/// <summary>
	/// Distance in m around track where sector 3 start
	/// </summary>
	public float Sector3LapDistanceStart { get; init; }

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
			IsSliProNativeSupportActive = reader.GetNextBoolean(),
			NumMarshalZones = reader.GetNextByte(),
			MarshalZones = reader.GetNextArray21<MarshalZone>(),
			SafetyCarStatus = reader.GetNextEnum<SafetyCarType>(),
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
			IsEqualCarPerformance = reader.GetNextBoolean(),
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
			IsCollisionsOffForFirstLapOnlyEnabled = reader.GetNextBoolean(),
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
		writer.Write(IsSliProNativeSupportActive);
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
		writer.Write(IsEqualCarPerformance);
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
		writer.Write(IsCollisionsOffForFirstLapOnlyEnabled);
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
