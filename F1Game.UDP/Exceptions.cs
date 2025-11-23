using F1Game.UDP.Enums;

namespace F1Game.UDP;

/// <summary>
/// Base exception for parsing errors in F1 game UDP packets.
/// </summary>
/// <param name="message">The error message that explains the reason for the exception.</param>
public abstract class ParsingException(string message) : Exception(message);

/// <summary>
/// Exception thrown when there are not enough bytes to parse a specific type.
/// </summary>
/// <param name="requiredSize">The number of bytes required to parse the type.</param>
/// <param name="inputSize">The number of bytes available in the input.</param>
/// <param name="typeToParse">The type that was attempted to be parsed.</param>
public sealed class NotEnoughBytesException(int requiredSize, int inputSize, Type typeToParse)
	: ParsingException($"There is not enough bytes to parse {typeToParse.Name}. Required size: {requiredSize}, input size: {inputSize}.")
{
	/// <summary>
    /// The type that was attempted to be parsed.
    /// </summary>
	public Type TypeToParse => typeToParse;
	/// <summary>
    /// The number of bytes required to parse the type.
    /// </summary>
	public int RequiredSize => requiredSize;
	/// <summary>
    /// The number of bytes available in the input.
    /// </summary>
	public int InputSize => inputSize;
}

/// <summary>
/// Exception thrown when an invalid packet type is encountered.
/// </summary>
/// <param name="packetType">The invalid packet type that was encountered.</param>
public sealed class InvalidPacketTypeException(PacketType packetType)
	: ParsingException($"Invalid data. Packet type {packetType} does not exist in enum {nameof(PacketType)}.")
{
	/// <summary>
    /// The invalid packet type that was encountered.
    /// </summary>
	public PacketType PacketType => packetType;
}
