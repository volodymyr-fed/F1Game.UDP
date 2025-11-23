using System.Diagnostics;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;

namespace F1Game.UDP.Packets;

/// <summary>
/// Represents a union packet that can hold any of the F1 game UDP packet types.
/// </summary>
[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 1460)]
public readonly record struct UnionPacket : IByteWritable
{
	/// <summary>
	/// Gets the type of the packet contained in this union.
	/// </summary>
	[field: FieldOffset(PacketHeader.PacketTypeIndex)]
	public PacketType PacketType { get; init; }
	/// <summary>
	/// Gets the common packet header shared by all packet types.
	/// </summary>
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

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a car damage data packet.
	/// </summary>
	/// <param name="carDamageDataPacket">The car damage data packet.</param>
	public UnionPacket(CarDamageDataPacket carDamageDataPacket) => (this.carDamageDataPacket, PacketType) = (carDamageDataPacket, PacketType.CarDamage);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a car setup data packet.
	/// </summary>
	/// <param name="carSetupDataPacket">The car setup data packet.</param>
	public UnionPacket(CarSetupDataPacket carSetupDataPacket) => (this.carSetupDataPacket, PacketType) = (carSetupDataPacket, PacketType.CarSetups);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a car status data packet.
	/// </summary>
	/// <param name="carStatusDataPacket">The car status data packet.</param>
	public UnionPacket(CarStatusDataPacket carStatusDataPacket) => (this.carStatusDataPacket, PacketType) = (carStatusDataPacket, PacketType.CarStatus);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a car telemetry data packet.
	/// </summary>
	/// <param name="carTelemetryDataPacket">The car telemetry data packet.</param>
	public UnionPacket(CarTelemetryDataPacket carTelemetryDataPacket) => (this.carTelemetryDataPacket, PacketType) = (carTelemetryDataPacket, PacketType.CarTelemetry);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with an event data packet.
	/// </summary>
	/// <param name="eventDataPacket">The event data packet.</param>
	public UnionPacket(EventDataPacket eventDataPacket) => (this.eventDataPacket, PacketType) = (eventDataPacket, PacketType.Event);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a final classification data packet.
	/// </summary>
	/// <param name="finalClassificationDataPacket">The final classification data packet.</param>
	public UnionPacket(FinalClassificationDataPacket finalClassificationDataPacket) => (this.finalClassificationDataPacket, PacketType) = (finalClassificationDataPacket, PacketType.FinalClassification);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a lap data packet.
	/// </summary>
	/// <param name="lapDataPacket">The lap data packet.</param>
	public UnionPacket(LapDataPacket lapDataPacket) => (this.lapDataPacket, PacketType) = (lapDataPacket, PacketType.LapData);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a lobby info data packet.
	/// </summary>
	/// <param name="lobbyInfoDataPacket">The lobby info data packet.</param>
	public UnionPacket(LobbyInfoDataPacket lobbyInfoDataPacket) => (this.lobbyInfoDataPacket, PacketType) = (lobbyInfoDataPacket, PacketType.LobbyInfo);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a motion data packet.
	/// </summary>
	/// <param name="motionDataPacket">The motion data packet.</param>
	public UnionPacket(MotionDataPacket motionDataPacket) => (this.motionDataPacket, PacketType) = (motionDataPacket, PacketType.Motion);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a participants data packet.
	/// </summary>
	/// <param name="participantsDataPacket">The participants data packet.</param>
	public UnionPacket(ParticipantsDataPacket participantsDataPacket) => (this.participantsDataPacket, PacketType) = (participantsDataPacket, PacketType.Participants);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a session data packet.
	/// </summary>
	/// <param name="sessionDataPacket">The session data packet.</param>
	public UnionPacket(SessionDataPacket sessionDataPacket) => (this.sessionDataPacket, PacketType) = (sessionDataPacket, PacketType.Session);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a session history data packet.
	/// </summary>
	/// <param name="sessionHistoryDataPacket">The session history data packet.</param>
	public UnionPacket(SessionHistoryDataPacket sessionHistoryDataPacket) => (this.sessionHistoryDataPacket, PacketType) = (sessionHistoryDataPacket, PacketType.SessionHistory);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a tyre sets data packet.
	/// </summary>
	/// <param name="tyreSetsDataPacket">The tyre sets data packet.</param>
	public UnionPacket(TyreSetsDataPacket tyreSetsDataPacket) => (this.tyreSetsDataPacket, PacketType) = (tyreSetsDataPacket, PacketType.TyreSets);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a motion extended data packet.
	/// </summary>
	/// <param name="motionExDataPacket">The motion extended data packet.</param>
	public UnionPacket(MotionExDataPacket motionExDataPacket) => (this.motionExDataPacket, PacketType) = (motionExDataPacket, PacketType.MotionEx);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a time trial data packet.
	/// </summary>
	/// <param name="timeTrialDataPacket">The time trial data packet.</param>
	public UnionPacket(TimeTrialDataPacket timeTrialDataPacket) => (this.timeTrialDataPacket, PacketType) = (timeTrialDataPacket, PacketType.TimeTrial);

	/// <summary>
	/// Initializes a new instance of the <see cref="UnionPacket"/> struct with a lap positions data packet.
	/// </summary>
	/// <param name="lapPositionsDataPacket">The lap positions data packet.</param>
	public UnionPacket(LapPositionsDataPacket lapPositionsDataPacket) => (this.lapPositionsDataPacket, PacketType) = (lapPositionsDataPacket, PacketType.LapPositions);

	/// <summary>
	/// Tries to get the car damage data packet from this union.
	/// </summary>
	/// <param name="carDamageDataPacket">When this method returns, contains the car damage data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.CarDamage"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetCarDamageDataPacket(out CarDamageDataPacket carDamageDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarDamage;
		carDamageDataPacket = isRightPacket ? this.carDamageDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the car setup data packet from this union.
	/// </summary>
	/// <param name="carSetupDataPacket">When this method returns, contains the car setup data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.CarSetups"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetCarSetupDataPacket(out CarSetupDataPacket carSetupDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarSetups;
		carSetupDataPacket = isRightPacket ? this.carSetupDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the car status data packet from this union.
	/// </summary>
	/// <param name="carStatusDataPacket">When this method returns, contains the car status data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.CarStatus"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetCarStatusDataPacket(out CarStatusDataPacket carStatusDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarStatus;
		carStatusDataPacket = isRightPacket ? this.carStatusDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the car telemetry data packet from this union.
	/// </summary>
	/// <param name="carTelemetryDataPacket">When this method returns, contains the car telemetry data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.CarTelemetry"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetCarTelemetryDataPacket(out CarTelemetryDataPacket carTelemetryDataPacket)
	{
		var isRightPacket = PacketType == PacketType.CarTelemetry;
		carTelemetryDataPacket = isRightPacket ? this.carTelemetryDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the event data packet from this union.
	/// </summary>
	/// <param name="eventDataPacket">When this method returns, contains the event data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.Event"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetEventDataPacket(out EventDataPacket eventDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Event;
		eventDataPacket = isRightPacket ? this.eventDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the final classification data packet from this union.
	/// </summary>
	/// <param name="finalClassificationDataPacket">When this method returns, contains the final classification data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.FinalClassification"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetFinalClassificationDataPacket(out FinalClassificationDataPacket finalClassificationDataPacket)
	{
		var isRightPacket = PacketType == PacketType.FinalClassification;
		finalClassificationDataPacket = isRightPacket ? this.finalClassificationDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the lap data packet from this union.
	/// </summary>
	/// <param name="lapDataPacket">When this method returns, contains the lap data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.LapData"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetLapDataPacket(out LapDataPacket lapDataPacket)
	{
		var isRightPacket = PacketType == PacketType.LapData;
		lapDataPacket = isRightPacket ? this.lapDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the lobby info data packet from this union.
	/// </summary>
	/// <param name="lobbyInfoDataPacket">When this method returns, contains the lobby info data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.LobbyInfo"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetLobbyInfoDataPacket(out LobbyInfoDataPacket lobbyInfoDataPacket)
	{
		var isRightPacket = PacketType == PacketType.LobbyInfo;
		lobbyInfoDataPacket = isRightPacket ? this.lobbyInfoDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the motion data packet from this union.
	/// </summary>
	/// <param name="motionDataPacket">When this method returns, contains the motion data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.Motion"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetMotionDataPacket(out MotionDataPacket motionDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Motion;
		motionDataPacket = isRightPacket ? this.motionDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the participants data packet from this union.
	/// </summary>
	/// <param name="participantsDataPacket">When this method returns, contains the participants data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.Participants"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetParticipantsDataPacket(out ParticipantsDataPacket participantsDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Participants;
		participantsDataPacket = isRightPacket ? this.participantsDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the session data packet from this union.
	/// </summary>
	/// <param name="sessionDataPacket">When this method returns, contains the session data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.Session"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetSessionDataPacket(out SessionDataPacket sessionDataPacket)
	{
		var isRightPacket = PacketType == PacketType.Session;
		sessionDataPacket = isRightPacket ? this.sessionDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the session history data packet from this union.
	/// </summary>
	/// <param name="sessionHistoryDataPacket">When this method returns, contains the session history data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.SessionHistory"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetSessionHistoryDataPacket(out SessionHistoryDataPacket sessionHistoryDataPacket)
	{
		var isRightPacket = PacketType == PacketType.SessionHistory;
		sessionHistoryDataPacket = isRightPacket ? this.sessionHistoryDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the tyre sets data packet from this union.
	/// </summary>
	/// <param name="tyreSetsDataPacket">When this method returns, contains the tyre sets data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.TyreSets"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetTyreSetsDataPacket(out TyreSetsDataPacket tyreSetsDataPacket)
	{
		var isRightPacket = PacketType == PacketType.TyreSets;
		tyreSetsDataPacket = isRightPacket ? this.tyreSetsDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the motion extended data packet from this union.
	/// </summary>
	/// <param name="motionExDataPacket">When this method returns, contains the motion extended data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.MotionEx"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetMotionExDataPacket(out MotionExDataPacket motionExDataPacket)
	{
		var isRightPacket = PacketType == PacketType.MotionEx;
		motionExDataPacket = isRightPacket ? this.motionExDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the time trial data packet from this union.
	/// </summary>
	/// <param name="timeTrialDataPacket">When this method returns, contains the time trial data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.TimeTrial"/>; otherwise, <c>false</c>.</returns>
	public bool TryGetTimeTrialDataPacket(out TimeTrialDataPacket timeTrialDataPacket)
	{
		var isRightPacket = PacketType == PacketType.TimeTrial;
		timeTrialDataPacket = isRightPacket ? this.timeTrialDataPacket : default;
		return isRightPacket;
	}

	/// <summary>
	/// Tries to get the lap positions data packet from this union.
	/// </summary>
	/// <param name="lapPositionsDataPacket">When this method returns, contains the lap positions data packet if the packet type matches; otherwise, the default value.</param>
	/// <returns><c>true</c> if the packet type is <see cref="PacketType.LapPositions"/>; otherwise, <c>false</c>.</returns>
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

	/// <summary>
	/// Implicitly converts a <see cref="CarDamageDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The car damage data packet to convert.</param>
	public static implicit operator UnionPacket(CarDamageDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="CarSetupDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The car setup data packet to convert.</param>
	public static implicit operator UnionPacket(CarSetupDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="CarStatusDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The car status data packet to convert.</param>
	public static implicit operator UnionPacket(CarStatusDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="CarTelemetryDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The car telemetry data packet to convert.</param>
	public static implicit operator UnionPacket(CarTelemetryDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts an <see cref="EventDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The event data packet to convert.</param>
	public static implicit operator UnionPacket(EventDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="FinalClassificationDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The final classification data packet to convert.</param>
	public static implicit operator UnionPacket(FinalClassificationDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="LapDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The lap data packet to convert.</param>
	public static implicit operator UnionPacket(LapDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="LobbyInfoDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The lobby info data packet to convert.</param>
	public static implicit operator UnionPacket(LobbyInfoDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="MotionDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The motion data packet to convert.</param>
	public static implicit operator UnionPacket(MotionDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="ParticipantsDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The participants data packet to convert.</param>
	public static implicit operator UnionPacket(ParticipantsDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="SessionDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The session data packet to convert.</param>
	public static implicit operator UnionPacket(SessionDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="SessionHistoryDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The session history data packet to convert.</param>
	public static implicit operator UnionPacket(SessionHistoryDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="TyreSetsDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The tyre sets data packet to convert.</param>
	public static implicit operator UnionPacket(TyreSetsDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="MotionExDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The motion extended data packet to convert.</param>
	public static implicit operator UnionPacket(MotionExDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="TimeTrialDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The time trial data packet to convert.</param>
	public static implicit operator UnionPacket(TimeTrialDataPacket packet) => new(packet);

	/// <summary>
	/// Implicitly converts a <see cref="LapPositionsDataPacket"/> to a <see cref="UnionPacket"/>.
	/// </summary>
	/// <param name="packet">The lap positions data packet to convert.</param>
	public static implicit operator UnionPacket(LapPositionsDataPacket packet) => new(packet);
}
