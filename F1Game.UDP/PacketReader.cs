using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Packets;

namespace F1Game.UDP;

public static class PacketReader
{
	public static IPacket ToPacket(this byte[] bytes)
	{
		var packetType = GetPacketType(bytes);
		return CreatePacketByType(bytes, packetType);
	}

	static PacketType GetPacketType(byte[] bytes)
	{
		if (bytes.Length < PacketHeader.Size)
			throw new NotEnoughBytesException(PacketHeader.Size, bytes.Length, nameof(PacketHeader));

		var bytesReader = new BytesReader(bytes, PacketHeader.PacketTypeIndex);

		return bytesReader.GetNextEnum<PacketType>();
	}

	static IPacket CreatePacketByType(byte[] bytes, PacketType packetType)
	{
		var bytesReader = new BytesReader(bytes);

		return packetType switch
		{
			PacketType.Motion => CreateWithSizeCheck<MotionDataPacket>(ref bytesReader),
			PacketType.Session => CreateWithSizeCheck<SessionDataPacket>(ref bytesReader),
			PacketType.LapData => CreateWithSizeCheck<LapDataPacket>(ref bytesReader),
			PacketType.Event => CreateWithSizeCheck<EventDataPacket>(ref bytesReader),
			PacketType.Participants => CreateWithSizeCheck<ParticipantsDataPacket>(ref bytesReader),
			PacketType.CarSetups => CreateWithSizeCheck<CarSetupDataPacket>(ref bytesReader),
			PacketType.CarTelemetry => CreateWithSizeCheck<CarTelemetryDataPacket>(ref bytesReader),
			PacketType.CarStatus => CreateWithSizeCheck<CarStatusDataPacket>(ref bytesReader),
			PacketType.FinalClassification => CreateWithSizeCheck<FinalClassificationDataPacket>(ref bytesReader),
			PacketType.LobbyInfo => CreateWithSizeCheck<LobbyInfoDataPacket>(ref bytesReader),
			PacketType.CarDamage => CreateWithSizeCheck<CarDamageDataPacket>(ref bytesReader),
			PacketType.SessionHistory => CreateWithSizeCheck<SessionHistoryDataPacket>(ref bytesReader),
			PacketType.TyreSets => CreateWithSizeCheck<TyreSetsDataPacket>(ref bytesReader),
			PacketType.MotionEx => CreateWithSizeCheck<MotionExDataPacket>(ref bytesReader),
			_ => throw new ArgumentOutOfRangeException(nameof(packetType)),
		};
	}

	static IPacket CreateWithSizeCheck<T>(ref BytesReader reader) where T : IPacket, IByteParsable<T>, ISizeable
	{
		if (T.Size > reader.TotalCount)
			throw new NotEnoughBytesException(T.Size, reader.TotalCount, typeof(T).Name);

		return reader.GetNextObject<T>();
	}
}
