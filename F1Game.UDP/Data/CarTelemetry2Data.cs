namespace F1Game.UDP.Data;

/// <summary>
/// Represents the additional telemetry data introduced for the 2026 regulations.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarTelemetry2Data() : IByteParsable<CarTelemetry2Data>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 10;

	/// <summary>
	/// Active aero mode. 0 = corner mode, 1 = straight mode.
	/// </summary>
	public byte ActiveAeroMode { get; init; }
	/// <summary>
	/// Indicates whether active aero is available.
	/// </summary>
	public bool ActiveAeroAvailable { get; init; }
	/// <summary>
	/// Distance until active aero can be activated.
	/// </summary>
	public ushort ActiveAeroActivationDistance { get; init; }
	/// <summary>
	/// Indicates whether overtake mode is available.
	/// </summary>
	public bool OvertakeAvailable { get; init; }
	/// <summary>
	/// Indicates whether overtake mode is currently active.
	/// </summary>
	public bool OvertakeActive { get; init; }
	/// <summary>
	/// Distance until overtake mode can be activated.
	/// </summary>
	public ushort OvertakeActivationDistance { get; init; }
	/// <summary>
	/// Indicates whether 2026 regulations are applicable to the car.
	/// </summary>
	public bool Regulations2026Applicable { get; init; }
	/// <summary>
	/// Indicates whether the car is driving the wrong way.
	/// </summary>
	public bool IsDrivingWrongWay { get; init; }

	static CarTelemetry2Data IByteParsable<CarTelemetry2Data>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ActiveAeroMode = reader.GetNextByte(),
			ActiveAeroAvailable = reader.GetNextBoolean(),
			ActiveAeroActivationDistance = reader.GetNextUShort(),
			OvertakeAvailable = reader.GetNextBoolean(),
			OvertakeActive = reader.GetNextBoolean(),
			OvertakeActivationDistance = reader.GetNextUShort(),
			Regulations2026Applicable = reader.GetNextBoolean(),
			IsDrivingWrongWay = reader.GetNextBoolean(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(ActiveAeroMode);
		writer.Write(ActiveAeroAvailable);
		writer.Write(ActiveAeroActivationDistance);
		writer.Write(OvertakeAvailable);
		writer.Write(OvertakeActive);
		writer.Write(OvertakeActivationDistance);
		writer.Write(Regulations2026Applicable);
		writer.Write(IsDrivingWrongWay);
	}
}