namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 26)]
public readonly record struct EventDetails
{
	[field: FieldOffset(0)]
	public EventType EventType { get; init; } // Event string code, see below 4 chars
	[field: FieldOffset(4)]
	public ButtonsEvent ButtonsEvent { get; init; }
	[field: FieldOffset(4)]
	public DriveThroughPenaltyServedEvent DriveThroughPenaltyServedEvent { get; init; }
	[field: FieldOffset(4)]
	public FastestLapEvent FastestLapEvent { get; init; }
	[field: FieldOffset(4)]
	public FlashbackEvent FlashbackEvent { get; init; }
	[field: FieldOffset(4)]
	public OvertakeEvent OvertakeEvent { get; init; }
	[field: FieldOffset(4)]
	public PenaltyEvent PenaltyEvent { get; init; }
	[field: FieldOffset(4)]
	public RaceWinnerEvent RaceWinnerEvent { get; init; }
	[field: FieldOffset(4)]
	public RetirementEvent RetirementEvent { get; init; }
	[field: FieldOffset(4)]
	public SpeedTrapEvent SpeedTrapEvent { get; init; }
	[field: FieldOffset(4)]
	public StartLightsEvent StartLightsEvent { get; init; }
	[field: FieldOffset(4)]
	public StopGoPenaltyServedEvent StopGoPenaltyServedEvent { get; init; }
	[field: FieldOffset(4)]
	public TeamMateInPitsEvent TeamMateInPitsEvent { get; init; }
	[field: FieldOffset(4)]
	public CollisionEvent CollisionEvent { get; init; }
	[field: FieldOffset(4)]
	public SafetyCarEvent SafetyCarEvent { get; init; }

	public static implicit operator EventDetails(ButtonsEvent buttonsEvent) => new() { EventType = EventType.ButtonStatus, ButtonsEvent = buttonsEvent };
	public static implicit operator EventDetails(DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent) => new() { EventType = EventType.DriveThroughServed, DriveThroughPenaltyServedEvent = driveThroughPenaltyServedEvent };
	public static implicit operator EventDetails(FastestLapEvent fastestLapEvent) => new() { EventType = EventType.FastestLap, FastestLapEvent = fastestLapEvent };
	public static implicit operator EventDetails(FlashbackEvent flashbackEvent) => new() { EventType = EventType.Flashback, FlashbackEvent = flashbackEvent };
	public static implicit operator EventDetails(OvertakeEvent overtakeEvent) => new() { EventType = EventType.Overtake, OvertakeEvent = overtakeEvent };
	public static implicit operator EventDetails(PenaltyEvent penaltyEvent) => new() { EventType = EventType.PenaltyIssued, PenaltyEvent = penaltyEvent };
	public static implicit operator EventDetails(RaceWinnerEvent raceWinnerEvent) => new() { EventType = EventType.RaceWinner, RaceWinnerEvent = raceWinnerEvent };
	public static implicit operator EventDetails(RetirementEvent retirementEvent) => new() { EventType = EventType.Retirement, RetirementEvent = retirementEvent };
	public static implicit operator EventDetails(SpeedTrapEvent speedTrapEvent) => new() { EventType = EventType.SpeedTrapTriggered, SpeedTrapEvent = speedTrapEvent };
	public static implicit operator EventDetails(StartLightsEvent startLightsEvent) => new() { EventType = EventType.StartLights, StartLightsEvent = startLightsEvent };
	public static implicit operator EventDetails(StopGoPenaltyServedEvent stopGoPenaltyServedEvent) => new() { EventType = EventType.StopGoServed, StopGoPenaltyServedEvent = stopGoPenaltyServedEvent };
	public static implicit operator EventDetails(TeamMateInPitsEvent teamMateInPitsEvent) => new() { EventType = EventType.TeamMateInPits, TeamMateInPitsEvent = teamMateInPitsEvent };
	public static implicit operator EventDetails(CollisionEvent collisionEvent) => new() { EventType = EventType.Collision, CollisionEvent = collisionEvent };
	public static implicit operator EventDetails(SafetyCarEvent safetyCarEvent) => new() { EventType = EventType.SafetyCar, SafetyCarEvent = safetyCarEvent };
}
