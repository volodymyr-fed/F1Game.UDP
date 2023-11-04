using System.Runtime.Serialization;

namespace F1Game.UDP;

[Serializable]
public sealed class NotEnoughBytesException : Exception
{
	NotEnoughBytesException(SerializationInfo info, StreamingContext context) : base(info, context) { }

	public NotEnoughBytesException(int requiredLength, int actualLength, string packetType)
		: base($"There is not enough bytes to read {packetType}. Required count: {requiredLength}, actual count: {actualLength}.") { }
}
