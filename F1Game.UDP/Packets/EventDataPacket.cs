using F1Game.UDP.Data;
using F1Game.UDP.Events;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 45)]
public readonly record struct EventDataPacket() : IByteParsable<EventDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 45;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public EventDetails EventDetails { get; init; } // Event details - should be interpreted differently

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
		writer.WriteEnum(EventDetails.EventType);

		IByteWritable? byteWritable = EventDetails.EventType switch
		{
			EventType.FastestLap => EventDetails.FastestLapEvent,
			EventType.Retirement => EventDetails.RetirementEvent,
			EventType.TeamMateInPits => EventDetails.TeamMateInPitsEvent,
			EventType.RaceWinner => EventDetails.RaceWinnerEvent,
			EventType.PenaltyIssued => EventDetails.PenaltyEvent,
			EventType.SpeedTrapTriggered => EventDetails.SpeedTrapEvent,
			EventType.StartLights => EventDetails.StartLightsEvent,
			EventType.DriveThroughServed => EventDetails.DriveThroughPenaltyServedEvent,
			EventType.StopGoServed => EventDetails.StopGoPenaltyServedEvent,
			EventType.Flashback => EventDetails.FlashbackEvent,
			EventType.ButtonStatus => EventDetails.ButtonsEvent,
			EventType.Overtake => EventDetails.OvertakeEvent,
			_ => null,
		};
		if (byteWritable is not null)
			writer.Write(byteWritable);
	}
}
