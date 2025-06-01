using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public readonly record struct LapPositionsDataPacket() : IByteParsable<LapPositionsDataPacket>, IByteWritable, ISizeable, IHaveHeader
{
	static int ISizeable.Size => 1131;

	public PacketHeader Header { get; init; }

	/// <summary>
	/// Number of laps in the data <see cref="NumberOfLaps" />
	/// </summary>
	public byte NumberOfLaps { get; init; }
	/// <summary>
	/// Index of the lap where the data starts, 0 indexed
	/// </summary>
	public byte StartingLap { get; init; }
	/// <summary>
	/// Array holding the position of the car in a given lap, 0 if no record
	/// </summary>
	public Array50<Array22<byte>> PositionsPerLapForVehicle { get; init; }

	static LapPositionsDataPacket IByteParsable<LapPositionsDataPacket>.Parse(ref BytesReader reader)
	{
		var header = reader.GetNextObject<PacketHeader>();
		var numberOfLaps = reader.GetNextByte();
		var startingLap = reader.GetNextByte();
		var positionsPerLapForVehicle = new Array50<Array22<byte>>();

		foreach (ref var positionsForVehicles in positionsPerLapForVehicle.AsSpan())
			positionsForVehicles = reader.GetNextBytes(22);

		return new()
		{
			Header = header,
			NumberOfLaps = numberOfLaps,
			StartingLap = startingLap,
			PositionsPerLapForVehicle = positionsPerLapForVehicle,
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(NumberOfLaps);
		writer.Write(StartingLap);

		foreach (var positionsForVehicles in PositionsPerLapForVehicle)
			writer.Write(positionsForVehicles.AsReadOnlySpan());
	}
}
