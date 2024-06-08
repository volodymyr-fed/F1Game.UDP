using F1Game.UDP.Enums;

namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 55)]
public readonly record struct CarStatusData() : IByteParsable<CarStatusData>, IByteWritable
{
	public TractionOptions TractionControl { get; init; } // Traction control - 0 = off, 1 = medium, 2 = full
	public AntiLockBrakesOptions AntiLockBrakes { get; init; } // 0 (off) - 1 (on)
	public FuelMixOptions FuelMix { get; init; } // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
	public byte FrontBrakeBias { get; init; } // Front brake bias (percentage)
	private byte IsPitLimiterOnByte { get; init; } // Pit limiter status - 0 = off, 1 = on
	public bool IsPitLimiterOn { get => IsPitLimiterOnByte.AsBool(); init => IsPitLimiterOnByte = value.AsByte(); }
	public float FuelInTank { get; init; } // Current fuel mass
	public float FuelCapacity { get; init; } // Fuel capacity
	public float FuelRemainingLaps { get; init; } // Fuel remaining in terms of laps (value on MFD)
	public ushort MaxRPM { get; init; } // Cars max RPM, point of rev limiter
	public ushort IdleRPM { get; init; } // Cars idle RPM
	public byte MaxGears { get; init; } // Maximum number of gears
	private byte DrsAllowedByte { get; init; } // 0 = not allowed, 1 = allowed
	public bool DrsAllowed { get => DrsAllowedByte.AsBool(); init => DrsAllowedByte = value.AsByte(); }
	public ushort DrsActivationDistance { get; init; } // in meters
	public ActualCompound ActualTyreCompound { get; init; }
	public VisualCompound VisualTyreCompound { get; init; }
	public byte TyresAgeLaps { get; init; } // Age in laps of the current set of tyres
	public FiaFlag VehicleFiaFlags { get; init; } // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow
	public float EnginePowerICE { get; init; } // Engine power output of ICE (W)
	public float EnginePowerMGUK { get; init; } // Engine power output of MGU-K (W)
	public float ErsStoreEnergy { get; init; } // ERS energy store in Joules
	public ErsDeployMode ErsDeployMode { get; init; } // ERS deployment mode, 0 = none, 1 = medium, 2 = hotlap, 3 = overtake
	public float ErsHarvestedThisLapMGUK { get; init; } // ERS energy harvested this lap by MGU-K
	public float ErsHarvestedThisLapMGUH { get; init; } // ERS energy harvested this lap by MGU-H
	public float ErsDeployedThisLap { get; init; } // ERS energy deployed this lap
	private byte NetworkPausedByte { get; init; } // Whether the car is paused in a network game
	public bool NetworkPaused { get => NetworkPausedByte.AsBool(); init => NetworkPausedByte = value.AsByte(); }

	static CarStatusData IByteParsable<CarStatusData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			TractionControl = reader.GetNextEnum<TractionOptions>(),
			AntiLockBrakes = reader.GetNextEnum<AntiLockBrakesOptions>(),
			FuelMix = reader.GetNextEnum<FuelMixOptions>(),
			FrontBrakeBias = reader.GetNextByte(),
			IsPitLimiterOnByte = reader.GetNextByte(),
			FuelInTank = reader.GetNextFloat(),
			FuelCapacity = reader.GetNextFloat(),
			FuelRemainingLaps = reader.GetNextFloat(),
			MaxRPM = reader.GetNextUShort(),
			IdleRPM = reader.GetNextUShort(),
			MaxGears = reader.GetNextByte(),
			DrsAllowedByte = reader.GetNextByte(),
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
			NetworkPausedByte = reader.GetNextByte()
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteEnum(TractionControl);
		writer.WriteEnum(AntiLockBrakes);
		writer.WriteEnum(FuelMix);
		writer.Write(FrontBrakeBias);
		writer.Write(IsPitLimiterOnByte);
		writer.Write(FuelInTank);
		writer.Write(FuelCapacity);
		writer.Write(FuelRemainingLaps);
		writer.Write(MaxRPM);
		writer.Write(IdleRPM);
		writer.Write(MaxGears);
		writer.Write(DrsAllowedByte);
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
		writer.Write(NetworkPausedByte);
	}
}
