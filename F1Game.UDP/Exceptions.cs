using F1Game.UDP.Enums;

namespace F1Game.UDP;

public abstract class ParsingException(string message) : Exception(message);

public sealed class NotEnoughBytesException(int requiredSize, int inputSize, Type typeToParse)
	: ParsingException($"There is not enough bytes to parse {typeToParse.Name}. Required size: {requiredSize}, input size: {inputSize}.")
{
	public Type TypeToParse => typeToParse;
	public int RequiredSize => requiredSize;
	public int InputSize => inputSize;
}

public sealed class InvalidPacketTypeException(PacketType packetType)
	: ParsingException($"Invalid data. Packet type {packetType} does not exist in enum {nameof(PacketType)}.")
{
	public PacketType PacketType => packetType;
}
