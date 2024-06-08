using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 644)]
public sealed record SessionDataPacket() : IPacket, IByteParsable<SessionDataPacket>, ISizeable, IByteWritable
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
	private byte GamePausedByte { get; init; } // Whether the game is paused – network game only
	public bool GamePaused { get => GamePausedByte.AsBool(); init => GamePausedByte = value.AsByte(); }
	private byte IsSpectatingByte { get; init; } // Whether the player is spectating
	public bool IsSpectating { get => IsSpectatingByte.AsBool(); init => IsSpectatingByte = value.AsByte(); }
	public byte SpectatorCarIndex { get; init; } // Index of the car being spectated
	private byte IsSliProNativeSupportByte { get; init; } // SLI Pro support, 0 = inactive, 1 = active
	public bool IsSliProNativeSupport { get => IsSliProNativeSupportByte.AsBool(); init => IsSliProNativeSupportByte = value.AsByte(); }
	public byte NumMarshalZones { get; init; } // Number of marshal zones to follow
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	public MarshalZone[] MarshalZones { get; init; } = []; // List of marshal zones – max 21
	public SafetyCarStatus SafetyCarStatus { get; init; } // 0 = no safety car, 1 = full, 2 = virtual, 3 = formation lap
	private byte IsNetworkGameByte { get; init; } // 0 = offline, 1 = online
	public bool IsNetworkGame { get => IsNetworkGameByte.AsBool(); init => IsNetworkGameByte = value.AsByte(); }
	public byte NumWeatherForecastSamples { get; init; } // Number of weather samples to follow
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
	public WeatherForecastSample[] WeatherForecastSamples { get; init; } = []; // Array of weather forecast samples 56 cells
	public ForecastAccuracy ForecastAccuracy { get; init; } // 0 = Perfect, 1 = Approximate
	public byte AIDifficulty { get; init; } // AI Difficulty rating – 0-110
	public uint SeasonLinkIdentifier { get; init; } // Identifier for season - persists across saves
	public uint WeekendLinkIdentifier { get; init; } // Identifier for weekend - persists across saves
	public uint SessionLinkIdentifier { get; init; } // Identifier for session - persists across saves
	public byte PitStopWindowIdealLap { get; init; } // Ideal lap to pit on for current strategy (player)
	public byte PitStopWindowLatestLap { get; init; } // Latest lap to pit on for current strategy (player)
	public byte PitStopRejoinPosition { get; init; } // Predicted position to rejoin at (player)
	private byte IsSteeringAssistOnByte { get; init; } // 0 = off, 1 = on
	public bool IsSteeringAssistOn { get => IsSteeringAssistOnByte.AsBool(); init => IsSteeringAssistOnByte = value.AsByte(); }
	public BrakingAssist BrakingAssist { get; init; } // 0 = off, 1 = low, 2 = medium, 3 = high
	public GearboxAssist GearboxAssist { get; init; } // 1 = manual, 2 = manual & suggested gear, 3 = auto
	private byte PitAssistByte { get; init; } // 0 = off, 1 = on
	public bool PitAssist { get => PitAssistByte.AsBool(); init => PitAssistByte = value.AsByte(); }
	private byte PitReleaseAssistByte { get; init; } // 0 = off, 1 = on
	public bool PitReleaseAssist { get => PitReleaseAssistByte.AsBool(); init => PitReleaseAssistByte = value.AsByte(); }
	private byte ERSAssistByte { get; init; } // 0 = off, 1 = on
	public bool ERSAssist { get => ERSAssistByte.AsBool(); init => ERSAssistByte = value.AsByte(); }
	private byte DRSAssistByte { get; init; } // 0 = off, 1 = on
	public bool DRSAssist { get => DRSAssistByte.AsBool(); init => DRSAssistByte = value.AsByte(); }
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
			GamePausedByte = reader.GetNextByte(),
			IsSpectatingByte = reader.GetNextByte(),
			SpectatorCarIndex = reader.GetNextByte(),
			IsSliProNativeSupportByte = reader.GetNextByte(),
			NumMarshalZones = reader.GetNextByte(),
			MarshalZones = reader.GetNextObjects<MarshalZone>(21),
			SafetyCarStatus = reader.GetNextEnum<SafetyCarStatus>(),
			IsNetworkGameByte = reader.GetNextByte(),
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
			IsSteeringAssistOnByte = reader.GetNextByte(),
			BrakingAssist = reader.GetNextEnum<BrakingAssist>(),
			GearboxAssist = reader.GetNextEnum<GearboxAssist>(),
			PitAssistByte = reader.GetNextByte(),
			PitReleaseAssistByte = reader.GetNextByte(),
			ERSAssistByte = reader.GetNextByte(),
			DRSAssistByte = reader.GetNextByte(),
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
		writer.Write(GamePausedByte);
		writer.Write(IsSpectatingByte);
		writer.Write(SpectatorCarIndex);
		writer.Write(IsSliProNativeSupportByte);
		writer.Write(NumMarshalZones);
		writer.Write(MarshalZones);
		writer.WriteEnum(SafetyCarStatus);
		writer.Write(IsNetworkGameByte);
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
		writer.Write(IsSteeringAssistOnByte);
		writer.WriteEnum(BrakingAssist);
		writer.WriteEnum(GearboxAssist);
		writer.Write(PitAssistByte);
		writer.Write(PitReleaseAssistByte);
		writer.Write(ERSAssistByte);
		writer.Write(DRSAssistByte);
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
	}
}
