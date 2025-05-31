using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details telemetry for all the cars in the race. It details various values that would be recorded on the car such as speed, throttle application, DRS etc.
/// <para>Note that the rev light configurations are presented separately as well and will mimic real life driver preferences.</para>
/// <para>Frequency: Rate as specified in menus</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarTelemetryDataPacket() : IByteParsable<CarTelemetryDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1352;

	public PacketHeader Header { get; init; }
	public Array22<CarTelemetryData> CarTelemetryData { get; init; }
	public MfdPanel MfdPanelStatus { get; init; }
	public MfdPanel MfdPanelStatusSecondaryPlayer { get; init; }
	/// <summary>
	/// Suggested gear for the player (1-8) 0 if no gear suggested
	/// </summary>
	public byte SuggestedGear { get; init; }

	static CarTelemetryDataPacket IByteParsable<CarTelemetryDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarTelemetryData = reader.GetNextArray22<CarTelemetryData>(),
			MfdPanelStatus = reader.GetNextEnum<MfdPanel>(),
			MfdPanelStatusSecondaryPlayer = reader.GetNextEnum<MfdPanel>(),
			SuggestedGear = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarTelemetryData);
		writer.WriteEnum(MfdPanelStatus);
		writer.WriteEnum(MfdPanelStatusSecondaryPlayer);
		writer.Write(SuggestedGear);
	}
}
