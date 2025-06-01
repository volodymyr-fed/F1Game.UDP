using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct DrsDisabledEvent() : IByteParsable<DrsDisabledEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	public DrsDisabledReason Reason { get; init; }

	static DrsDisabledEvent IByteParsable<DrsDisabledEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Reason = reader.GetNextEnum<DrsDisabledReason>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(Reason);
	}
}
