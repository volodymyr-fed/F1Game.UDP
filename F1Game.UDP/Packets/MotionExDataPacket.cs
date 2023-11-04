using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

public sealed record MotionExDataPacket : IPacket, IByteParsable<MotionExDataPacket>, ISizeable
{
	public static int Size => 217;

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
		};
	}
}
