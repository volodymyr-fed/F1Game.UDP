using F1Game.UDP.Data;
using F1Game.UDP.Events;

namespace F1Game.UDP.Packets;

public sealed record EventDataPacket : IPacket, IByteParsable<EventDataPacket>, ISizeable
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
				EventType.FastestLap => reader.GetNextObject<FastestLap>(),
				EventType.Retirement => reader.GetNextObject<Retirement>(),
				EventType.TeamMateInPits => reader.GetNextObject<TeamMateInPits>(),
				EventType.RaceWinner => reader.GetNextObject<RaceWinner>(),
				EventType.PenaltyIssued => reader.GetNextObject<Penalty>(),
				EventType.SpeedTrapTriggered => reader.GetNextObject<SpeedTrap>(),
				EventType.StartLights => reader.GetNextObject<StartLights>(),
				EventType.DriveThroughServed => reader.GetNextObject<DriveThroughPenaltyServed>(),
				EventType.StopGoServed => reader.GetNextObject<StopGoPenaltyServed>(),
				EventType.Flashback => reader.GetNextObject<Flashback>(),
				EventType.ButtonStatus => reader.GetNextObject<Buttons>(),
				EventType.Overtake => reader.GetNextObject<Overtake>(),
				_ => null,
			}
		};
	}
}
