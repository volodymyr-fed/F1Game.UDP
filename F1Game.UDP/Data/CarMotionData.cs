namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 60)]
public readonly record struct CarMotionData() : IByteParsable<CarMotionData>, IByteWritable
{
	public float WorldPositionX { get; init; } // World space X position
	public float WorldPositionY { get; init; } // World space Y position
	public float WorldPositionZ { get; init; } // World space Z position
	public float WorldVelocityX { get; init; } // Velocity in world space X
	public float WorldVelocityY { get; init; } // Velocity in world space Y
	public float WorldVelocityZ { get; init; } // Velocity in world space Z
	public short WorldForwardDirX { get; init; } // World space forward X direction (normalised)
	public short WorldForwardDirY { get; init; } // World space forward Y direction (normalised)
	public short WorldForwardDirZ { get; init; } // World space forward Z direction (normalised)
	public short WorldRightDirX { get; init; } // World space right X direction (normalised)
	public short WorldRightDirY { get; init; } // World space right Y direction (normalised)
	public short WorldRightDirZ { get; init; } // World space right Z direction (normalised)
	public float GForceLateral { get; init; } // Lateral G-Force component
	public float GForceLongitudinal { get; init; } // Longitudinal G-Force component
	public float GForceVertical { get; init; } // Vertical G-Force component
	public float Yaw { get; init; } // Yaw angle in radians
	public float Pitch { get; init; } // Pitch angle in radians
	public float Roll { get; init; } // Roll angle in radians

	static CarMotionData IByteParsable<CarMotionData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			WorldPositionX = reader.GetNextFloat(),
			WorldPositionY = reader.GetNextFloat(),
			WorldPositionZ = reader.GetNextFloat(),
			WorldVelocityX = reader.GetNextFloat(),
			WorldVelocityY = reader.GetNextFloat(),
			WorldVelocityZ = reader.GetNextFloat(),
			WorldForwardDirX = reader.GetNextShort(),
			WorldForwardDirY = reader.GetNextShort(),
			WorldForwardDirZ = reader.GetNextShort(),
			WorldRightDirX = reader.GetNextShort(),
			WorldRightDirY = reader.GetNextShort(),
			WorldRightDirZ = reader.GetNextShort(),
			GForceLateral = reader.GetNextFloat(),
			GForceLongitudinal = reader.GetNextFloat(),
			GForceVertical = reader.GetNextFloat(),
			Yaw = reader.GetNextFloat(),
			Pitch = reader.GetNextFloat(),
			Roll = reader.GetNextFloat(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(WorldPositionX);
		writer.Write(WorldPositionY);
		writer.Write(WorldPositionZ);
		writer.Write(WorldVelocityX);
		writer.Write(WorldVelocityY);
		writer.Write(WorldVelocityZ);
		writer.Write(WorldForwardDirX);
		writer.Write(WorldForwardDirY);
		writer.Write(WorldForwardDirZ);
		writer.Write(WorldRightDirX);
		writer.Write(WorldRightDirY);
		writer.Write(WorldRightDirZ);
		writer.Write(GForceLateral);
		writer.Write(GForceLongitudinal);
		writer.Write(GForceVertical);
		writer.Write(Yaw);
		writer.Write(Pitch);
		writer.Write(Roll);
	}
}
