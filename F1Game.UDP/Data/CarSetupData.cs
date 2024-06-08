namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 49)]
public readonly record struct CarSetupData() : IByteParsable<CarSetupData>, IByteWritable
{
	public byte FrontWing { get; init; } // Front wing aero
	public byte RearWing { get; init; } // Rear wing aero
	public byte OnThrottle { get; init; } // Differential adjustment on throttle (percentage)
	public byte OffThrottle { get; init; } // Differential adjustment off throttle (percentage)
	public float FrontCamber { get; init; } // Front camber angle (suspension geometry)
	public float RearCamber { get; init; } // Rear camber angle (suspension geometry)
	public float FrontToe { get; init; } // Front toe angle (suspension geometry)
	public float RearToe { get; init; } // Rear toe angle (suspension geometry)
	public byte FrontSuspension { get; init; } // Front suspension
	public byte RearSuspension { get; init; } // Rear suspension
	public byte FrontAntiRollBar { get; init; } // Front anti-roll bar
	public byte RearAntiRollBar { get; init; } // Front anti-roll bar
	public byte FrontSuspensionHeight { get; init; } // Front ride height
	public byte RearSuspensionHeight { get; init; } // Rear ride height
	public byte BrakePressure { get; init; } // Brake pressure (percentage)
	public byte BrakeBias { get; init; } // Brake bias (percentage)
	public Tyres<float> TyresPressures { get; init; } // PSI
	public byte Ballast { get; init; } // Ballast
	public float FuelLoad { get; init; } // Fuel load

	static CarSetupData IByteParsable<CarSetupData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			FrontWing = reader.GetNextByte(),
			RearWing = reader.GetNextByte(),
			OnThrottle = reader.GetNextByte(),
			OffThrottle = reader.GetNextByte(),
			FrontCamber = reader.GetNextFloat(),
			RearCamber = reader.GetNextFloat(),
			FrontToe = reader.GetNextFloat(),
			RearToe = reader.GetNextFloat(),
			FrontSuspension = reader.GetNextByte(),
			RearSuspension = reader.GetNextByte(),
			FrontAntiRollBar = reader.GetNextByte(),
			RearAntiRollBar = reader.GetNextByte(),
			FrontSuspensionHeight = reader.GetNextByte(),
			RearSuspensionHeight = reader.GetNextByte(),
			BrakePressure = reader.GetNextByte(),
			BrakeBias = reader.GetNextByte(),
			TyresPressures = reader.GetNextTyresFloat(),
			Ballast = reader.GetNextByte(),
			FuelLoad = reader.GetNextFloat(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(FrontWing);
		writer.Write(RearWing);
		writer.Write(OnThrottle);
		writer.Write(OffThrottle);
		writer.Write(FrontCamber);
		writer.Write(RearCamber);
		writer.Write(FrontToe);
		writer.Write(RearToe);
		writer.Write(FrontSuspension);
		writer.Write(RearSuspension);
		writer.Write(FrontAntiRollBar);
		writer.Write(RearAntiRollBar);
		writer.Write(FrontSuspensionHeight);
		writer.Write(RearSuspensionHeight);
		writer.Write(BrakePressure);
		writer.Write(BrakeBias);
		writer.Write(TyresPressures.RearLeft);
		writer.Write(TyresPressures.RearRight);
		writer.Write(TyresPressures.FrontLeft);
		writer.Write(TyresPressures.FrontRight);
		writer.Write(Ballast);
		writer.Write(FuelLoad);
	}
}
