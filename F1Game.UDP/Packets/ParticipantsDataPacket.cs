using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1306)]
public sealed record ParticipantsDataPacket() : IPacket, IByteParsable<ParticipantsDataPacket>, ISizeable, IByteWritable
{
	public static int Size => 1306;
	public PacketHeader Header { get; init; } = PacketHeader.Empty; // Header
	public byte NumActiveCars { get; init; } // Number of active cars in the data – should match number of cars on HUD
	[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
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
		writer.Write(Header);
		writer.Write(NumActiveCars);
		writer.Write(Participants);
	}
}
