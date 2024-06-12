using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 7)]
public readonly record struct PenaltyEvent() : IByteParsable<PenaltyEvent>, IByteWritable
{
	public PenaltyType PenaltyType { get; init; } // Penalty type – see Appendices
	public InfringementType InfringementType { get; init; } // Infringement type – see Appendices
	public byte VehicleIdx { get; init; } // Vehicle index of the car the penalty is applied to
	public byte OtherVehicleIdx { get; init; } // Vehicle index of the other car involved
	public byte Time { get; init; } // Time gained, or time spent doing action in seconds
	public byte LapNum { get; init; } // Lap the penalty occurred on
	public byte PlacesGained { get; init; } // Number of places gained by this

	static PenaltyEvent IByteParsable<PenaltyEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			PenaltyType = reader.GetNextEnum<PenaltyType>(),
			InfringementType = reader.GetNextEnum<InfringementType>(),
			VehicleIdx = reader.GetNextByte(),
			OtherVehicleIdx = reader.GetNextByte(),
			Time = reader.GetNextByte(),
			LapNum = reader.GetNextByte(),
			PlacesGained = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(PenaltyType);
		writer.WriteEnum(InfringementType);
		writer.Write(VehicleIdx);
		writer.Write(OtherVehicleIdx);
		writer.Write(Time);
		writer.Write(LapNum);
		writer.Write(PlacesGained);
	}
}
