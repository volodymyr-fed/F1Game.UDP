namespace F1Game.UDP.Events;

/// <summary>
/// Represents a union of all possible F1 event details, allowing access to the specific event data based on <see cref="EventType"/>.
/// </summary>
[StructLayout(LayoutKind.Explicit, Pack = 1)]
public readonly record struct EventDetails : IByteParsable<EventDetails>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 16;

	/// <summary>
	/// Gets the type of the event contained in this union.
	/// </summary>
	[field: FieldOffset(0)]
	public EventType EventType { get; init; }
	[field: FieldOffset(4)]
	private readonly ButtonsEvent buttonsEvent;
	[field: FieldOffset(4)]
	private readonly DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent;
	[field: FieldOffset(4)]
	private readonly FastestLapEvent fastestLapEvent;
	[field: FieldOffset(4)]
	private readonly FlashbackEvent flashbackEvent;
	[field: FieldOffset(4)]
	private readonly OvertakeEvent overtakeEvent;
	[field: FieldOffset(4)]
	private readonly PenaltyEvent penaltyEvent;
	[field: FieldOffset(4)]
	private readonly RaceWinnerEvent raceWinnerEvent;
	[field: FieldOffset(4)]
	private readonly RetirementEvent retirementEvent;
	[field: FieldOffset(4)]
	private readonly SpeedTrapEvent speedTrapEvent;
	[field: FieldOffset(4)]
	private readonly StartLightsEvent startLightsEvent;
	[field: FieldOffset(4)]
	private readonly StopGoPenaltyServedEvent stopGoPenaltyServedEvent;
	[field: FieldOffset(4)]
	private readonly TeamMateInPitsEvent teamMateInPitsEvent;
	[field: FieldOffset(4)]
	private readonly CollisionEvent collisionEvent;
	[field: FieldOffset(4)]
	private readonly SafetyCarEvent safetyCarEvent;
	[field: FieldOffset(4)]
	private readonly DrsDisabledEvent drsDisabledEvent;

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="ButtonsEvent"/>.
	/// </summary>
	/// <param name="buttonsEvent">The buttons event data.</param>
	public EventDetails(ButtonsEvent buttonsEvent) => (this.buttonsEvent, EventType) = (buttonsEvent, EventType.ButtonStatus);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="DriveThroughPenaltyServedEvent"/>.
	/// </summary>
	/// <param name="driveThroughPenaltyServedEvent">The drive through penalty served event data.</param>
	public EventDetails(DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent) => (this.driveThroughPenaltyServedEvent, EventType) = (driveThroughPenaltyServedEvent, EventType.DriveThroughServed);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="FastestLapEvent"/>.
	/// </summary>
	/// <param name="fastestLapEvent">The fastest lap event data.</param>
	public EventDetails(FastestLapEvent fastestLapEvent) => (this.fastestLapEvent, EventType) = (fastestLapEvent, EventType.FastestLap);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="FlashbackEvent"/>.
	/// </summary>
	/// <param name="flashbackEvent">The flashback event data.</param>
	public EventDetails(FlashbackEvent flashbackEvent) => (this.flashbackEvent, EventType) = (flashbackEvent, EventType.Flashback);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with an <see cref="OvertakeEvent"/>.
	/// </summary>
	/// <param name="overtakeEvent">The overtake event data.</param>
	public EventDetails(OvertakeEvent overtakeEvent) => (this.overtakeEvent, EventType) = (overtakeEvent, EventType.Overtake);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="PenaltyEvent"/>.
	/// </summary>
	/// <param name="penaltyEvent">The penalty event data.</param>
	public EventDetails(PenaltyEvent penaltyEvent) => (this.penaltyEvent, EventType) = (penaltyEvent, EventType.PenaltyIssued);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="RaceWinnerEvent"/>.
	/// </summary>
	/// <param name="raceWinnerEvent">The race winner event data.</param>
	public EventDetails(RaceWinnerEvent raceWinnerEvent) => (this.raceWinnerEvent, EventType) = (raceWinnerEvent, EventType.RaceWinner);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="RetirementEvent"/>.
	/// </summary>
	/// <param name="retirementEvent">The retirement event data.</param>
	public EventDetails(RetirementEvent retirementEvent) => (this.retirementEvent, EventType) = (retirementEvent, EventType.Retirement);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="SpeedTrapEvent"/>.
	/// </summary>
	/// <param name="speedTrapEvent">The speed trap event data.</param>
	public EventDetails(SpeedTrapEvent speedTrapEvent) => (this.speedTrapEvent, EventType) = (speedTrapEvent, EventType.SpeedTrapTriggered);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="StartLightsEvent"/>.
	/// </summary>
	/// <param name="startLightsEvent">The start lights event data.</param>
	public EventDetails(StartLightsEvent startLightsEvent) => (this.startLightsEvent, EventType) = (startLightsEvent, EventType.StartLights);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="StopGoPenaltyServedEvent"/>.
	/// </summary>
	/// <param name="stopGoPenaltyServedEvent">The stop-go penalty served event data.</param>
	public EventDetails(StopGoPenaltyServedEvent stopGoPenaltyServedEvent) => (this.stopGoPenaltyServedEvent, EventType) = (stopGoPenaltyServedEvent, EventType.StopGoServed);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="TeamMateInPitsEvent"/>.
	/// </summary>
	/// <param name="teamMateInPitsEvent">The team mate in pits event data.</param>
	public EventDetails(TeamMateInPitsEvent teamMateInPitsEvent) => (this.teamMateInPitsEvent, EventType) = (teamMateInPitsEvent, EventType.TeamMateInPits);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="CollisionEvent"/>.
	/// </summary>
	/// <param name="collisionEvent">The collision event data.</param>
	public EventDetails(CollisionEvent collisionEvent) => (this.collisionEvent, EventType) = (collisionEvent, EventType.Collision);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="SafetyCarEvent"/>.
	/// </summary>
	/// <param name="safetyCarEvent">The safety car event data.</param>
	public EventDetails(SafetyCarEvent safetyCarEvent) => (this.safetyCarEvent, EventType) = (safetyCarEvent, EventType.SafetyCar);

	/// <summary>
	/// Initializes a new instance of the <see cref="EventDetails"/> struct with a <see cref="DrsDisabledEvent"/>.
	/// </summary>
	/// <param name="drsDisabledEvent">The DRS disabled event data.</param>
	public EventDetails(DrsDisabledEvent drsDisabledEvent) => (this.drsDisabledEvent, EventType) = (drsDisabledEvent, EventType.DRSDisabled);

	/// <summary>
	/// Tries to get the <see cref="ButtonsEvent"/> from this union.
	/// </summary>
	/// <param name="buttonsEvent">When this method returns, contains the buttons event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.ButtonStatus"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetButtonsEvent(out ButtonsEvent buttonsEvent)
	{
		var isRightEvent = EventType == EventType.ButtonStatus;
		buttonsEvent = isRightEvent ? this.buttonsEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="DriveThroughPenaltyServedEvent"/> from this union.
	/// </summary>
	/// <param name="driveThroughPenaltyServedEvent">When this method returns, contains the drive through penalty served event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.DriveThroughServed"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetDriveThroughPenaltyServedEvent(out DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent)
	{
		var isRightEvent = EventType == EventType.DriveThroughServed;
		driveThroughPenaltyServedEvent = isRightEvent ? this.driveThroughPenaltyServedEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="FastestLapEvent"/> from this union.
	/// </summary>
	/// <param name="fastestLapEvent">When this method returns, contains the fastest lap event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.FastestLap"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetFastestLapEvent(out FastestLapEvent fastestLapEvent)
	{
		var isRightEvent = EventType == EventType.FastestLap;
		fastestLapEvent = isRightEvent ? this.fastestLapEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="FlashbackEvent"/> from this union.
	/// </summary>
	/// <param name="flashbackEvent">When this method returns, contains the flashback event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.Flashback"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetFlashbackEvent(out FlashbackEvent flashbackEvent)
	{
		var isRightEvent = EventType == EventType.Flashback;
		flashbackEvent = isRightEvent ? this.flashbackEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="OvertakeEvent"/> from this union.
	/// </summary>
	/// <param name="overtakeEvent">When this method returns, contains the overtake event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.Overtake"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetOvertakeEvent(out OvertakeEvent overtakeEvent)
	{
		var isRightEvent = EventType == EventType.Overtake;
		overtakeEvent = isRightEvent ? this.overtakeEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="PenaltyEvent"/> from this union.
	/// </summary>
	/// <param name="penaltyEvent">When this method returns, contains the penalty event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.PenaltyIssued"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetPenaltyEvent(out PenaltyEvent penaltyEvent)
	{
		var isRightEvent = EventType == EventType.PenaltyIssued;
		penaltyEvent = isRightEvent ? this.penaltyEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="RaceWinnerEvent"/> from this union.
	/// </summary>
	/// <param name="raceWinnerEvent">When this method returns, contains the race winner event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.RaceWinner"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetRaceWinnerEvent(out RaceWinnerEvent raceWinnerEvent)
	{
		var isRightEvent = EventType == EventType.RaceWinner;
		raceWinnerEvent = isRightEvent ? this.raceWinnerEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="RetirementEvent"/> from this union.
	/// </summary>
	/// <param name="retirementEvent">When this method returns, contains the retirement event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.Retirement"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetRetirementEvent(out RetirementEvent retirementEvent)
	{
		var isRightEvent = EventType == EventType.Retirement;
		retirementEvent = isRightEvent ? this.retirementEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="SpeedTrapEvent"/> from this union.
	/// </summary>
	/// <param name="speedTrapEvent">When this method returns, contains the speed trap event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.SpeedTrapTriggered"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetSpeedTrapEvent(out SpeedTrapEvent speedTrapEvent)
	{
		var isRightEvent = EventType == EventType.SpeedTrapTriggered;
		speedTrapEvent = isRightEvent ? this.speedTrapEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="StartLightsEvent"/> from this union.
	/// </summary>
	/// <param name="startLightsEvent">When this method returns, contains the start lights event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.StartLights"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetStartLightsEvent(out StartLightsEvent startLightsEvent)
	{
		var isRightEvent = EventType == EventType.StartLights;
		startLightsEvent = isRightEvent ? this.startLightsEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="StopGoPenaltyServedEvent"/> from this union.
	/// </summary>
	/// <param name="stopGoPenaltyServedEvent">When this method returns, contains the stop-go penalty served event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.StopGoServed"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetStopGoPenaltyServedEvent(out StopGoPenaltyServedEvent stopGoPenaltyServedEvent)
	{
		var isRightEvent = EventType == EventType.StopGoServed;
		stopGoPenaltyServedEvent = isRightEvent ? this.stopGoPenaltyServedEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="TeamMateInPitsEvent"/> from this union.
	/// </summary>
	/// <param name="teamMateInPitsEvent">When this method returns, contains the team mate in pits event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.TeamMateInPits"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetTeamMateInPitsEvent(out TeamMateInPitsEvent teamMateInPitsEvent)
	{
		var isRightEvent = EventType == EventType.TeamMateInPits;
		teamMateInPitsEvent = isRightEvent ? this.teamMateInPitsEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="CollisionEvent"/> from this union.
	/// </summary>
	/// <param name="collisionEvent">When this method returns, contains the collision event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.Collision"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetCollisionEvent(out CollisionEvent collisionEvent)
	{
		var isRightEvent = EventType == EventType.Collision;
		collisionEvent = isRightEvent ? this.collisionEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="SafetyCarEvent"/> from this union.
	/// </summary>
	/// <param name="safetyCarEvent">When this method returns, contains the safety car event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.SafetyCar"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetSafetyCarEvent(out SafetyCarEvent safetyCarEvent)
	{
		var isRightEvent = EventType == EventType.SafetyCar;
		safetyCarEvent = isRightEvent ? this.safetyCarEvent : default;
		return isRightEvent;
	}

	/// <summary>
	/// Tries to get the <see cref="DrsDisabledEvent"/> from this union.
	/// </summary>
	/// <param name="drsDisabledEvent">When this method returns, contains the DRS disabled event if the event type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the event type is <see cref="EventType.DRSDisabled"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetDrsDisabledEvent(out DrsDisabledEvent drsDisabledEvent)
	{
		var isRightEvent = EventType == EventType.DRSDisabled;
		drsDisabledEvent = isRightEvent ? this.drsDisabledEvent : default;
		return isRightEvent;
	}

	static EventDetails IByteParsable<EventDetails>.Parse(ref BytesReader reader)
	{
		var eventType = reader.GetNextUIntEnum<EventType>();

		return eventType switch
		{
			EventType.FastestLap => reader.GetNextObject<FastestLapEvent>(),
			EventType.Retirement => reader.GetNextObject<RetirementEvent>(),
			EventType.TeamMateInPits => reader.GetNextObject<TeamMateInPitsEvent>(),
			EventType.RaceWinner => reader.GetNextObject<RaceWinnerEvent>(),
			EventType.PenaltyIssued => reader.GetNextObject<PenaltyEvent>(),
			EventType.SpeedTrapTriggered => reader.GetNextObject<SpeedTrapEvent>(),
			EventType.StartLights => reader.GetNextObject<StartLightsEvent>(),
			EventType.DriveThroughServed => reader.GetNextObject<DriveThroughPenaltyServedEvent>(),
			EventType.StopGoServed => reader.GetNextObject<StopGoPenaltyServedEvent>(),
			EventType.Flashback => reader.GetNextObject<FlashbackEvent>(),
			EventType.ButtonStatus => reader.GetNextObject<ButtonsEvent>(),
			EventType.Overtake => reader.GetNextObject<OvertakeEvent>(),
			EventType.SafetyCar => reader.GetNextObject<SafetyCarEvent>(),
			EventType.Collision => reader.GetNextObject<CollisionEvent>(),
			EventType.ChequeredFlag => new EventDetails { EventType = eventType },
			EventType.DRSEnabled => new EventDetails { EventType = eventType },
			EventType.DRSDisabled => reader.GetNextObject<DrsDisabledEvent>(),
			EventType.LightsOut => new EventDetails { EventType = eventType },
			EventType.SessionStarted => new EventDetails { EventType = eventType },
			EventType.SessionEnded => new EventDetails { EventType = eventType },
			EventType.RedFlag => new EventDetails { EventType = eventType },
			_ => new EventDetails { EventType = eventType },
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(EventType);

		IByteWritable? byteWritable = EventType switch
		{
			EventType.FastestLap => fastestLapEvent,
			EventType.Retirement => retirementEvent,
			EventType.TeamMateInPits => teamMateInPitsEvent,
			EventType.RaceWinner => raceWinnerEvent,
			EventType.PenaltyIssued => penaltyEvent,
			EventType.SpeedTrapTriggered => speedTrapEvent,
			EventType.StartLights => startLightsEvent,
			EventType.DriveThroughServed => driveThroughPenaltyServedEvent,
			EventType.StopGoServed => stopGoPenaltyServedEvent,
			EventType.Flashback => flashbackEvent,
			EventType.ButtonStatus => buttonsEvent,
			EventType.Overtake => overtakeEvent,
			EventType.SafetyCar => safetyCarEvent,
			EventType.Collision => collisionEvent,
			EventType.DRSDisabled => drsDisabledEvent,
			_ => null,
		};

		byteWritable?.WriteBytes(ref writer);
	}

	/// <summary>
	/// Implicitly converts a <see cref="ButtonsEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="buttonsEvent">The buttons event to convert.</param>
	public static implicit operator EventDetails(ButtonsEvent buttonsEvent) => new(buttonsEvent);

	/// <summary>
	/// Implicitly converts a <see cref="DriveThroughPenaltyServedEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="driveThroughPenaltyServedEvent">The drive through penalty served event to convert.</param>
	public static implicit operator EventDetails(DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent) => new(driveThroughPenaltyServedEvent);

	/// <summary>
	/// Implicitly converts a <see cref="FastestLapEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="fastestLapEvent">The fastest lap event to convert.</param>
	public static implicit operator EventDetails(FastestLapEvent fastestLapEvent) => new(fastestLapEvent);

	/// <summary>
	/// Implicitly converts a <see cref="FlashbackEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="flashbackEvent">The flashback event to convert.</param>
	public static implicit operator EventDetails(FlashbackEvent flashbackEvent) => new(flashbackEvent);

	/// <summary>
	/// Implicitly converts an <see cref="OvertakeEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="overtakeEvent">The overtake event to convert.</param>
	public static implicit operator EventDetails(OvertakeEvent overtakeEvent) => new(overtakeEvent);

	/// <summary>
	/// Implicitly converts a <see cref="PenaltyEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="penaltyEvent">The penalty event to convert.</param>
	public static implicit operator EventDetails(PenaltyEvent penaltyEvent) => new(penaltyEvent);

	/// <summary>
	/// Implicitly converts a <see cref="RaceWinnerEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="raceWinnerEvent">The race winner event to convert.</param>
	public static implicit operator EventDetails(RaceWinnerEvent raceWinnerEvent) => new(raceWinnerEvent);

	/// <summary>
	/// Implicitly converts a <see cref="RetirementEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="retirementEvent">The retirement event to convert.</param>
	public static implicit operator EventDetails(RetirementEvent retirementEvent) => new(retirementEvent);

	/// <summary>
	/// Implicitly converts a <see cref="SpeedTrapEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="speedTrapEvent">The speed trap event to convert.</param>
	public static implicit operator EventDetails(SpeedTrapEvent speedTrapEvent) => new(speedTrapEvent);

	/// <summary>
	/// Implicitly converts a <see cref="StartLightsEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="startLightsEvent">The start lights event to convert.</param>
	public static implicit operator EventDetails(StartLightsEvent startLightsEvent) => new(startLightsEvent);

	/// <summary>
	/// Implicitly converts a <see cref="StopGoPenaltyServedEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="stopGoPenaltyServedEvent">The stop-go penalty served event to convert.</param>
	public static implicit operator EventDetails(StopGoPenaltyServedEvent stopGoPenaltyServedEvent) => new(stopGoPenaltyServedEvent);

	/// <summary>
	/// Implicitly converts a <see cref="TeamMateInPitsEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="teamMateInPitsEvent">The team mate in pits event to convert.</param>
	public static implicit operator EventDetails(TeamMateInPitsEvent teamMateInPitsEvent) => new(teamMateInPitsEvent);

	/// <summary>
	/// Implicitly converts a <see cref="CollisionEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="collisionEvent">The collision event to convert.</param>
	public static implicit operator EventDetails(CollisionEvent collisionEvent) => new(collisionEvent);

	/// <summary>
	/// Implicitly converts a <see cref="SafetyCarEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="safetyCarEvent">The safety car event to convert.</param>
	public static implicit operator EventDetails(SafetyCarEvent safetyCarEvent) => new(safetyCarEvent);

	/// <summary>
	/// Implicitly converts a <see cref="DrsDisabledEvent"/> to an <see cref="EventDetails"/>.
	/// </summary>
	/// <param name="drsDisabledEvent">The DRS disabled event to convert.</param>
	public static implicit operator EventDetails(DrsDisabledEvent drsDisabledEvent) => new(drsDisabledEvent);
}
