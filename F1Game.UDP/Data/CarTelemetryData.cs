using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarTelemetryData() : IByteParsable<CarTelemetryData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 60;

	/// <summary>
	/// Speed of car in kilometres per hour.
	/// </summary>
	public ushort Speed { get; init; }
	/// <summary>
	/// Amount of throttle applied (0.0 to 1.0).
	/// </summary>
	public float Throttle { get; init; }
	/// <summary>
	/// Steering (-1.0 (full lock left) to 1.0 (full lock right)).
	/// </summary>
	public float Steer { get; init; }
	/// <summary>
	/// Amount of brake applied (0.0 to 1.0).
	/// </summary>
	public float Brake { get; init; }
	/// <summary>
	/// Amount of clutch applied (0 to 100).
	/// </summary>
	public byte Clutch { get; init; }
	/// <summary>
	/// Gear selected (1-8, N=0, R=-1).
	/// </summary>
	public sbyte Gear { get; init; }
	/// <summary>
	/// Engine RPM.
	/// </summary>
	public ushort EngineRPM { get; init; }
	/// <summary>
	/// DRS status
	/// </summary>
	public bool IsDrsOn { get; init; }
	/// <summary>
	/// Rev lights indicator (percentage).
	/// </summary>
	public byte RevLightsPercent { get; init; }
	/// <summary>
	/// Rev lights (bit 0 = leftmost LED, bit 14 = rightmost LED).
	/// </summary>
	public ushort RevLightsBitValue { get; init; }
	/// <summary>
	/// Brakes temperature (celsius).
	/// </summary>
	public Tyres<ushort> BrakesTemperature { get; init; }
	/// <summary>
	/// Tyres surface temperature (celsius).
	/// </summary>
	public Tyres<byte> TyresSurfaceTemperature { get; init; }
	/// <summary>
	/// Tyres inner temperature (celsius).
	/// </summary>
	public Tyres<byte> TyresInnerTemperature { get; init; }
	/// <summary>
	/// Engine temperature (celsius).
	/// </summary>
	public ushort EngineTemperature { get; init; }
	/// <summary>
	/// Tyres pressure (PSI).
	/// </summary>
	public Tyres<float> TyresPressure { get; init; }
	/// <summary>
	/// Driving surface, see appendices.
	/// </summary>
	public Tyres<Surface> SurfaceType { get; init; }

	static CarTelemetryData IByteParsable<CarTelemetryData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Speed = reader.GetNextUShort(),
			Throttle = reader.GetNextFloat(),
			Steer = reader.GetNextFloat(),
			Brake = reader.GetNextFloat(),
			Clutch = reader.GetNextByte(),
			Gear = reader.GetNextSbyte(),
			EngineRPM = reader.GetNextUShort(),
			IsDrsOn = reader.GetNextBoolean(),
			RevLightsPercent = reader.GetNextByte(),
			RevLightsBitValue = reader.GetNextUShort(),
			BrakesTemperature = reader.GetNextTyresUShort(),
			TyresSurfaceTemperature = reader.GetNextTyresByte(),
			TyresInnerTemperature = reader.GetNextTyresByte(),
			EngineTemperature = reader.GetNextUShort(),
			TyresPressure = reader.GetNextTyresFloat(),
			SurfaceType = reader.GetNextTyresEnum<Surface>(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Speed);
		writer.Write(Throttle);
		writer.Write(Steer);
		writer.Write(Brake);
		writer.Write(Clutch);
		writer.Write(Gear);
		writer.Write(EngineRPM);
		writer.Write(IsDrsOn);
		writer.Write(RevLightsPercent);
		writer.Write(RevLightsBitValue);
		writer.WriteTyresUShort(BrakesTemperature);
		writer.WriteTyresByte(TyresSurfaceTemperature);
		writer.WriteTyresByte(TyresInnerTemperature);
		writer.Write(EngineTemperature);
		writer.WriteTyresFloat(TyresPressure);
		writer.WriteTyresEnum(SurfaceType);
	}
}
