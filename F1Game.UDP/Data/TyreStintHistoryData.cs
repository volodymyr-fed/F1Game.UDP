using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 3)]
public readonly record struct TyreStintHistoryData() : IByteParsable<TyreStintHistoryData>, IByteWritable
{
	public byte EndLap { get; init; } // Lap the tyre usage ends on (255 of current tyre)
	public ActualCompound TyreActualCompound { get; init; } // Actual tyres used by this driver
	public VisualCompound TyreVisualCompound { get; init; } // Visual tyres used by this driver

	static TyreStintHistoryData IByteParsable<TyreStintHistoryData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			EndLap = reader.GetNextByte(),
			TyreActualCompound = reader.GetNextEnum<ActualCompound>(),
			TyreVisualCompound = reader.GetNextEnum<VisualCompound>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(EndLap);
		writer.WriteEnum(TyreActualCompound);
		writer.WriteEnum(TyreVisualCompound);
	}
}
