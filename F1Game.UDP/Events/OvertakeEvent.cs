namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct OvertakeEvent() : IByteParsable<OvertakeEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 2;

	/// <summary>
	/// Vehicle index of the vehicle overtaking
	/// </summary>
	public byte OvertakingVehicleIdx { get; init; }
	/// <summary>
	/// Vehicle index of the vehicle being overtaken
	/// </summary>
	public byte BeingOvertakenVehicleIdx { get; init; }

	static OvertakeEvent IByteParsable<OvertakeEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			OvertakingVehicleIdx = reader.GetNextByte(),
			BeingOvertakenVehicleIdx = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(OvertakingVehicleIdx);
		writer.Write(BeingOvertakenVehicleIdx);
	}
}
