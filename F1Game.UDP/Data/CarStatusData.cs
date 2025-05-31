using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarStatusData() : IByteParsable<CarStatusData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 55;

	/// <summary>
	/// Traction control setting <see cref="TractionOptions"/>
	/// </summary>
	public TractionOptions TractionControl { get; init; }
	/// <summary>
	/// Anti-lock brakes setting <see cref="AntiLockBrakesOptions"/>
	/// </summary>
	public AntiLockBrakesOptions AntiLockBrakes { get; init; }
	/// <summary>
	/// Fuel mix setting <see cref="FuelMixOptions"/>
	/// </summary>
	public FuelMixOptions FuelMix { get; init; }
	/// <summary>
	/// Front brake bias as a percentage.
	/// </summary>
	public byte FrontBrakeBias { get; init; }
	/// <summary>
	/// Pit limiter status.
	/// </summary>
	public bool IsPitLimiterOn { get; init; }
	/// <summary>
	/// Current fuel mass in the tank.
	/// </summary>
	public float FuelInTank { get; init; }
	/// <summary>
	/// Total fuel capacity.
	/// </summary>
	public float FuelCapacity { get; init; }
	/// <summary>
	/// Fuel remaining in terms of laps (value on MFD).
	/// </summary>
	public float FuelRemainingLaps { get; init; }
	/// <summary>
	/// Car's maximum RPM, point of rev limiter.
	/// </summary>
	public ushort MaxRPM { get; init; }
	/// <summary>
	/// Car's idle RPM.
	/// </summary>
	public ushort IdleRPM { get; init; }
	/// <summary>
	/// Maximum number of gears.
	/// </summary>
	public byte MaxGears { get; init; }
	/// <summary>
	/// DRS allowed status.
	/// </summary>
	public bool DrsAllowed { get; init; }
	/// <summary>
	/// DRS activation distance in meters.
	/// </summary>
	public ushort DrsActivationDistance { get; init; }
	/// <summary>
	/// Actual tyre compound.
	/// </summary>
	public ActualCompound ActualTyreCompound { get; init; }
	/// <summary>
	/// Visual tyre compound.
	/// </summary>
	public VisualCompound VisualTyreCompound { get; init; }
	/// <summary>
	/// Age in laps of the current set of tyres.
	/// </summary>
	public byte TyresAgeLaps { get; init; }
	/// <summary>
	/// FIA flag status <see cref="FiaFlag" />.
	/// </summary>
	public FiaFlag VehicleFiaFlags { get; init; }
	/// <summary>
	/// Engine power output of ICE (W).
	/// </summary>
	public float EnginePowerICE { get; init; }
	/// <summary>
	/// Engine power output of MGU-K (W).
	/// </summary>
	public float EnginePowerMGUK { get; init; }
	/// <summary>
	/// ERS energy store in Joules.
	/// </summary>
	public float ErsStoreEnergy { get; init; }
	/// <summary>
	/// ERS deployment mode <see cref="Enums.ErsDeployMode" />.
	/// </summary>
	public ErsDeployMode ErsDeployMode { get; init; }
	/// <summary>
	/// ERS energy harvested this lap by MGU-K.
	/// </summary>
	public float ErsHarvestedThisLapMGUK { get; init; }
	/// <summary>
	/// ERS energy harvested this lap by MGU-H.
	/// </summary>
	public float ErsHarvestedThisLapMGUH { get; init; }
	/// <summary>
	/// ERS energy deployed this lap.
	/// </summary>
	public float ErsDeployedThisLap { get; init; }
	/// <summary>
	/// Whether the car is paused in a network game.
	/// </summary>
	public bool NetworkPaused { get; init; }

	static CarStatusData IByteParsable<CarStatusData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			TractionControl = reader.GetNextEnum<TractionOptions>(),
			AntiLockBrakes = reader.GetNextEnum<AntiLockBrakesOptions>(),
			FuelMix = reader.GetNextEnum<FuelMixOptions>(),
			FrontBrakeBias = reader.GetNextByte(),
			IsPitLimiterOn = reader.GetNextBoolean(),
			FuelInTank = reader.GetNextFloat(),
			FuelCapacity = reader.GetNextFloat(),
			FuelRemainingLaps = reader.GetNextFloat(),
			MaxRPM = reader.GetNextUShort(),
			IdleRPM = reader.GetNextUShort(),
			MaxGears = reader.GetNextByte(),
			DrsAllowed = reader.GetNextBoolean(),
			DrsActivationDistance = reader.GetNextUShort(),
			ActualTyreCompound = reader.GetNextEnum<ActualCompound>(),
			VisualTyreCompound = reader.GetNextEnum<VisualCompound>(),
			TyresAgeLaps = reader.GetNextByte(),
			VehicleFiaFlags = reader.GetNextEnum<FiaFlag>(),
			EnginePowerICE = reader.GetNextFloat(),
			EnginePowerMGUK = reader.GetNextFloat(),
			ErsStoreEnergy = reader.GetNextFloat(),
			ErsDeployMode = reader.GetNextEnum<ErsDeployMode>(),
			ErsHarvestedThisLapMGUK = reader.GetNextFloat(),
			ErsHarvestedThisLapMGUH = reader.GetNextFloat(),
			ErsDeployedThisLap = reader.GetNextFloat(),
			NetworkPaused = reader.GetNextBoolean()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(TractionControl);
		writer.WriteEnum(AntiLockBrakes);
		writer.WriteEnum(FuelMix);
		writer.Write(FrontBrakeBias);
		writer.Write(IsPitLimiterOn);
		writer.Write(FuelInTank);
		writer.Write(FuelCapacity);
		writer.Write(FuelRemainingLaps);
		writer.Write(MaxRPM);
		writer.Write(IdleRPM);
		writer.Write(MaxGears);
		writer.Write(DrsAllowed);
		writer.Write(DrsActivationDistance);
		writer.WriteEnum(ActualTyreCompound);
		writer.WriteEnum(VisualTyreCompound);
		writer.Write(TyresAgeLaps);
		writer.WriteEnum(VehicleFiaFlags);
		writer.Write(EnginePowerICE);
		writer.Write(EnginePowerMGUK);
		writer.Write(ErsStoreEnergy);
		writer.WriteEnum(ErsDeployMode);
		writer.Write(ErsHarvestedThisLapMGUK);
		writer.Write(ErsHarvestedThisLapMGUH);
		writer.Write(ErsDeployedThisLap);
		writer.Write(NetworkPaused);
	}
}
