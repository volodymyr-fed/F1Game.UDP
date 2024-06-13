using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1352)]
public readonly record struct CarTelemetryDataPacket() : IByteParsable<CarTelemetryDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1352;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public Array22<CarTelemetryData> CarTelemetryData { get; init; }
	public MfdPanel MfdPanelIndex { get; init; }
	public MfdPanel MfdPanelIndexSecondaryPlayer { get; init; } // See above
	public byte SuggestedGear { get; init; } // Suggested gear for the player (1-8) 0 if no gear suggested

	static CarTelemetryDataPacket IByteParsable<CarTelemetryDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarTelemetryData = reader.GetNextArray22<CarTelemetryData>(),
			MfdPanelIndex = reader.GetNextEnum<MfdPanel>(),
			MfdPanelIndexSecondaryPlayer = reader.GetNextEnum<MfdPanel>(),
			SuggestedGear = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarTelemetryData);
		writer.WriteEnum(MfdPanelIndex);
		writer.WriteEnum(MfdPanelIndexSecondaryPlayer);
		writer.Write(SuggestedGear);
	}
}
