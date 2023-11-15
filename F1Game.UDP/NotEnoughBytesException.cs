namespace F1Game.UDP;

public sealed class NotEnoughBytesException(int requiredLength, int actualLength, string packetType)
	: Exception($"There is not enough bytes to read {packetType}. Required count: {requiredLength}, actual count: {actualLength}.")
{
}
