using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details additional telemetry for all the cars in the race.
/// <para>Frequency: Rate as specified in menus</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarTelemetry2DataPacket() : IByteParsable<CarTelemetry2DataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 269;

	/// <inheritdoc/>
	public PacketHeader Header { get; init; }
	/// <summary>
	/// Additional telemetry data for all cars in the session.
	/// </summary>
	public Array24<CarTelemetry2Data> CarTelemetry2Data { get; init; }

	static CarTelemetry2DataPacket IByteParsable<CarTelemetry2DataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarTelemetry2Data = reader.GetNextObjects<CarTelemetry2Data>(ProtocolLimits.MaxCars),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarTelemetry2Data.AsReadOnlySpan());
	}
}
