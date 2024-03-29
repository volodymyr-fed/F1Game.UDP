﻿using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public readonly record struct MotionDataPacket() : IPacket, IByteParsable<MotionDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1349;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public CarMotionData[] CarMotionData { get; init; } = []; // Data for all cars on track
																						// Extra player car ONLY data

	static MotionDataPacket IByteParsable<MotionDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarMotionData = reader.GetNextObjects<CarMotionData>(22),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteObject(Header);
		writer.WriteObjects(CarMotionData);
	}
}
