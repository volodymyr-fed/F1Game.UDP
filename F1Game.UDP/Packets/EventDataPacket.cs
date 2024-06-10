using F1Game.UDP.Data;
using F1Game.UDP.Events;

namespace F1Game.UDP.Packets;

public sealed record EventDataPacket() : IPacket, IByteParsable<EventDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 45;

	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public EventType EventType { get; init; } // Event string code, see below 4 chars
	public IEventDetails? EventDetails { get; init; } // Event details - should be interpreted differently

	static EventDataPacket IByteParsable<EventDataPacket>.Parse(ref BytesReader reader)
	{
		EventType eventType;

		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			EventType = eventType = reader.GetNextUIntEnum<EventType>(),
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
				EventType.ChequeredFlag => null,
				EventType.DRSEnabled => null,
				EventType.DRSDisabled => null,
				EventType.LightsOut => null,
				EventType.SessionStarted => null,
				EventType.SessionEnded => null,
				EventType.RedFlag => null,
				_ => throw new InvalidEventTypeException(eventType),
			}
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.WriteEnum(EventType);

		if (EventDetails is IByteWritable byteWritable)
			writer.Write(byteWritable);
	}
}
