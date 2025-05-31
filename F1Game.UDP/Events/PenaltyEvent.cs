using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct PenaltyEvent() : IByteParsable<PenaltyEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 7;

	/// <summary>
	/// Penalty type
	/// </summary>
	public PenaltyType PenaltyType { get; init; }
	/// <summary>
	/// Infringement type
	/// </summary>
	public InfringementType InfringementType { get; init; }
	/// <summary>
	/// Vehicle index of the car the penalty is applied to
	/// </summary>
	public byte VehicleIdx { get; init; }
	/// <summary>
	/// Vehicle index of the other car involved
	/// </summary>
	public byte OtherVehicleIdx { get; init; }
	/// <summary>
	/// Time gained, or time spent doing action in seconds
	/// </summary>
	public byte Time { get; init; }
	/// <summary>
	/// Lap the penalty occurred on
	/// </summary>
	public byte LapNum { get; init; }
	/// <summary>
	/// Number of places gained by this
	/// </summary>
	public byte PlacesGained { get; init; }

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
