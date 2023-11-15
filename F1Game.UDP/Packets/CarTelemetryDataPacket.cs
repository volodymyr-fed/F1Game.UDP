using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

public sealed record CarTelemetryDataPacket : IPacket, IByteParsable<CarTelemetryDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1352;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public CarTelemetryData[] CarTelemetryData { get; init; } = [];
	public MfdPanel MfdPanelIndex { get; init; }
	public MfdPanel MfdPanelIndexSecondaryPlayer { get; init; } // See above
	public sbyte SuggestedGear { get; init; } // Suggested gear for the player (1-8) 0 if no gear suggested

	static CarTelemetryDataPacket IByteParsable<CarTelemetryDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarTelemetryData = reader.GetNextObjects<CarTelemetryData>(22),
			MfdPanelIndex = reader.GetNextEnum<MfdPanel>(),
			MfdPanelIndexSecondaryPlayer = reader.GetNextEnum<MfdPanel>(),
			SuggestedGear = reader.GetNextSbyte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteObject(Header);
		writer.WriteObjects(CarTelemetryData);
		writer.WriteEnum(MfdPanelIndex);
		writer.WriteEnum(MfdPanelIndexSecondaryPlayer);
		writer.WriteSByte(SuggestedGear);
	}
}
