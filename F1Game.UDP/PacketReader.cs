using System.Runtime.CompilerServices;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Packets;

namespace F1Game.UDP;

public static class PacketReader
{
	public static IPacket ToPacket(this byte[] bytes)
	{
		var packetType = GetPacketType(bytes);

		return packetType switch
		{
			PacketType.Motion => CreateWithMarshal<MotionDataPacket>(bytes),
			PacketType.Session => CreateWithMarshal<SessionDataPacket>(bytes),
			PacketType.LapData => CreateWithMarshal<LapDataPacket>(bytes),
			PacketType.Event => CreateWithReader<EventDataPacket>(bytes),
			PacketType.Participants => CreateWithReader<ParticipantsDataPacket>(bytes),
			PacketType.CarSetups => CreateWithMarshal<CarSetupDataPacket>(bytes),
			PacketType.CarTelemetry => CreateWithMarshal<CarTelemetryDataPacket>(bytes),
			PacketType.CarStatus => CreateWithMarshal<CarStatusDataPacket>(bytes),
			PacketType.FinalClassification => CreateWithReader<FinalClassificationDataPacket>(bytes),
			PacketType.LobbyInfo => CreateWithReader<LobbyInfoDataPacket>(bytes),
			PacketType.CarDamage => CreateWithMarshal<CarDamageDataPacket>(bytes),
			PacketType.SessionHistory => CreateWithMarshal<SessionHistoryDataPacket>(bytes),
			PacketType.TyreSets => CreateWithMarshal<TyreSetsDataPacket>(bytes),
			PacketType.MotionEx => CreateWithMarshal<MotionExDataPacket>(bytes),
			_ => throw new ArgumentOutOfRangeException(nameof(packetType)),
		};
	}

	internal static IPacket ToPacketWithReader(this byte[] bytes)
	{
		var packetType = GetPacketType(bytes);

		return packetType switch
		{
			PacketType.Motion => CreateWithReader<MotionDataPacket>(bytes),
			PacketType.Session => CreateWithReader<SessionDataPacket>(bytes),
			PacketType.LapData => CreateWithReader<LapDataPacket>(bytes),
			PacketType.Event => CreateWithReader<EventDataPacket>(bytes),
			PacketType.Participants => CreateWithReader<ParticipantsDataPacket>(bytes),
			PacketType.CarSetups => CreateWithReader<CarSetupDataPacket>(bytes),
			PacketType.CarTelemetry => CreateWithReader<CarTelemetryDataPacket>(bytes),
			PacketType.CarStatus => CreateWithReader<CarStatusDataPacket>(bytes),
			PacketType.FinalClassification => CreateWithReader<FinalClassificationDataPacket>(bytes),
			PacketType.LobbyInfo => CreateWithReader<LobbyInfoDataPacket>(bytes),
			PacketType.CarDamage => CreateWithReader<CarDamageDataPacket>(bytes),
			PacketType.SessionHistory => CreateWithReader<SessionHistoryDataPacket>(bytes),
			PacketType.TyreSets => CreateWithReader<TyreSetsDataPacket>(bytes),
			PacketType.MotionEx => CreateWithReader<MotionExDataPacket>(bytes),
			_ => throw new ArgumentOutOfRangeException(nameof(packetType)),
		};
	}

	internal static IPacket ToPacketWithMarshal(this byte[] bytes)
	{
		var packetType = GetPacketType(bytes);

		return packetType switch
		{
			PacketType.Motion => CreateWithMarshal<MotionDataPacket>(bytes),
			PacketType.Session => CreateWithMarshal<SessionDataPacket>(bytes),
			PacketType.LapData => CreateWithMarshal<LapDataPacket>(bytes),
			PacketType.Participants => CreateWithMarshal<ParticipantsDataPacket>(bytes),
			PacketType.CarSetups => CreateWithMarshal<CarSetupDataPacket>(bytes),
			PacketType.CarTelemetry => CreateWithMarshal<CarTelemetryDataPacket>(bytes),
			PacketType.CarStatus => CreateWithMarshal<CarStatusDataPacket>(bytes),
			PacketType.FinalClassification => CreateWithMarshal<FinalClassificationDataPacket>(bytes),
			PacketType.LobbyInfo => CreateWithMarshal<LobbyInfoDataPacket>(bytes),
			PacketType.CarDamage => CreateWithMarshal<CarDamageDataPacket>(bytes),
			PacketType.SessionHistory => CreateWithMarshal<SessionHistoryDataPacket>(bytes),
			PacketType.TyreSets => CreateWithMarshal<TyreSetsDataPacket>(bytes),
			PacketType.MotionEx => CreateWithMarshal<MotionExDataPacket>(bytes),
			_ => throw new ArgumentOutOfRangeException(nameof(packetType)),
		};
	}

	static PacketType GetPacketType(byte[] bytes)
	{
		if (bytes.Length < PacketHeader.Size)
			throw new NotEnoughBytesException(PacketHeader.Size, bytes.Length, nameof(PacketHeader));

		var bytesReader = new BytesReader(bytes, PacketHeader.PacketTypeIndex);

		return bytesReader.GetNextEnum<PacketType>();
	}

	static T CreateWithReader<T>(byte[] bytes) where T : IByteParsable<T>, ISizeable
	{
		if (T.Size > bytes.Length)
			throw new NotEnoughBytesException(T.Size, bytes.Length, typeof(T).Name);

		var reader = new BytesReader(bytes);
		return reader.GetNextObject<T>();
	}

	static unsafe T CreateWithMarshal<T>(Span<byte> span) where T : class, IPacket, ISizeable, new()
	{
		if (T.Size > span.Length)
			throw new NotEnoughBytesException(T.Size, span.Length, typeof(T).Name);

		T result = new T();
		ref byte r = ref MemoryMarshal.GetReference(span);
		IntPtr ptr = (IntPtr)Unsafe.AsPointer(ref r);
		Marshal.PtrToStructure(ptr, result);

		return result;
	}
}
