using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This is a list of participants in the race.
/// <para>If the vehicle is controlled by AI, then the name will be the driver name.</para>
/// <para>If this is a multiplayer game, the names will be the Steam Id on PC, or the LAN name if appropriate.</para>
/// <para>
/// N.B. on Xbox One, the names will always be the driver name, on PS4 the name will be the LAN name if playing a LAN game,
/// otherwise it will be the driver name.
/// </para>
/// <para>Frequency: Every 5 seconds</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ParticipantsDataPacket() : IByteParsable<ParticipantsDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1350;

	public PacketHeader Header { get; init; }
	/// <summary>
	/// Number of active cars in the data – should match number of cars on HUD
	/// </summary>
	public byte NumActiveCars { get; init; }
	public Array22<ParticipantData> Participants { get; init; }

	static ParticipantsDataPacket IByteParsable<ParticipantsDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumActiveCars = reader.GetNextByte(),
			Participants = reader.GetNextArray22<ParticipantData>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(NumActiveCars);
		writer.Write(Participants);
	}
}
