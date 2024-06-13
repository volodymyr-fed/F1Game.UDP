using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
public readonly record struct SafetyCarEvent() : IByteParsable<SafetyCarEvent>, IByteWritable
{
	public SafetyCarStatus SafetyCarType { get; init; }
	public SafetyCarEventType EventType { get; init; }// 0 = Deployed, 1 = Returning, 2 = Returned 3 = Resume Race

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
