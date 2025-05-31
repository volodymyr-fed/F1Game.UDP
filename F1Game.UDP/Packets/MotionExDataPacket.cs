using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// The motion packet gives extended data for the car being driven with the goal of being able to drive a motion platform setup.
/// <para>Frequency: Rate as specified in menus</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct MotionExDataPacket() : IByteParsable<MotionExDataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 237;

	public PacketHeader Header { get; init; }
	public Tyres<float> SuspensionPosition { get; init; }
	public Tyres<float> SuspensionVelocity { get; init; }
	public Tyres<float> SuspensionAcceleration { get; init; }
	/// <summary>
	/// Speed of each wheel
	/// </summary>
	public Tyres<float> WheelSpeed { get; init; }
	/// <summary>
	/// Slip ratio for each wheel
	/// </summary>
	public Tyres<float> WheelSlipRatio { get; init; }
	/// <summary>
	/// Slip angles for each wheel
	/// </summary>
	public Tyres<float> WheelSlipAngle { get; init; }
	/// <summary>
	/// Lateral forces for each wheel
	/// </summary>
	public Tyres<float> WheelLateralForce { get; init; }
	/// <summary>
	/// Longitudinal forces for each wheel
	/// </summary>
	public Tyres<float> WheelLongitudinalForce { get; init; }
	/// <summary>
	/// Height of centre of gravity above ground
	/// </summary>
	public float HeightOfCOGAboveGround { get; init; }
	/// <summary>
	/// Velocity in local space
	/// </summary>
	public float LocalVelocityX { get; init; }
	/// <summary>
	/// Velocity in local space
	/// </summary>
	public float LocalVelocityY { get; init; }
	/// <summary>
	/// Velocity in local space
	/// </summary>
	public float LocalVelocityZ { get; init; }
	/// <summary>
	/// Angular velocity x-component
	/// </summary>
	public float AngularVelocityX { get; init; }
	/// <summary>
	/// Angular velocity y-component
	/// </summary>
	public float AngularVelocityY { get; init; }
	/// <summary>
	/// Angular velocity z-component
	/// </summary>
	public float AngularVelocityZ { get; init; }
	/// <summary>
	/// Angular velocity x-component
	/// </summary>
	public float AngularAccelerationX { get; init; }
	/// <summary>
	/// Angular velocity y-component
	/// </summary>
	public float AngularAccelerationY { get; init; }
	/// <summary>
	/// Angular velocity z-component
	/// </summary>
	public float AngularAccelerationZ { get; init; }
	/// <summary>
	/// Current front wheels angle in radians
	/// </summary>
	public float FrontWheelsAngle { get; init; }
	/// <summary>
	/// Vertical forces for each wheel
	/// </summary>
	public Tyres<float> WheelVerticalForce { get; init; }
	/// <summary>
	/// Front plank edge height above road surface
	/// </summary>
	public float FrontAeroHeight { get; init; }
	/// <summary>
	/// Rear plank edge height above road surface
	/// </summary>
	public float RearAeroHeight { get; init; }
	/// <summary>
	/// Roll angle of the front suspension
	/// </summary>
	public float FrontRollAngle { get; init; }
	/// <summary>
	/// Roll angle of the rear suspension
	/// </summary>
	public float RearRollAngle { get; init; }
	/// <summary>
	/// aw angle of the chassis relative to the direction of motion in radians
	/// </summary>
	public float ChassisYaw { get; init; }

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
			WheelLateralForce = reader.GetNextTyresFloat(),
			WheelLongitudinalForce = reader.GetNextTyresFloat(),
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
			WheelVerticalForce = reader.GetNextTyresFloat(),
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
		writer.WriteTyresFloat(WheelLateralForce);
		writer.WriteTyresFloat(WheelLongitudinalForce);
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
		writer.WriteTyresFloat(WheelVerticalForce);
		writer.Write(FrontAeroHeight);
		writer.Write(RearAeroHeight);
		writer.Write(FrontRollAngle);
		writer.Write(RearRollAngle);
		writer.Write(ChassisYaw);
	}
}
