using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct TyreStintHistoryData() : IByteParsable<TyreStintHistoryData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 3;

	/// <summary>
	/// Gets the lap the tyre usage ends on (255 if current tyre).
	/// </summary>
	public byte EndLap { get; init; }
	/// <summary>
	/// Gets the actual compound of tyres used by this driver.
	/// </summary>
	public ActualCompound TyreActualCompound { get; init; }
	/// <summary>
	/// Gets the visual compound of tyres used by this driver.
	/// </summary>
	public VisualCompound TyreVisualCompound { get; init; }

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
