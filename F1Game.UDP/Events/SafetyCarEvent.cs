using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct SafetyCarEvent() : IByteParsable<SafetyCarEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 2;

	/// <summary>
	/// Safety car type
	/// </summary>
	public SafetyCarStatus SafetyCarType { get; init; }
	/// <summary>
	/// Safety car event type
	/// </summary>
	public SafetyCarEventType EventType { get; init; }

	static SafetyCarEvent IByteParsable<SafetyCarEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			SafetyCarType= reader.GetNextEnum<SafetyCarStatus>(),
			EventType = reader.GetNextEnum<SafetyCarEventType>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(SafetyCarType);
		writer.WriteEnum(EventType);
	}
}
