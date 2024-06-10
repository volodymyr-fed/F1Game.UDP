using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 237)]
public readonly record struct MotionExDataPacket() : IByteParsable<MotionExDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	public static int Size => 237;

	public PacketHeader Header { get; init; } = PacketHeader.Empty;
	public Tyres<float> SuspensionPosition { get; init; } // Note: All wheel arrays have the following order:
	public Tyres<float> SuspensionVelocity { get; init; } // RL, RR, FL, FR
	public Tyres<float> SuspensionAcceleration { get; init; } // RL, RR, FL, FR
	public Tyres<float> WheelSpeed { get; init; } // Speed of each wheel
	public Tyres<float> WheelSlipRatio { get; init; } // Slip ratio for each wheel
	public Tyres<float> WheelSlipAngle { get; init; } // Slip angles for each whee
	public Tyres<float> WheelLatForce { get; init; } // Lateral forces for each wheel
	public Tyres<float> WheelLongForce { get; init; } // Longitudinal forces for each wheel
	public float HeightOfCOGAboveGround { get; init; } // Height of centre of gravity above ground
	public float LocalVelocityX { get; init; } // Velocity in local space
	public float LocalVelocityY { get; init; } // Velocity in local space
	public float LocalVelocityZ { get; init; } // Velocity in local space
	public float AngularVelocityX { get; init; } // Angular velocity x-component
	public float AngularVelocityY { get; init; } // Angular velocity y-component
	public float AngularVelocityZ { get; init; } // Angular velocity z-component
	public float AngularAccelerationX { get; init; } // Angular velocity x-component
	public float AngularAccelerationY { get; init; } // Angular velocity y-component
	public float AngularAccelerationZ { get; init; } // Angular velocity z-component
	public float FrontWheelsAngle { get; init; } // Current front wheels angle in radians
	public Tyres<float> WheelVertForce { get; init; } // Vertical forces for each wheel
	public float FrontAeroHeight { get; init; } // Front plank edge height above road surface
	public float RearAeroHeight { get; init; } // Rear plank edge height above road surface
	public float FrontRollAngle { get; init; } // Roll angle of the front suspension
	public float RearRollAngle { get; init; } // Roll angle of the rear suspension
	public float ChassisYaw { get; init; } // Yaw angle of the chassis relative to the direction
						// of motion - radians

	static MotionExDataPacket IByteParsable<MotionExDataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			SuspensionPosition = reader.GetNextTyresFloat(),
			SuspensionVelocity = reader.GetNextTyresFloat(),
			SuspensionAcceleration = reader.GetNextTyresFloat(),
			WheelSpeed = reader.GetNextTyresFloat(),
			WheelSlipRatio = reader.GetNextTyresFloat(),
			WheelSlipAngle = reader.GetNextTyresFloat(),
			WheelLatForce = reader.GetNextTyresFloat(),
			WheelLongForce = reader.GetNextTyresFloat(),
			HeightOfCOGAboveGround = reader.GetNextFloat(),
			LocalVelocityX = reader.GetNextFloat(),
			LocalVelocityY = reader.GetNextFloat(),
			LocalVelocityZ = reader.GetNextFloat(),
			AngularVelocityX = reader.GetNextFloat(),
			AngularVelocityY = reader.GetNextFloat(),
			AngularVelocityZ = reader.GetNextFloat(),
			AngularAccelerationX = reader.GetNextFloat(),
			AngularAccelerationY = reader.GetNextFloat(),
			AngularAccelerationZ = reader.GetNextFloat(),
			FrontWheelsAngle = reader.GetNextFloat(),
			WheelVertForce = reader.GetNextTyresFloat(),
			FrontAeroHeight = reader.GetNextFloat(),
			RearAeroHeight = reader.GetNextFloat(),
			FrontRollAngle = reader.GetNextFloat(),
			RearRollAngle = reader.GetNextFloat(),
			ChassisYaw = reader.GetNextFloat(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.WriteTyresFloat(SuspensionPosition);
		writer.WriteTyresFloat(SuspensionVelocity);
		writer.WriteTyresFloat(SuspensionAcceleration);
		writer.WriteTyresFloat(WheelSpeed);
		writer.WriteTyresFloat(WheelSlipRatio);
		writer.WriteTyresFloat(WheelSlipAngle);
		writer.WriteTyresFloat(WheelLatForce);
		writer.WriteTyresFloat(WheelLongForce);
		writer.Write(HeightOfCOGAboveGround);
		writer.Write(LocalVelocityX);
		writer.Write(LocalVelocityY);
		writer.Write(LocalVelocityZ);
		writer.Write(AngularVelocityX);
		writer.Write(AngularVelocityY);
		writer.Write(AngularVelocityZ);
		writer.Write(AngularAccelerationX);
		writer.Write(AngularAccelerationY);
		writer.Write(AngularAccelerationZ);
		writer.Write(FrontWheelsAngle);
		writer.WriteTyresFloat(WheelVertForce);
		writer.Write(FrontAeroHeight);
		writer.Write(RearAeroHeight);
		writer.Write(FrontRollAngle);
		writer.Write(RearRollAngle);
		writer.Write(ChassisYaw);
	}
}
