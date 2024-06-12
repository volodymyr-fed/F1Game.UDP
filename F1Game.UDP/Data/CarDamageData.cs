namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 42)]
public readonly record struct CarDamageData() : IByteParsable<CarDamageData>, IByteWritable
{
	public Tyres<float> TyresWear { get; init; } // Tyre wear (percentage)
	public Tyres<byte> TyresDamage { get; init; } // Tyre damage (percentage)
	public Tyres<byte> BrakesDamage { get; init; } // Brakes damage (percentage)
	public byte FrontLeftWingDamage { get; init; } // Front left wing damage (percentage)
	public byte FrontRightWingDamage { get; init; } // Front right wing damage (percentage)
	public byte RearWingDamage { get; init; } // Rear wing damage (percentage)
	public byte FloorDamage { get; init; } // Floor damage (percentage)
	public byte DiffuserDamage { get; init; } // Diffuser damage (percentage)
	public byte SidepodDamage { get; init; } // Sidepod damage (percentage)
	public bool DrsFault { get; init; } // Indicator for DRS fault, 0 = OK, 1 = fault
	public bool ErsFault { get; init; } // Indicator for ERS fault, 0 = OK, 1 = fault
	public byte GearBoxDamage { get; init; } // Gear box damage (percentage)
	public byte EngineDamage { get; init; } // Engine damage (percentage)
	public byte EngineMGUHWear { get; init; } // Engine wear MGU-H (percentage)
	public byte EngineESWear { get; init; } // Engine wear ES (percentage)
	public byte EngineCEWear { get; init; } // Engine wear CE (percentage)
	public byte EngineICEWear { get; init; } // Engine wear ICE (percentage)
	public byte EngineMGUKWear { get; init; } // Engine wear MGU-K (percentage)
	public byte EngineTCWear { get; init; } // Engine wear TC (percentage)
	public bool EngineBlown { get; init; } // Engine blown, 0 = OK, 1 = fault
	public bool EngineSeized { get; init; } // Engine seized, 0 = OK, 1 = fault

	static CarDamageData IByteParsable<CarDamageData>.Parse(ref BytesReader reader)
	{
		return new()
		{
			TyresWear = reader.GetNextTyresFloat(),
			TyresDamage = reader.GetNextTyresByte(),
			BrakesDamage = reader.GetNextTyresByte(),
			FrontLeftWingDamage = reader.GetNextByte(),
			FrontRightWingDamage = reader.GetNextByte(),
			RearWingDamage = reader.GetNextByte(),
			FloorDamage = reader.GetNextByte(),
			DiffuserDamage = reader.GetNextByte(),
			SidepodDamage = reader.GetNextByte(),
			DrsFault = reader.GetNextBoolean(),
			ErsFault = reader.GetNextBoolean(),
			GearBoxDamage = reader.GetNextByte(),
			EngineDamage = reader.GetNextByte(),
			EngineMGUHWear = reader.GetNextByte(),
			EngineESWear = reader.GetNextByte(),
			EngineCEWear = reader.GetNextByte(),
			EngineICEWear = reader.GetNextByte(),
			EngineMGUKWear = reader.GetNextByte(),
			EngineTCWear = reader.GetNextByte(),
			EngineBlown = reader.GetNextBoolean(),
			EngineSeized = reader.GetNextBoolean(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.WriteTyresFloat(TyresWear);
		writer.WriteTyresByte(TyresDamage);
		writer.WriteTyresByte(BrakesDamage);
		writer.Write(FrontLeftWingDamage);
		writer.Write(FrontRightWingDamage);
		writer.Write(RearWingDamage);
		writer.Write(FloorDamage);
		writer.Write(DiffuserDamage);
		writer.Write(SidepodDamage);
		writer.Write(DrsFault);
		writer.Write(ErsFault);
		writer.Write(GearBoxDamage);
		writer.Write(EngineDamage);
		writer.Write(EngineMGUHWear);
		writer.Write(EngineESWear);
		writer.Write(EngineCEWear);
		writer.Write(EngineICEWear);
		writer.Write(EngineMGUKWear);
		writer.Write(EngineTCWear);
		writer.Write(EngineBlown);
		writer.Write(EngineSeized);
	}
}
