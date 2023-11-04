using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record LobbyInfoDataPacket : IPacket, IByteParsable<LobbyInfoDataPacket>, ISizeable
{
	public static int Size => 1218;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumPlayers { get; init; } // Number of players in the lobby data
	public LobbyInfoData[] LobbyPlayers { get; init; } = Array.Empty<LobbyInfoData>();

	static LobbyInfoDataPacket IByteParsable<LobbyInfoDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumPlayers = reader.GetNextByte(),
			LobbyPlayers = reader.GetNextObjects<LobbyInfoData>(22)
		};
	}
}
