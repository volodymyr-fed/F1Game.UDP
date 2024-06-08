using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 14)]
public readonly record struct LapHistoryData() : IByteParsable<LapHistoryData>, IByteWritable
{
	public uint LapTimeInMS { get; init; } // Lap time in milliseconds
	public ushort Sector1TimeInMS { get; init; } // Sector 1 time in milliseconds
	public byte Sector1TimeMinutes { get; init; } // Sector 1 whole minute part
	public ushort Sector2TimeInMS { get; init; } // Sector 2 time in milliseconds
	public byte Sector2TimeMinutes { get; init; } // Sector 2 whole minute part
	public ushort Sector3TimeInMS { get; init; } // Sector 3 time in milliseconds
	public byte Sector3TimeMinutes { get; init; } // Sector 3 whole minute part
	public LapValid LapValidBitFlags { get; init; } // 0x01 bit set-lap valid, 0x02 bit set-sector 1 valid
													// 0x04 bit set-sector 2 valid, 0x08 bit set-sector 3 valid

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
