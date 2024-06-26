﻿namespace F1Game.UDP.Events;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
public readonly record struct StopGoPenaltyServedEvent() : IByteParsable<StopGoPenaltyServedEvent>, IByteWritable
{
	public byte VehicleIdx { get; init; } // Vehicle index of the vehicle serving stop go

	static StopGoPenaltyServedEvent IByteParsable<StopGoPenaltyServedEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			VehicleIdx = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(VehicleIdx);
	}
}
