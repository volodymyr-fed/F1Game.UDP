using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet details the car setups for each vehicle in the session.
/// <para>
/// Note that in multiplayer games, other player cars will appear as blank, you will only be able to see your own car setup, regardless of the “Your Telemetry” setting.
/// Spectators will also not be able to see any car setups.
/// </para>
/// <para>Frequency: 2 per second</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarSetupDataPacket() : IByteParsable<CarSetupDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 1133;

	public PacketHeader Header { get; init; }
	public Array22<CarSetupData> CarSetups { get; init; }

	/// <summary>
	/// Value of front wing after next pit stop - player only
	/// </summary>
	public float NextFrontWingValue { get; init; }

	static CarSetupDataPacket IByteParsable<CarSetupDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarSetups = reader.GetNextArray22<CarSetupData>(),
			NextFrontWingValue = reader.GetNextFloat()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarSetups);
		writer.Write(NextFrontWingValue);
	}
}
