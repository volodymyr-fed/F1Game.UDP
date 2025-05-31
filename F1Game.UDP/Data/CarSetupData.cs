namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarSetupData() : IByteParsable<CarSetupData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 50;

	/// <summary>
	/// Front wing aero.
	/// </summary>
	public byte FrontWing { get; init; }
	/// <summary>
	/// Rear wing aero.
	/// </summary>
	public byte RearWing { get; init; }
	/// <summary>
	/// Differential adjustment on throttle (percentage).
	/// </summary>
	public byte OnThrottle { get; init; }
	/// <summary>
	/// Differential adjustment off throttle (percentage).
	/// </summary>
	public byte OffThrottle { get; init; }
	/// <summary>
	/// Front camber angle (suspension geometry).
	/// </summary>
	public float FrontCamber { get; init; }
	/// <summary>
	/// Rear camber angle (suspension geometry).
	/// </summary>
	public float RearCamber { get; init; }
	/// <summary>
	/// Front toe angle (suspension geometry).
	/// </summary>
	public float FrontToe { get; init; }
	/// <summary>
	/// Rear toe angle (suspension geometry).
	/// </summary>
	public float RearToe { get; init; }
	/// <summary>
	/// Front suspension.
	/// </summary>
	public byte FrontSuspension { get; init; }
	/// <summary>
	/// Rear suspension.
	/// </summary>
	public byte RearSuspension { get; init; }
	/// <summary>
	/// Front anti-roll bar.
	/// </summary>
	public byte FrontAntiRollBar { get; init; }
	/// <summary>
	/// Rear anti-roll bar.
	/// </summary>
	public byte RearAntiRollBar { get; init; }
	/// <summary>
	/// Front ride height.
	/// </summary>
	public byte FrontSuspensionHeight { get; init; }
	/// <summary>
	/// Rear ride height.
	/// </summary>
	public byte RearSuspensionHeight { get; init; }
	/// <summary>
	/// Brake pressure (percentage).
	/// </summary>
	public byte BrakePressure { get; init; }
	/// <summary>
	/// Brake bias (percentage).
	/// </summary>
	public byte BrakeBias { get; init; }
	/// <summary>
	/// Engine braking (percentage).
	/// </summary>
	public byte EngineBraking { get; init; }
	/// <summary>
	/// Tyre pressures in PSI.
	/// </summary>
	public Tyres<float> TyresPressure { get; init; }
	/// <summary>
	/// Ballast.
	/// </summary>
	public byte Ballast { get; init; }
	/// <summary>
	/// Fuel load.
	/// </summary>
	public float FuelLoad { get; init; }

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
			EngineBraking = reader.GetNextByte(),
			TyresPressure = reader.GetNextTyresFloat(),
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
		writer.Write(EngineBraking);
		writer.WriteTyresFloat(TyresPressure);
		writer.Write(Ballast);
		writer.Write(FuelLoad);
	}
}
