using F1Game.UDP.Data;

namespace F1Game.UDP.Internal;

interface IHaveHeader
{
	public PacketHeader Header { get; init; }
}
