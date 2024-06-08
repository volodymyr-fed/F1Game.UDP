using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 60)]
public readonly record struct CarTelemetryData() : IByteParsable<CarTelemetryData>, IByteWritable
{
	public ushort Speed { get; init; } // Speed of car in kilometres per hour
	public float Throttle { get; init; } // Amount of throttle applied (0.0 to 1.0)
	public float Steer { get; init; } // Steering (-1.0 (full lock left) to 1.0 (full lock right))
	public float Brake { get; init; } // Amount of brake applied (0.0 to 1.0)
	public byte Clutch { get; init; } // Amount of clutch applied (0 to 100)
	public sbyte Gear { get; init; } // Gear selected (1-8, N=0, R=-1)
	public ushort EngineRPM { get; init; } // Engine RPM
	private byte IsDrsOnByte { get; init; } // 0 = off, 1 = on
	public bool IsDrsOn { get => IsDrsOnByte.AsBool(); init => IsDrsOnByte = value.AsByte(); }
	public byte RevLightsPercent { get; init; } // Rev lights indicator (percentage)
	public ushort RevLightsBitValue { get; init; } // Rev lights (bit 0 = leftmost LED, bit 14 = rightmost LED)
	public Tyres<ushort> BrakesTemperature { get; init; } // Brakes temperature (celsius)
	public Tyres<byte> TyresSurfaceTemperature { get; init; } // Tyres surface temperature (celsius)
	public Tyres<byte> TyresInnerTemperature { get; init; } // Tyres inner temperature (celsius)
	public ushort EngineTemperature { get; init; } // Engine temperature (celsius)
	public Tyres<float> TyresPressure { get; init; } // Tyres pressure (PSI)
	public Tyres<Surface> SurfaceType { get; init; } // Driving surface, see appendices

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
			IsDrsOnByte = reader.GetNextByte(),
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
		writer.Write(IsDrsOnByte);
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
