using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
public readonly record struct PacketHeader() : IByteParsable<PacketHeader>, ISizeable, IByteWritable
{
	public static readonly PacketHeader Empty = new();
	internal const int PacketTypeIndex = 6;

	public static int Size => 29;

	public ushort PacketFormat { get; init; } // 2023
	public byte GameYear { get; init; }
	public byte GameMajorVersion { get; init; } // Game major version - "X.00"
	public byte GameMinorVersion { get; init; } // Game minor version - "1.XX"
	public byte PacketVersion { get; init; } // Version of this packet type, all start from 1
	public PacketType PacketType { get; init; } // Identifier for the packet type, see below
	public ulong SessionUID { get; init; } // Unique identifier for the session
	public float SessionTime { get; init; } // Session timestamp
	public uint FrameIdentifier { get; init; } // Identifier for the frame the data was retrieved on
	public uint OverallFrameIdentifier { get; init; } // Identifier for the frame the data was retrieved on
	public byte PlayerCarIndex { get; init; } // Index of player's car in the array
	public byte SecondaryPlayerCarIndex { get; init; } // Index of secondary player's car in the array (splitscreen) 255 if no second player

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
