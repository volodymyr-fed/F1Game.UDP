using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details the players currently in a multiplayer lobby.
/// It details each player’s selected car, any AI involved in the game and also the ready status of each of the participants.
/// <para>Frequency: Two every second when in the lobby</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct LobbyInfoDataPacket() : IByteParsable<LobbyInfoDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1306;

	public PacketHeader Header { get; init; }
	/// <summary>
	/// Number of players in the <see cref="LobbyPlayers"/>
	/// </summary>
	public byte NumPlayers { get; init; }
	public Array22<LobbyInfoData> LobbyPlayers { get; init; }

	static LobbyInfoDataPacket IByteParsable<LobbyInfoDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumPlayers = reader.GetNextByte(),
			LobbyPlayers = reader.GetNextObjects<LobbyInfoData>(22)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(NumPlayers);
		writer.Write(LobbyPlayers.AsReadOnlySpan());
	}
}
