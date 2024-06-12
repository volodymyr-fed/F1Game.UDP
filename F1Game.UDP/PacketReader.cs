using System.Runtime.CompilerServices;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Packets;

namespace F1Game.UDP;

public static class PacketReader
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static UnionPacket ToPacket(this byte[] bytes)
	{
		var packetType = GetPacketType(bytes);
		var packet = new UnionPacket();

		return packetType switch
		{
			PacketType.Motion => CreateWithMarshal<MotionDataPacket>(bytes, ref packet),
			PacketType.Session => CreateWithMarshal<SessionDataPacket>(bytes, ref packet),
			PacketType.LapData => CreateWithMarshal<LapDataPacket>(bytes, ref packet),
			PacketType.Event => CreateWithMarshal<EventDataPacket>(bytes, ref packet),
			PacketType.Participants => CreateWithMarshal<ParticipantsDataPacket>(bytes, ref packet),
			PacketType.CarSetups => CreateWithMarshal<CarSetupDataPacket>(bytes, ref packet),
			PacketType.CarTelemetry => CreateWithMarshal<CarTelemetryDataPacket>(bytes, ref packet),
			PacketType.CarStatus => CreateWithMarshal<CarStatusDataPacket>(bytes, ref packet),
			PacketType.FinalClassification => CreateWithMarshal<FinalClassificationDataPacket>(bytes, ref packet),
			PacketType.LobbyInfo => CreateWithMarshal<LobbyInfoDataPacket>(bytes, ref packet),
			PacketType.CarDamage => CreateWithMarshal<CarDamageDataPacket>(bytes, ref packet),
			PacketType.SessionHistory => CreateWithMarshal<SessionHistoryDataPacket>(bytes, ref packet),
			PacketType.TyreSets => CreateWithMarshal<TyreSetsDataPacket>(bytes, ref packet),
			PacketType.MotionEx => CreateWithMarshal<MotionExDataPacket>(bytes, ref packet),
			_ => throw new InvalidPacketTypeException(packetType),
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static UnionPacket ToPacketWithReader(this byte[] bytes)
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
			_ => throw new InvalidPacketTypeException(packetType),
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static UnionPacket ToPacketWithMarshal(this byte[] bytes)
	{
		var packetType = GetPacketType(bytes);
		var packet = new UnionPacket();

		return packetType switch
		{
			PacketType.Motion => CreateWithMarshal<MotionDataPacket>(bytes, ref packet),
			PacketType.Session => CreateWithMarshal<SessionDataPacket>(bytes, ref packet),
			PacketType.LapData => CreateWithMarshal<LapDataPacket>(bytes, ref packet),
			PacketType.Event => CreateWithMarshal<EventDataPacket>(bytes, ref packet),
			PacketType.Participants => CreateWithMarshal<ParticipantsDataPacket>(bytes, ref packet),
			PacketType.CarSetups => CreateWithMarshal<CarSetupDataPacket>(bytes, ref packet),
			PacketType.CarTelemetry => CreateWithMarshal<CarTelemetryDataPacket>(bytes, ref packet),
			PacketType.CarStatus => CreateWithMarshal<CarStatusDataPacket>(bytes, ref packet),
			PacketType.FinalClassification => CreateWithMarshal<FinalClassificationDataPacket>(bytes, ref packet),
			PacketType.LobbyInfo => CreateWithMarshal<LobbyInfoDataPacket>(bytes, ref packet),
			PacketType.CarDamage => CreateWithMarshal<CarDamageDataPacket>(bytes, ref packet),
			PacketType.SessionHistory => CreateWithMarshal<SessionHistoryDataPacket>(bytes, ref packet),
			PacketType.TyreSets => CreateWithMarshal<TyreSetsDataPacket>(bytes, ref packet),
			PacketType.MotionEx => CreateWithMarshal<MotionExDataPacket>(bytes, ref packet),
			_ => throw new InvalidPacketTypeException(packetType),
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	static PacketType GetPacketType(Span<byte> bytes)
	{
		if (bytes.Length < PacketHeader.Size)
			throw new NotEnoughBytesException(PacketHeader.Size, bytes.Length, typeof(PacketHeader));

		return (PacketType) bytes[PacketHeader.PacketTypeIndex];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	static T CreateWithReader<T>(byte[] bytes) where T : IByteParsable<T>, ISizeable
	{
		if (T.Size > bytes.Length)
			throw new NotEnoughBytesException(T.Size, bytes.Length, typeof(T));

		var reader = new BytesReader(bytes);
		return reader.GetNextObject<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	static ref UnionPacket CreateWithMarshal<T>(Span<byte> span, ref UnionPacket packet) where T : struct, ISizeable
	{
		if (T.Size > span.Length)
			throw new NotEnoughBytesException(T.Size, span.Length, typeof(T));

		var structSpan = MemoryMarshal.CreateSpan(ref packet, 1);
		var bytesStructSpan = MemoryMarshal.AsBytes(structSpan);

		span.Slice(0, T.Size).CopyTo(bytesStructSpan);

		return ref packet;
	}
}
