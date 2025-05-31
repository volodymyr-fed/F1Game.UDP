using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// The motion packet gives physics data for all the cars being driven.
/// <para>
/// N.B.For the normalised vectors below, to convert to float values divide by 32767.0f – 16-bit signed values are used to pack the data
/// and on the assumption that direction values are always between -1.0f and 1.0f.
/// </para>
/// <para>Frequency: Rate as specified in menus</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct MotionDataPacket() : IByteParsable<MotionDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1349;

	public PacketHeader Header { get; init; }
	public Array22<CarMotionData> CarMotionData { get; init; }

	static MotionDataPacket IByteParsable<MotionDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarMotionData = reader.GetNextArray22<CarMotionData>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarMotionData);
	}
}
