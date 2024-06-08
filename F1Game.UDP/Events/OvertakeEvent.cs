namespace F1Game.UDP.Events;

public readonly record struct OvertakeEvent() : IEventDetails, IByteParsable<OvertakeEvent>, IByteWritable
{
	public byte OvertakingVehicleIdx { get; init; } // Vehicle index of the vehicle overtaking
	public byte BeingOvertakenVehicleIdx { get; init; }  // Vehicle index of the vehicle being overtaken

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
