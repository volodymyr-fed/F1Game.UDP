using F1Sharp;
using F1Sharp.Packets;

using System.Runtime.InteropServices;

namespace F1Game.UDP.Benchmarks.Helpers;

static class F1SharpHelper
{
	public static void ReadPacket(byte[] data)
	{
		GCHandle handle = new();

		try
		{
			handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			var header = (PacketHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketHeader))!;

			switch (header.packetId)
			{
				case Packet.MOTION:
					var motionPacket = (MotionPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MotionPacket))!;
					OnMotionDataReceive?.Invoke(motionPacket);
					break;
				case Packet.LAP_DATA:
					var lapDataPacket = (LapDataPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(LapDataPacket))!;
					OnLapDataReceive?.Invoke(lapDataPacket);
					break;
				case Packet.EVENT:
					var eventPacket = (EventPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(EventPacket))!;
					OnEventDetailsReceive?.Invoke(eventPacket);
					break;
				case Packet.SESSION:
					var sessionPacket = (SessionPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SessionPacket))!;
					OnSessionDataReceive?.Invoke(sessionPacket);
					break;
				case Packet.PARTICIPANTS:
					var participantsPacket = (ParticipantsPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(ParticipantsPacket))!;
					OnParticipantsDataReceive?.Invoke(participantsPacket);
					break;
				case Packet.CAR_SETUPS:
					var carSetupPacket = (CarSetupPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarSetupPacket))!;
					OnCarSetupDataReceive?.Invoke(carSetupPacket);
					break;
				case Packet.CAR_TELEMETRY:
					var carTelemetryPacket = (CarTelemetryPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarTelemetryPacket))!;
					OnCarTelemetryDataReceive?.Invoke(carTelemetryPacket);
					break;
				case Packet.CAR_STATUS:
					var carStatusPacket = (CarStatusPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarStatusPacket))!;
					OnCarStatusDataReceive?.Invoke(carStatusPacket);
					break;
				case Packet.FINAL_CLASSIFICATION:
					var finalClassificationPacket = (FinalClassificationPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(FinalClassificationPacket))!;
					OnFinalClassificationDataReceive?.Invoke(finalClassificationPacket);
					break;
				case Packet.LOBBY_INFO:
					var lobbyInfoPacket = (LobbyInfoPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(LobbyInfoPacket))!;
					OnLobbyInfoDataReceive?.Invoke(lobbyInfoPacket);
					break;
				case Packet.CAR_DAMAGE:
					var carDamagePacket = (CarDamagePacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CarDamagePacket))!;
					OnCarDamageDataReceive?.Invoke(carDamagePacket);
					break;
				case Packet.SESSION_HISTORY:
					var sessionHistoryPacket = (SessionHistoryPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(SessionHistoryPacket))!;
					OnSessionHistoryDataReceive?.Invoke(sessionHistoryPacket);
					break;
				case Packet.TYRE_SET:
					var tyreSetPacket = (TyreSetPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TyreSetPacket))!;
					OnTyreSetDataReceive?.Invoke(tyreSetPacket);
					break;
				case Packet.MOTION_EX:
					var motionExPacket = (MotionExPacket)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MotionExPacket))!;
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
