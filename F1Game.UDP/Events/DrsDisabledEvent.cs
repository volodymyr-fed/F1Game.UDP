using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

/// <summary>
/// Represents a DRS disabled event in the F1 game.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct DrsDisabledEvent() : IByteParsable<DrsDisabledEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 1;

	/// <summary>
	/// Reason why DRS was disabled.
	/// </summary>
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
