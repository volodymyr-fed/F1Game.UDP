using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public interface IPacket
{
	public PacketHeader Header { get; init; }
}
