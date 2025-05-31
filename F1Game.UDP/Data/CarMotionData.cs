namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarMotionData() : IByteParsable<CarMotionData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 60;

	/// <summary>
	/// World space X position.
	/// </summary>
	public float WorldPositionX { get; init; }
	/// <summary>
	/// World space Y position.
	/// </summary>
	public float WorldPositionY { get; init; }
	/// <summary>
	/// World space Z position.
	/// </summary>
	public float WorldPositionZ { get; init; }
	/// <summary>
	/// Velocity in world space X.
	/// </summary>
	public float WorldVelocityX { get; init; }
	/// <summary>
	/// Velocity in world space Y.
	/// </summary>
	public float WorldVelocityY { get; init; }
	/// <summary>
	/// Velocity in world space Z.
	/// </summary>
	public float WorldVelocityZ { get; init; }
	/// <summary>
	/// World space forward X direction (normalized).
	/// </summary>
	public short WorldForwardDirX { get; init; }
	/// <summary>
	/// World space forward Y direction (normalized).
	/// </summary>
	public short WorldForwardDirY { get; init; }
	/// <summary>
	/// World space forward Z direction (normalized).
	/// </summary>
	public short WorldForwardDirZ { get; init; }
	/// <summary>
	/// World space right X direction (normalized).
	/// </summary>
	public short WorldRightDirX { get; init; }
	/// <summary>
	/// World space right Y direction (normalized).
	/// </summary>
	public short WorldRightDirY { get; init; }
	/// <summary>
	/// World space right Z direction (normalized).
	/// </summary>
	public short WorldRightDirZ { get; init; }
	/// <summary>
	/// Lateral G-Force component.
	/// </summary>
	public float GForceLateral { get; init; }
	/// <summary>
	/// Longitudinal G-Force component.
	/// </summary>
	public float GForceLongitudinal { get; init; }
	/// <summary>
	/// Vertical G-Force component.
	/// </summary>
	public float GForceVertical { get; init; }
	/// <summary>
	/// Yaw angle in radians.
	/// </summary>
	public float Yaw { get; init; }
	/// <summary>
	/// Pitch angle in radians.
	/// </summary>
	public float Pitch { get; init; }
	/// <summary>
	/// Roll angle in radians.
	/// </summary>
	public float Roll { get; init; }

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
