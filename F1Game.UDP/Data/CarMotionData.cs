namespace F1Game.UDP.Data;

public sealed record CarMotionData : IByteParsable<CarMotionData>, IByteWritable
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
		writer.WriteFloat(WorldPositionX);
		writer.WriteFloat(WorldPositionY);
		writer.WriteFloat(WorldPositionZ);
		writer.WriteFloat(WorldVelocityX);
		writer.WriteFloat(WorldVelocityY);
		writer.WriteFloat(WorldVelocityZ);
		writer.WriteShort(WorldForwardDirX);
		writer.WriteShort(WorldForwardDirY);
		writer.WriteShort(WorldForwardDirZ);
		writer.WriteShort(WorldRightDirX);
		writer.WriteShort(WorldRightDirY);
		writer.WriteShort(WorldRightDirZ);
		writer.WriteFloat(GForceLateral);
		writer.WriteFloat(GForceLongitudinal);
		writer.WriteFloat(GForceVertical);
		writer.WriteFloat(Yaw);
		writer.WriteFloat(Pitch);
		writer.WriteFloat(Roll);
	}
}
