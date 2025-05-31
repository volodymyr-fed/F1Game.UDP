using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// The time trial data gives extra information only relevant to time trial game mode. This packet will not be sent in other game modes.
/// <para>Frequency: 1 per second</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct TimeTrialDataPacket() : IByteParsable<TimeTrialDataPacket>, IByteWritable, ISizeable, IHaveHeader
{
	static int ISizeable.Size => 101;

	public PacketHeader Header { get; init; }
	/// <summary>
	/// Player session best data set
	/// </summary>
	public TimeTrialDataSet PlayerSessionBestDataSet { get; init; }
	/// <summary>
	/// Personal best data set
	/// </summary>
	public TimeTrialDataSet PersonalBestDataSet { get; init; }
	/// <summary>
	/// Rival data set
	/// </summary>
	public TimeTrialDataSet RivalDataSet { get; init; }

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
