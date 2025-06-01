using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct PacketHeader() : IByteParsable<PacketHeader>, ISizeable, IByteWritable
{
	internal const int PacketTypeIndex = 6;

	internal static int Size => 29;

	static int ISizeable.Size => Size;

	/// <summary>
	/// Packet format, current version is 2025
	/// </summary>
	public ushort PacketFormat { get; init; }
	/// <summary>
	/// Game year - last two digits e.g. 25
	/// <para>Example: <c>25</c> for 2025</para>
	/// </summary>
	public byte GameYear { get; init; }
	/// <summary>
	/// Game major version - "X.00"
	/// <para>Example: <c>1</c> for version 1.00</para>
	/// </summary>
	public byte GameMajorVersion { get; init; }
	/// <summary>
	/// Game minor version - "1.XX"
	/// <para>Example: <c>15</c> for version 1.15</para>
	/// </summary>
	public byte GameMinorVersion { get; init; }
	/// <summary>
	/// Version of this packet type, all start from 1
	/// <para>Example: <c>1</c></para>
	/// </summary>
	public byte PacketVersion { get; init; }
	/// <summary>
	/// Identifier for the packet type <see cref="Enums.PacketType"/>
	/// </summary>
	public PacketType PacketType { get; init; }
	/// <summary>
	/// Unique identifier for the session
	/// </summary>
	public ulong SessionUID { get; init; }
	/// <summary>
	/// Session timestamp
	/// </summary>
	public float SessionTime { get; init; }
	/// <summary>
	/// Identifier for the frame the data was retrieved on
	/// </summary>
	public uint FrameIdentifier { get; init; }
	/// <summary>
	/// Overall identifier for the frame the data was retrieved on, doesn't go back after flashbacks
	/// </summary>
	public uint OverallFrameIdentifier { get; init; }
	/// <summary>
	/// Index of player's car in the array
	/// </summary>
	public byte PlayerCarIndex { get; init; }
	/// <summary>
	/// Index of secondary player's car in the array (splitscreen)
	/// <para><c>255</c> if no second player</para>
	/// </summary>
	public byte SecondaryPlayerCarIndex { get; init; }

	static PacketHeader IByteParsable<PacketHeader>.Parse(ref BytesReader reader)
	{
		return new()
		{
			PacketFormat = reader.GetNextUShort(),
			GameYear = reader.GetNextByte(),
			GameMajorVersion = reader.GetNextByte(),
			GameMinorVersion = reader.GetNextByte(),
			PacketVersion = reader.GetNextByte(),
			PacketType = reader.GetNextEnum<PacketType>(),
			SessionUID = reader.GetNextULong(),
			SessionTime = reader.GetNextFloat(),
			FrameIdentifier = reader.GetNextUInt(),
			OverallFrameIdentifier = reader.GetNextUInt(),
			PlayerCarIndex = reader.GetNextByte(),
			SecondaryPlayerCarIndex = reader.GetNextByte()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(PacketFormat);
		writer.Write(GameYear);
		writer.Write(GameMajorVersion);
		writer.Write(GameMinorVersion);
		writer.Write(PacketVersion);
		writer.WriteEnum(PacketType);
		writer.Write(SessionUID);
		writer.Write(SessionTime);
		writer.Write(FrameIdentifier);
		writer.Write(OverallFrameIdentifier);
		writer.Write(PlayerCarIndex);
		writer.Write(SecondaryPlayerCarIndex);
	}
}
