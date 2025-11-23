using F1Game.UDP.Data;

namespace F1Game.UDP.Internal;

interface IHaveHeader
{
	/// <summary>
	/// Gets the common packet header shared by all packet types.
	/// </summary>
	public PacketHeader Header { get; init; }
}
