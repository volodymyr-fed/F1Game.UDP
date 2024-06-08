using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1218)]
public sealed record LobbyInfoDataPacket() : IPacket, IByteParsable<LobbyInfoDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1218;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumPlayers { get; init; } // Number of players in the lobby data
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public LobbyInfoData[] LobbyPlayers { get; init; } = [];

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
		writer.Write(LobbyPlayers);
	}
}
