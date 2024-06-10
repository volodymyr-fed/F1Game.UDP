using System.Diagnostics;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 1460)]
public readonly record struct UnionPacket : IByteWritable
{
	[field: FieldOffset(PacketHeader.PacketTypeIndex)]
	public PacketType PacketType { get; init; }
	[field: FieldOffset(0)]
	public PacketHeader Header { get; init; }
	[field: FieldOffset(0)]
	public CarDamageDataPacket CarDamageDataPacket { get; init; }
	[field: FieldOffset(0)]
	public CarSetupDataPacket CarSetupDataPacket { get; init; }
	[field: FieldOffset(0)]
	public CarStatusDataPacket CarStatusDataPacket { get; init; }
	[field: FieldOffset(0)]
	public CarTelemetryDataPacket CarTelemetryDataPacket { get; init; }
	[field: FieldOffset(0)]
	public EventDataPacket EventDataPacket { get; init; }
	[field: FieldOffset(0)]
	public FinalClassificationDataPacket FinalClassificationDataPacket { get; init; }
	[field: FieldOffset(0)]
	public LapDataPacket LapDataPacket { get; init; }
	[field: FieldOffset(0)]
	public LobbyInfoDataPacket LobbyInfoDataPacket { get; init; }
	[field: FieldOffset(0)]
	public MotionDataPacket MotionDataPacket { get; init; }
	[field: FieldOffset(0)]
	public ParticipantsDataPacket ParticipantsDataPacket { get; init; }
	[field: FieldOffset(0)]
	public SessionDataPacket SessionDataPacket { get; init; }
	[field: FieldOffset(0)]
	public SessionHistoryDataPacket SessionHistoryDataPacket { get; init; }
	[field: FieldOffset(0)]
	public TyreSetsDataPacket TyreSetsDataPacket { get; init; }
	[field: FieldOffset(0)]
	public MotionExDataPacket MotionExDataPacket { get; init; }
	[field: FieldOffset(0)]
	public TimeTrialDataPacket TimeTrialDataPacket { get; init; }

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		IByteWritable byteWritable = PacketType switch
		{
			PacketType.CarDamage => CarDamageDataPacket,
			PacketType.CarSetups => CarSetupDataPacket,
			PacketType.CarStatus => CarStatusDataPacket,
			PacketType.CarTelemetry => CarTelemetryDataPacket,
			PacketType.Event => EventDataPacket,
			PacketType.FinalClassification => FinalClassificationDataPacket,
			PacketType.MotionEx => MotionExDataPacket,
			PacketType.LapData => LapDataPacket,
			PacketType.LobbyInfo => LobbyInfoDataPacket,
			PacketType.Motion => MotionDataPacket,
			PacketType.Participants => ParticipantsDataPacket,
			PacketType.Session => SessionDataPacket,
			PacketType.SessionHistory => SessionHistoryDataPacket,
			PacketType.TyreSets => TyreSetsDataPacket,
			PacketType.TimeTrial => TimeTrialDataPacket,
			_ => throw new UnreachableException()
		};

		writer.Write(byteWritable);
	}

	public static implicit operator UnionPacket(CarDamageDataPacket packet) => new() { CarDamageDataPacket = packet, PacketType = PacketType.CarDamage };
	public static implicit operator UnionPacket(CarSetupDataPacket packet) => new() { CarSetupDataPacket = packet, PacketType = PacketType.CarSetups };
	public static implicit operator UnionPacket(CarStatusDataPacket packet) => new() { CarStatusDataPacket = packet, PacketType = PacketType.CarStatus };
	public static implicit operator UnionPacket(CarTelemetryDataPacket packet) => new() { CarTelemetryDataPacket = packet, PacketType = PacketType.CarTelemetry };
	public static implicit operator UnionPacket(EventDataPacket packet) => new() { EventDataPacket = packet, PacketType = PacketType.Event };
	public static implicit operator UnionPacket(FinalClassificationDataPacket packet) => new() { FinalClassificationDataPacket = packet, PacketType = PacketType.FinalClassification };
	public static implicit operator UnionPacket(LapDataPacket packet) => new() { LapDataPacket = packet, PacketType = PacketType.LapData };
	public static implicit operator UnionPacket(LobbyInfoDataPacket packet) => new() { LobbyInfoDataPacket = packet, PacketType = PacketType.LobbyInfo };
	public static implicit operator UnionPacket(MotionDataPacket packet) => new() { MotionDataPacket = packet, PacketType = PacketType.Motion };
	public static implicit operator UnionPacket(ParticipantsDataPacket packet) => new() { ParticipantsDataPacket = packet, PacketType = PacketType.Participants };
	public static implicit operator UnionPacket(SessionDataPacket packet) => new() { SessionDataPacket = packet, PacketType = PacketType.Session };
	public static implicit operator UnionPacket(SessionHistoryDataPacket packet) => new() { SessionHistoryDataPacket = packet, PacketType = PacketType.SessionHistory };
	public static implicit operator UnionPacket(TyreSetsDataPacket packet) => new() { TyreSetsDataPacket = packet, PacketType = PacketType.TyreSets };
	public static implicit operator UnionPacket(MotionExDataPacket packet) => new() { MotionExDataPacket = packet, PacketType = PacketType.MotionEx };
	public static implicit operator UnionPacket(TimeTrialDataPacket packet) => new() { TimeTrialDataPacket = packet, PacketType = PacketType.TimeTrial };
}
