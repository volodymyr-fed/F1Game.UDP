using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct LapHistoryData() : IByteParsable<LapHistoryData>, IByteWritable, ISizeable
{
	/// <inheritdoc/>
	static int ISizeable.Size => 14;

	/// <summary>
	/// Gets the lap time in milliseconds.
	/// </summary>
	public uint LapTimeInMS { get; init; }
	/// <summary>
	/// Gets the sector 1 time in milliseconds.
	/// </summary>
	public ushort Sector1TimeInMS { get; init; }
	/// <summary>
	/// Gets the sector 1 whole minute part.
	/// </summary>
	public byte Sector1TimeMinutes { get; init; }
	/// <summary>
	/// Gets the sector 2 time in milliseconds.
	/// </summary>
	public ushort Sector2TimeInMS { get; init; }
	/// <summary>
	/// Gets the sector 2 whole minute part.
	/// </summary>
	public byte Sector2TimeMinutes { get; init; }
	/// <summary>
	/// Gets the sector 3 time in milliseconds.
	/// </summary>
	public ushort Sector3TimeInMS { get; init; }
	/// <summary>
	/// Gets the sector 3 whole minute part.
	/// </summary>
	public byte Sector3TimeMinutes { get; init; }
	/// <summary>
	/// Gets the lap validity bit flags.
	/// </summary>
	public LapValid LapValidBitFlags { get; init; }
													

	static LapHistoryData IByteParsable<LapHistoryData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			LapTimeInMS = reader.GetNextUInt(),
			Sector1TimeInMS = reader.GetNextUShort(),
			Sector1TimeMinutes = reader.GetNextByte(),
			Sector2TimeInMS = reader.GetNextUShort(),
			Sector2TimeMinutes = reader.GetNextByte(),
			Sector3TimeInMS = reader.GetNextUShort(),
			Sector3TimeMinutes = reader.GetNextByte(),
			LapValidBitFlags = reader.GetNextEnum<LapValid>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(LapTimeInMS);
		writer.Write(Sector1TimeInMS);
		writer.Write(Sector1TimeMinutes);
		writer.Write(Sector2TimeInMS);
		writer.Write(Sector2TimeMinutes);
		writer.Write(Sector3TimeInMS);
		writer.Write(Sector3TimeMinutes);
		writer.WriteEnum(LapValidBitFlags);
	}
}
