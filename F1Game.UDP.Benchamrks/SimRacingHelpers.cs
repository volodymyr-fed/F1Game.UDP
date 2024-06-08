using F1_22_UDP_Telemetry_Receiver.Packets;

using SimRacing.Telemetry.Receiver.F1._23.Packets;

namespace F1Game.UDP.Benchmarks;

static class SimRacingHelpers
{
	public static Packet ReadPacket(byte[] data)
	{
		Packet header = new Packet(data);

		return (PacketType)header.packetId switch
		{
			PacketType.Motion => new PacketMotionData(data),
			PacketType.Session => new PacketSessionData(data),
			PacketType.LapData => new PacketLapData(data),
			PacketType.Event => new PacketEventData(data),
			PacketType.Participants => new PacketParticipantsData(data),
			PacketType.CarSetups => new PacketCarSetupData(data),
			PacketType.CarTelemetery => new PacketCarTelemetryData(data),
			PacketType.CarStatus => new PacketCarStatusData(data),
			PacketType.FinalClassification => new PacketFinalClassificationData(data),
			PacketType.LobbyInfo => new PacketLobbyInfoData(data),
			PacketType.CarDamage => new PacketCarDamageData(data),
			PacketType.SessionHistory => new PacketSessionHistoryData(data),
			PacketType.TyreSets => new PacketTyreSetData(data),
			PacketType.MotionExtra => new PacketMotionExtraData(data),
			_ => throw new NotImplementedException()
		};
	}
}
