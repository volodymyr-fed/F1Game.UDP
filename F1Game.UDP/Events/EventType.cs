namespace F1Game.UDP.Events;

/// <summary>
/// Represents the different types of events that can occur in the F1 game.
/// </summary>
public enum EventType : uint
{
	/// <summary>
    /// Sent when the session starts.
    /// </summary>
	SessionStarted = 'S' * 0x1U + 'S' * 0x100U + 'T' * 0x10000U + 'A' * 0x1000000U,
	/// <summary>
    /// Sent when the session ends.
    /// </summary>
	SessionEnded = 'S' * 0x1U + 'E' * 0x100U + 'N' * 0x10000U + 'D' * 0x1000000U,
	/// <summary>
    /// When a driver achieves the fastest lap.
    /// </summary>
	FastestLap = 'F' * 0x1U + 'T' * 0x100U + 'L' * 0x10000U + 'P' * 0x1000000U,
	/// <summary>
	/// When a driver retires.
	/// </summary>
	Retirement = 'R' * 0x1U + 'T' * 0x100U + 'M' * 0x10000U + 'T' * 0x1000000U,
	/// <summary>
	/// Race control have enabled DRS.
	/// </summary>
	DRSEnabled = 'D' * 0x1U + 'R' * 0x100U + 'S' * 0x10000U + 'E' * 0x1000000U,
	/// <summary>
    /// Race control have disabled DRS.
    /// </summary>
	DRSDisabled = 'D' * 0x1U + 'R' * 0x100U + 'S' * 0x10000U + 'D' * 0x1000000U,
	/// <summary>
	/// Your team mate has entered the pits.
	/// </summary>
	TeamMateInPits = 'T' * 0x1U + 'M' * 0x100U + 'P' * 0x10000U + 'T' * 0x1000000U,
	/// <summary>
    /// The chequered flag has been waved.
    /// </summary>
	ChequeredFlag = 'C' * 0x1U + 'H' * 0x100U + 'Q' * 0x10000U + 'F' * 0x1000000U,
	/// <summary>
    /// The race winner is announced.
    /// </summary>
	RaceWinner = 'R' * 0x1U + 'C' * 0x100U + 'W' * 0x10000U + 'N' * 0x1000000U,
	/// <summary>
    /// A penalty has been issued – details in event data.
    /// </summary>
	PenaltyIssued = 'P' * 0x1U + 'E' * 0x100U + 'N' * 0x10000U + 'A' * 0x1000000U,
	/// <summary>
    /// Speed trap has been triggered by fastest speed.
    /// </summary>
	SpeedTrapTriggered = 'S' * 0x1U + 'P' * 0x100U + 'T' * 0x10000U + 'P' * 0x1000000U,
	/// <summary>
    /// Start lights – number shown.
    /// </summary>
	StartLights = 'S' * 0x1U + 'T' * 0x100U + 'L' * 0x10000U + 'G' * 0x1000000U,
	/// <summary>
    /// Lights out.
    /// </summary>
	LightsOut = 'L' * 0x1U + 'G' * 0x100U + 'O' * 0x10000U + 'T' * 0x1000000U,
	/// <summary>
    /// Drive through penalty served.
    /// </summary>
	DriveThroughServed = 'D' * 0x1U + 'T' * 0x100U + 'S' * 0x10000U + 'V' * 0x1000000U,
	/// <summary>
    /// Stop go penalty served.
    /// </summary>
	StopGoServed = 'S' * 0x1U + 'G' * 0x100U + 'S' * 0x10000U + 'V' * 0x1000000U,
	/// <summary>
    /// Flashback activated.
    /// </summary>
	Flashback = 'F' * 0x1U + 'L' * 0x100U + 'B' * 0x10000U + 'K' * 0x1000000U,
	/// <summary>
    /// Button status changed.
    /// </summary>
	ButtonStatus = 'B' * 0x1U + 'U' * 0x100U + 'T' * 0x10000U + 'N' * 0x1000000U,
	/// <summary>
    /// Red flag shown.
    /// </summary>
	RedFlag = 'R' * 0x1U + 'D' * 0x100U + 'F' * 0x10000U + 'L' * 0x1000000U,
	/// <summary>
    /// Overtake occurred.
    /// </summary>
	Overtake = 'O' * 0x1U + 'V' * 0x100U + 'T' * 0x10000U + 'K' * 0x1000000U,
	/// <summary>
    /// Safety car event - details in event data.
    /// </summary>
	SafetyCar = 'S' * 0x1U + 'C' * 0x100U + 'A' * 0x10000U + 'R' * 0x1000000U,
	/// <summary>
    /// Collision between two vehicles has occurred.
    /// </summary>
	Collision = 'C' * 0x1U + 'O' * 0x100U + 'L' * 0x10000U + 'L' * 0x1000000U
}
