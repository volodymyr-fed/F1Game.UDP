using F1Game.UDP.Data;
using F1Game.UDP.Events;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet gives details of events that happen during the course of a session.
/// <para>Frequency: When the event occurs</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct EventDataPacket() : IByteParsable<EventDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 45;

	public PacketHeader Header { get; init; }
	public EventDetails EventDetails { get; init; }

	static EventDataPacket IByteParsable<EventDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			EventDetails = reader.GetNextObject<EventDetails>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(EventDetails);
	}
}
