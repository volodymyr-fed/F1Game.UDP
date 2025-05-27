namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 26)]
public readonly record struct EventDetails : IByteWritable
{
	[field: FieldOffset(0)]
	public EventType EventType { get; init; } // Event string code, see below 4 chars
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

	public EventDetails(ButtonsEvent buttonsEvent) => (this.buttonsEvent, EventType) = (buttonsEvent, EventType.ButtonStatus);
	public EventDetails(DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent) => (this.driveThroughPenaltyServedEvent, EventType) = (driveThroughPenaltyServedEvent, EventType.DriveThroughServed);
	public EventDetails(FastestLapEvent fastestLapEvent) => (this.fastestLapEvent, EventType) = (fastestLapEvent, EventType.FastestLap);
	public EventDetails(FlashbackEvent flashbackEvent) => (this.flashbackEvent, EventType) = (flashbackEvent, EventType.Flashback);
	public EventDetails(OvertakeEvent overtakeEvent) => (this.overtakeEvent, EventType) = (overtakeEvent, EventType.Overtake);
	public EventDetails(PenaltyEvent penaltyEvent) => (this.penaltyEvent, EventType) = (penaltyEvent, EventType.PenaltyIssued);
	public EventDetails(RaceWinnerEvent raceWinnerEvent) => (this.raceWinnerEvent, EventType) = (raceWinnerEvent, EventType.RaceWinner);
	public EventDetails(RetirementEvent retirementEvent) => (this.retirementEvent, EventType) = (retirementEvent, EventType.Retirement);
	public EventDetails(SpeedTrapEvent speedTrapEvent) => (this.speedTrapEvent, EventType) = (speedTrapEvent, EventType.SpeedTrapTriggered);
	public EventDetails(StartLightsEvent startLightsEvent) => (this.startLightsEvent, EventType) = (startLightsEvent, EventType.StartLights);
	public EventDetails(StopGoPenaltyServedEvent stopGoPenaltyServedEvent) => (this.stopGoPenaltyServedEvent, EventType) = (stopGoPenaltyServedEvent, EventType.StopGoServed);
	public EventDetails(TeamMateInPitsEvent teamMateInPitsEvent) => (this.teamMateInPitsEvent, EventType) = (teamMateInPitsEvent, EventType.TeamMateInPits);
	public EventDetails(CollisionEvent collisionEvent) => (this.collisionEvent, EventType) = (collisionEvent, EventType.Collision);
	public EventDetails(SafetyCarEvent safetyCarEvent) => (this.safetyCarEvent, EventType) = (safetyCarEvent, EventType.SafetyCar);

	public bool TryGetButtonsEvent(out ButtonsEvent buttonsEvent)
	{
		var isRightEvent = EventType == EventType.ButtonStatus;
		buttonsEvent = isRightEvent ? this.buttonsEvent : default;
		return isRightEvent;
	}

	public bool TryGetDriveThroughPenaltyServedEvent(out DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent)
	{
		var isRightEvent = EventType == EventType.DriveThroughServed;
		driveThroughPenaltyServedEvent = isRightEvent ? this.driveThroughPenaltyServedEvent : default;
		return isRightEvent;
	}

	public bool TryGetFastestLapEvent(out FastestLapEvent fastestLapEvent)
	{
		var isRightEvent = EventType == EventType.FastestLap;
		fastestLapEvent = isRightEvent ? this.fastestLapEvent : default;
		return isRightEvent;
	}

	public bool TryGetFlashbackEvent(out FlashbackEvent flashbackEvent)
	{
		var isRightEvent = EventType == EventType.Flashback;
		flashbackEvent = isRightEvent ? this.flashbackEvent : default;
		return isRightEvent;
	}

	public bool TryGetOvertakeEvent(out OvertakeEvent overtakeEvent)
	{
		var isRightEvent = EventType == EventType.Overtake;
		overtakeEvent = isRightEvent ? this.overtakeEvent : default;
		return isRightEvent;
	}

	public bool TryGetPenaltyEvent(out PenaltyEvent penaltyEvent)
	{
		var isRightEvent = EventType == EventType.PenaltyIssued;
		penaltyEvent = isRightEvent ? this.penaltyEvent : default;
		return isRightEvent;
	}

	public bool TryGetRaceWinnerEvent(out RaceWinnerEvent raceWinnerEvent)
	{
		var isRightEvent = EventType == EventType.RaceWinner;
		raceWinnerEvent = isRightEvent ? this.raceWinnerEvent : default;
		return isRightEvent;
	}

	public bool TryGetRetirementEvent(out RetirementEvent retirementEvent)
	{
		var isRightEvent = EventType == EventType.Retirement;
		retirementEvent = isRightEvent ? this.retirementEvent : default;
		return isRightEvent;
	}

	public bool TryGetSpeedTrapEvent(out SpeedTrapEvent speedTrapEvent)
	{
		var isRightEvent = EventType == EventType.SpeedTrapTriggered;
		speedTrapEvent = isRightEvent ? this.speedTrapEvent : default;
		return isRightEvent;
	}

	public bool TryGetStartLightsEvent(out StartLightsEvent startLightsEvent)
	{
		var isRightEvent = EventType == EventType.StartLights;
		startLightsEvent = isRightEvent ? this.startLightsEvent : default;
		return isRightEvent;
	}

	public bool TryGetStopGoPenaltyServedEvent(out StopGoPenaltyServedEvent stopGoPenaltyServedEvent)
	{
		var isRightEvent = EventType == EventType.StopGoServed;
		stopGoPenaltyServedEvent = isRightEvent ? this.stopGoPenaltyServedEvent : default;
		return isRightEvent;
	}

	public bool TryGetTeamMateInPitsEvent(out TeamMateInPitsEvent teamMateInPitsEvent)
	{
		var isRightEvent = EventType == EventType.TeamMateInPits;
		teamMateInPitsEvent = isRightEvent ? this.teamMateInPitsEvent : default;
		return isRightEvent;
	}

	public bool TryGetCollisionEvent(out CollisionEvent collisionEvent)
	{
		var isRightEvent = EventType == EventType.Collision;
		collisionEvent = isRightEvent ? this.collisionEvent : default;
		return isRightEvent;
	}

	public bool TryGetSafetyCarEvent(out SafetyCarEvent safetyCarEvent)
	{
		var isRightEvent = EventType == EventType.SafetyCar;
		safetyCarEvent = isRightEvent ? this.safetyCarEvent : default;
		return isRightEvent;
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
			_ => null,
		};

		byteWritable?.WriteBytes(ref writer);
	}

	public static implicit operator EventDetails(ButtonsEvent buttonsEvent) => new(buttonsEvent);
	public static implicit operator EventDetails(DriveThroughPenaltyServedEvent driveThroughPenaltyServedEvent) => new(driveThroughPenaltyServedEvent);
	public static implicit operator EventDetails(FastestLapEvent fastestLapEvent) => new(fastestLapEvent);
	public static implicit operator EventDetails(FlashbackEvent flashbackEvent) => new(flashbackEvent);
	public static implicit operator EventDetails(OvertakeEvent overtakeEvent) => new(overtakeEvent);
	public static implicit operator EventDetails(PenaltyEvent penaltyEvent) => new(penaltyEvent);
	public static implicit operator EventDetails(RaceWinnerEvent raceWinnerEvent) => new(raceWinnerEvent);
	public static implicit operator EventDetails(RetirementEvent retirementEvent) => new(retirementEvent);
	public static implicit operator EventDetails(SpeedTrapEvent speedTrapEvent) => new(speedTrapEvent);
	public static implicit operator EventDetails(StartLightsEvent startLightsEvent) => new(startLightsEvent);
	public static implicit operator EventDetails(StopGoPenaltyServedEvent stopGoPenaltyServedEvent) => new(stopGoPenaltyServedEvent);
	public static implicit operator EventDetails(TeamMateInPitsEvent teamMateInPitsEvent) => new(teamMateInPitsEvent);
	public static implicit operator EventDetails(CollisionEvent collisionEvent) => new(collisionEvent);
	public static implicit operator EventDetails(SafetyCarEvent safetyCarEvent) => new(safetyCarEvent);
}
