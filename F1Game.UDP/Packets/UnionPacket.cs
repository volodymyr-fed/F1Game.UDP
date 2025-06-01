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
	private readonly CarDamageDataPacket carDamageDataPacket;
	[field: FieldOffset(0)]
	private readonly CarSetupDataPacket carSetupDataPacket;
	[field: FieldOffset(0)]
	private readonly CarStatusDataPacket carStatusDataPacket;
	[field: FieldOffset(0)]
	private readonly CarTelemetryDataPacket carTelemetryDataPacket;
	[field: FieldOffset(0)]
	private readonly EventDataPacket eventDataPacket;
	[field: FieldOffset(0)]
	private readonly FinalClassificationDataPacket finalClassificationDataPacket;
	[field: FieldOffset(0)]
	private readonly LapDataPacket lapDataPacket;
	[field: FieldOffset(0)]
	private readonly LobbyInfoDataPacket lobbyInfoDataPacket;
	[field: FieldOffset(0)]
	private readonly MotionDataPacket motionDataPacket;
	[field: FieldOffset(0)]
	private readonly ParticipantsDataPacket participantsDataPacket;
	[field: FieldOffset(0)]
	private readonly SessionDataPacket sessionDataPacket;
	[field: FieldOffset(0)]
	private readonly SessionHistoryDataPacket sessionHistoryDataPacket;
	[field: FieldOffset(0)]
	private readonly TyreSetsDataPacket tyreSetsDataPacket;
	[field: FieldOffset(0)]
	private readonly MotionExDataPacket motionExDataPacket;
	[field: FieldOffset(0)]
	private readonly TimeTrialDataPacket timeTrialDataPacket;
	[field: FieldOffset(0)]
	private readonly LapPositionsDataPacket lapPositionsDataPacket;

	public UnionPacket(CarDamageDataPacket carDamageDataPacket) => (this.carDamageDataPacket, PacketType) = (carDamageDataPacket, PacketType.CarDamage);
	public UnionPacket(CarSetupDataPacket carSetupDataPacket) => (this.carSetupDataPacket, PacketType) = (carSetupDataPacket, PacketType.CarSetups);
	public UnionPacket(CarStatusDataPacket carStatusDataPacket) => (this.carStatusDataPacket, PacketType) = (carStatusDataPacket, PacketType.CarStatus);
	public UnionPacket(CarTelemetryDataPacket carTelemetryDataPacket) => (this.carTelemetryDataPacket, PacketType) = (carTelemetryDataPacket, PacketType.CarTelemetry);
	public UnionPacket(EventDataPacket eventDataPacket) => (this.eventDataPacket, PacketType) = (eventDataPacket, PacketType.Event);
	public UnionPacket(FinalClassificationDataPacket finalClassificationDataPacket) => (this.finalClassificationDataPacket, PacketType) = (finalClassificationDataPacket, PacketType.FinalClassification);
	public UnionPacket(LapDataPacket lapDataPacket) => (this.lapDataPacket, PacketType) = (lapDataPacket, PacketType.LapData);
	public UnionPacket(LobbyInfoDataPacket lobbyInfoDataPacket) => (this.lobbyInfoDataPacket, PacketType) = (lobbyInfoDataPacket, PacketType.LobbyInfo);
	public UnionPacket(MotionDataPacket motionDataPacket) => (this.motionDataPacket, PacketType) = (motionDataPacket, PacketType.Motion);
	public UnionPacket(ParticipantsDataPacket participantsDataPacket) => (this.participantsDataPacket, PacketType) = (participantsDataPacket, PacketType.Participants);
	public UnionPacket(SessionDataPacket sessionDataPacket) => (this.sessionDataPacket, PacketType) = (sessionDataPacket, PacketType.Session);
	public UnionPacket(SessionHistoryDataPacket sessionHistoryDataPacket) => (this.sessionHistoryDataPacket, PacketType) = (sessionHistoryDataPacket, PacketType.SessionHistory);
	public UnionPacket(TyreSetsDataPacket tyreSetsDataPacket) => (this.tyreSetsDataPacket, PacketType) = (tyreSetsDataPacket, PacketType.TyreSets);
	public UnionPacket(MotionExDataPacket motionExDataPacket) => (this.motionExDataPacket, PacketType) = (motionExDataPacket, PacketType.MotionEx);
	public UnionPacket(TimeTrialDataPacket timeTrialDataPacket) => (this.timeTrialDataPacket, PacketType) = (timeTrialDataPacket, PacketType.TimeTrial);
	public UnionPacket(LapPositionsDataPacket lapPositionsDataPacket) => (this.lapPositionsDataPacket, PacketType) = (lapPositionsDataPacket, PacketType.LapPositions);

	public bool TryGetCarDamageDataPacket(out CarDamageDataPacket carDamageDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarDamage;
		carDamageDataPacket = isRightPacket ? this.carDamageDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetCarSetupDataPacket(out CarSetupDataPacket carSetupDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarSetups;
		carSetupDataPacket = isRightPacket ? this.carSetupDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetCarStatusDataPacket(out CarStatusDataPacket carStatusDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarStatus;
		carStatusDataPacket = isRightPacket ? this.carStatusDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetCarTelemetryDataPacket(out CarTelemetryDataPacket carTelemetryDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarTelemetry;
		carTelemetryDataPacket = isRightPacket ? this.carTelemetryDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetEventDataPacket(out EventDataPacket eventDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Event;
		eventDataPacket = isRightPacket ? this.eventDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetFinalClassificationDataPacket(out FinalClassificationDataPacket finalClassificationDataPacket)
	{
		var isRightPacket = PacketType == PacketType.FinalClassification;
		finalClassificationDataPacket = isRightPacket ? this.finalClassificationDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetLapDataPacket(out LapDataPacket lapDataPacket)
	{
		var isRightPacket = PacketType == PacketType.LapData;
		lapDataPacket = isRightPacket ? this.lapDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetLobbyInfoDataPacket(out LobbyInfoDataPacket lobbyInfoDataPacket)
	{
		var isRightPacket = PacketType == PacketType.LobbyInfo;
		lobbyInfoDataPacket = isRightPacket ? this.lobbyInfoDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetMotionDataPacket(out MotionDataPacket motionDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Motion;
		motionDataPacket = isRightPacket ? this.motionDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetParticipantsDataPacket(out ParticipantsDataPacket participantsDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Participants;
		participantsDataPacket = isRightPacket ? this.participantsDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetSessionDataPacket(out SessionDataPacket sessionDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Session;
		sessionDataPacket = isRightPacket ? this.sessionDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetSessionHistoryDataPacket(out SessionHistoryDataPacket sessionHistoryDataPacket)
	{
		var isRightPacket = PacketType == PacketType.SessionHistory;
		sessionHistoryDataPacket = isRightPacket ? this.sessionHistoryDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetTyreSetsDataPacket(out TyreSetsDataPacket tyreSetsDataPacket)
	{
		var isRightPacket = PacketType == PacketType.TyreSets;
		tyreSetsDataPacket = isRightPacket ? this.tyreSetsDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetMotionExDataPacket(out MotionExDataPacket motionExDataPacket)
	{
		var isRightPacket = PacketType == PacketType.MotionEx;
		motionExDataPacket = isRightPacket ? this.motionExDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetTimeTrialDataPacket(out TimeTrialDataPacket timeTrialDataPacket)
	{
		var isRightPacket = PacketType == PacketType.TimeTrial;
		timeTrialDataPacket = isRightPacket ? this.timeTrialDataPacket : default;
		return isRightPacket;
	}

	public bool TryGetLapPositionsDataPacket(out LapPositionsDataPacket lapPositionsDataPacket)
	{
		var isRightPacket = PacketType == PacketType.LapPositions;
		lapPositionsDataPacket = isRightPacket ? this.lapPositionsDataPacket : default;
		return isRightPacket;
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		IByteWritable byteWritable = PacketType switch
		{
			PacketType.CarDamage => carDamageDataPacket,
			PacketType.CarSetups => carSetupDataPacket,
			PacketType.CarStatus => carStatusDataPacket,
			PacketType.CarTelemetry => carTelemetryDataPacket,
			PacketType.Event => eventDataPacket,
			PacketType.FinalClassification => finalClassificationDataPacket,
			PacketType.MotionEx => motionExDataPacket,
			PacketType.LapData => lapDataPacket,
			PacketType.LobbyInfo => lobbyInfoDataPacket,
			PacketType.Motion => motionDataPacket,
			PacketType.Participants => participantsDataPacket,
			PacketType.Session => sessionDataPacket,
			PacketType.SessionHistory => sessionHistoryDataPacket,
			PacketType.TyreSets => tyreSetsDataPacket,
			PacketType.TimeTrial => timeTrialDataPacket,
			PacketType.LapPositions => lapPositionsDataPacket,
			_ => throw new UnreachableException()
		};

		writer.Write(byteWritable);
	}

	public static implicit operator UnionPacket(CarDamageDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(CarSetupDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(CarStatusDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(CarTelemetryDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(EventDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(FinalClassificationDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(LapDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(LobbyInfoDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(MotionDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(ParticipantsDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(SessionDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(SessionHistoryDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(TyreSetsDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(MotionExDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(TimeTrialDataPacket packet) => new(packet);
	public static implicit operator UnionPacket(LapPositionsDataPacket packet) => new(packet);
}
