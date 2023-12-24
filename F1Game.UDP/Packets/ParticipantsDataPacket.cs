using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public readonly record struct ParticipantsDataPacket() : IPacket, IByteParsable<ParticipantsDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1306;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumActiveCars { get; init; } // Number of active cars in the data – should match number of cars on HUD
	public ParticipantData[] Participants { get; init; } = [];

	static ParticipantsDataPacket IByteParsable<ParticipantsDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			NumActiveCars = reader.GetNextByte(),
			Participants = reader.GetNextObjects<ParticipantData>(22)
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteObject(Header);
		writer.WriteByte(NumActiveCars);
		writer.WriteObjects(Participants);
	}
}
