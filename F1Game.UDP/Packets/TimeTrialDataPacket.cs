using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 101)]
public readonly record struct TimeTrialDataPacket() : IByteParsable<TimeTrialDataPacket>, IByteWritable, ISizeable, IHaveHeader
{
	public static int Size => 101;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	public TimeTrialDataSet PlayerSessionBestDataSet { get; init; } // Player session best data set
	public TimeTrialDataSet PersonalBestDataSet { get; init; } // Personal best data set
	public TimeTrialDataSet RivalDataSet { get; init; } // Rival data set

	static TimeTrialDataPacket IByteParsable<TimeTrialDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			PlayerSessionBestDataSet = reader.GetNextObject<TimeTrialDataSet>(),
			PersonalBestDataSet = reader.GetNextObject<TimeTrialDataSet>(),
			RivalDataSet = reader.GetNextObject<TimeTrialDataSet>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(PlayerSessionBestDataSet);
		writer.Write(PersonalBestDataSet);
		writer.Write(RivalDataSet);
	}
}
