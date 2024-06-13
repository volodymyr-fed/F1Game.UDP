using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1306)]
public readonly record struct LobbyInfoDataPacket() : IByteParsable<LobbyInfoDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1306;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumPlayers { get; init; } // Number of players in the lobby data
	public Array22<LobbyInfoData> LobbyPlayers { get; init; }

	static LobbyInfoDataPacket IByteParsable<LobbyInfoDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumPlayers = reader.GetNextByte(),
			LobbyPlayers = reader.GetNextArray22<LobbyInfoData>()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(NumPlayers);
		writer.Write(LobbyPlayers);
	}
}
