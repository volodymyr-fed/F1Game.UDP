using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Packets;

namespace F1Game.UDP;

public abstract class ParsingException(string message) : Exception(message);

public sealed class NotEnoughBytesException(int requiredSize, int inputSize, Type typeToParse)
	: ParsingException($"There is not enough bytes to parse {typeToParse.Name}. Required size: {requiredSize}, input size: {inputSize}.")
{
	public Type TypeToParse => typeToParse;
	public int RequiredSize => requiredSize;
	public int InputSize => inputSize;
}

public sealed class InvalidEventTypeException(EventType eventType)
	: ParsingException($"Invalid data. Event type {eventType} in {nameof(EventDataPacket)} does not exist in enum {nameof(EventType)}.")
{
	public EventType EventType => eventType;
}

public sealed class InvalidPacketTypeException(PacketType packetType)
	: ParsingException($"Invalid data. Packet type {packetType} does not exist in enum {nameof(PacketType)}.")
{
	public PacketType PacketType => packetType;
}
