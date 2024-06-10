using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1350)]
public readonly record struct ParticipantsDataPacket() : IByteParsable<ParticipantsDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 1350;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumActiveCars { get; init; } // Number of active cars in the data – should match number of cars on HUD
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
