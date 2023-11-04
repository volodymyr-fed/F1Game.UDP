using F1Game.UDP.Enums;

namespace F1Game.UDP.Events;

public sealed record Penalty : IEventDetails, IByteParsable<Penalty>
{
	public PenaltyType PenaltyType { get; init; } // Penalty type – see Appendices
	public InfringementType InfringementType { get; init; } // Infringement type – see Appendices
	public byte VehicleIdx { get; init; } // Vehicle index of the car the penalty is applied to
	public byte OtherVehicleIdx { get; init; } // Vehicle index of the other car involved
	public byte Time { get; init; } // Time gained, or time spent doing action in seconds
	public byte LapNum { get; init; } // Lap the penalty occurred on
	public byte PlacesGained { get; init; } // Number of places gained by this

	static Penalty IByteParsable<Penalty>.Parse(ref BytesReader reader)
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
}
