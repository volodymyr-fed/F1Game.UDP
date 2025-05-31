using F1Game.UDP.Data;
using F1Game.UDP.Events;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 45)]
public readonly record struct EventDataPacket() : IByteParsable<EventDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 45;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	public EventDetails EventDetails { get; init; }

	static EventDataPacket IByteParsable<EventDataPacket>.Parse(ref BytesReader reader)
	{
		var packet = reader.GetNextObject<PacketHeader>();
		var eventType = reader.GetNextUIntEnum<EventType>();

		return new()
		{
			Header = packet,
			EventDetails = eventType switch
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
				EventType.DRSDisabled => new EventDetails { EventType = eventType },
				EventType.LightsOut => new EventDetails { EventType = eventType },
				EventType.SessionStarted => new EventDetails { EventType = eventType },
				EventType.SessionEnded => new EventDetails { EventType = eventType },
				EventType.RedFlag => new EventDetails { EventType = eventType },
				_ => new EventDetails { EventType = eventType },
			}
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(EventDetails);
	}
}
