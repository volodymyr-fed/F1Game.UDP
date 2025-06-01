using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct RetirementEvent() : IByteParsable<RetirementEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 2;

	/// <summary>
	/// Vehicle index of car retiring
	/// </summary>
	public byte VehicleIdx { get; init; }

	public ResultReason Reason { get; init; }

	static RetirementEvent IByteParsable<RetirementEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
			Reason = reader.GetNextEnum<ResultReason>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(VehicleIdx);
		writer.WriteEnum(Reason);
	}
}
