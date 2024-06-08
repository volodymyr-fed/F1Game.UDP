using F1Sharp;
using F1Sharp.Packets;

using System.Runtime.InteropServices;

namespace F1Game.UDP.Benchmarks;

static class F1SharpHelper
{
	public static void ReadPacket(byte[] data)
	{
		GCHandle handle = new();

		try
		{
			handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			PacketHeader header = (PacketHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketHeader))!;

			switch (header.packetId)
			{
				case Packet.MOTION:
					MotionPacket motionPacket = (MotionPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MotionPacket))!;
					OnMotionDataReceive?.Invoke(motionPacket);
					break;
				case Packet.LAP_DATA:
					var lapDataPacket = (F1Sharp.Packets.LapDataPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(F1Sharp.Packets.LapDataPacket))!;
					OnLapDataReceive?.Invoke(lapDataPacket);
					break;
				case Packet.EVENT:
					EventPacket eventPacket = (EventPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(EventPacket))!;
					OnEventDetailsReceive?.Invoke(eventPacket);
					break;
				case Packet.SESSION:
					SessionPacket sessionPacket = (SessionPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SessionPacket))!;
					OnSessionDataReceive?.Invoke(sessionPacket);
					break;
				case Packet.PARTICIPANTS:
					ParticipantsPacket participantsPacket = (ParticipantsPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(ParticipantsPacket))!;
					OnParticipantsDataReceive?.Invoke(participantsPacket);
					break;
				case Packet.CAR_SETUPS:
					CarSetupPacket carSetupPacket = (CarSetupPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarSetupPacket))!;
					OnCarSetupDataReceive?.Invoke(carSetupPacket);
					break;
				case Packet.CAR_TELEMETRY:
					CarTelemetryPacket carTelemetryPacket = (CarTelemetryPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarTelemetryPacket))!;
					OnCarTelemetryDataReceive?.Invoke(carTelemetryPacket);
					break;
				case Packet.CAR_STATUS:
					CarStatusPacket carStatusPacket = (CarStatusPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarStatusPacket))!;
					OnCarStatusDataReceive?.Invoke(carStatusPacket);
					break;
				case Packet.FINAL_CLASSIFICATION:
					FinalClassificationPacket finalClassificationPacket = (FinalClassificationPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(FinalClassificationPacket))!;
					OnFinalClassificationDataReceive?.Invoke(finalClassificationPacket);
					break;
				case Packet.LOBBY_INFO:
					LobbyInfoPacket lobbyInfoPacket = (LobbyInfoPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(LobbyInfoPacket))!;
					OnLobbyInfoDataReceive?.Invoke(lobbyInfoPacket);
					break;
				case Packet.CAR_DAMAGE:
					CarDamagePacket carDamagePacket = (CarDamagePacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarDamagePacket))!;
					OnCarDamageDataReceive?.Invoke(carDamagePacket);
					break;
				case Packet.SESSION_HISTORY:
					SessionHistoryPacket sessionHistoryPacket = (SessionHistoryPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SessionHistoryPacket))!;
					OnSessionHistoryDataReceive?.Invoke(sessionHistoryPacket);
					break;
				case Packet.TYRE_SET:
					TyreSetPacket tyreSetPacket = (TyreSetPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TyreSetPacket))!;
					OnTyreSetDataReceive?.Invoke(tyreSetPacket);
					break;
				case Packet.MOTION_EX:
					MotionExPacket motionExPacket = (MotionExPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MotionExPacket))!;
					OnMotionExDataReceive?.Invoke(motionExPacket);
					break;
			}
		}
		finally
		{
			if (handle.IsAllocated)
				handle.Free();
		}
	}

	public delegate void MotionDataReceiveDelegate(MotionPacket packet);
	public delegate void LapDataReceiveDelegate(LapDataPacket packet);
	public delegate void EventDetailsReceiveDelegate(EventPacket packet);
	public delegate void SessionDataReceiveDelegate(SessionPacket packet);
	public delegate void ParticipantsDataReceiveDelegate(ParticipantsPacket packet);
	public delegate void CarSetupDataReceiveDelegate(CarSetupPacket packet);
	public delegate void CarTelemetryDataReceiveDelegate(CarTelemetryPacket packet);
	public delegate void CarStatusDataReceiveDelegate(CarStatusPacket packet);
	public delegate void FinalClassificationDataReceiveDelegate(FinalClassificationPacket packet);
	public delegate void LobbyInfoDataReceiveDelegate(LobbyInfoPacket packet);
	public delegate void CarDamageDataReceiveDelegate(CarDamagePacket packet);
	public delegate void SessionHistoryDataReceiveDelegate(SessionHistoryPacket packet);
	public delegate void TyreSetDataReceiveDelegate(TyreSetPacket packet);
	public delegate void MotionExDataReceiveDelegate(MotionExPacket packet);

	// Events
	public static event MotionDataReceiveDelegate? OnMotionDataReceive;
	public static event LapDataReceiveDelegate? OnLapDataReceive;
	public static event EventDetailsReceiveDelegate? OnEventDetailsReceive;
	public static event SessionDataReceiveDelegate? OnSessionDataReceive;
	public static event ParticipantsDataReceiveDelegate? OnParticipantsDataReceive;
	public static event CarSetupDataReceiveDelegate? OnCarSetupDataReceive;
	public static event CarTelemetryDataReceiveDelegate? OnCarTelemetryDataReceive;
	public static event CarStatusDataReceiveDelegate? OnCarStatusDataReceive;
	public static event FinalClassificationDataReceiveDelegate? OnFinalClassificationDataReceive;
	public static event LobbyInfoDataReceiveDelegate? OnLobbyInfoDataReceive;
	public static event CarDamageDataReceiveDelegate? OnCarDamageDataReceive;
	public static event SessionHistoryDataReceiveDelegate? OnSessionHistoryDataReceive;
	public static event TyreSetDataReceiveDelegate? OnTyreSetDataReceive;
	public static event MotionExDataReceiveDelegate? OnMotionExDataReceive;
}
