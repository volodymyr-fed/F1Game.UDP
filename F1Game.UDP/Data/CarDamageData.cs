namespace F1Game.UDP.Data;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarDamageData() : IByteParsable<CarDamageData>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 42;

	/// <summary>
	/// Tyre wear (percentage).
	/// </summary>
	public Tyres<float> TyresWear { get; init; }
	/// <summary>
	/// Tyre damage (percentage).
	/// </summary>
	public Tyres<byte> TyresDamage { get; init; }
	/// <summary>
	/// Brakes damage (percentage).
	/// </summary>
	public Tyres<byte> BrakesDamage { get; init; }
	/// <summary>
	/// Front left wing damage (percentage).
	/// </summary>
	public byte FrontLeftWingDamage { get; init; }
	/// <summary>
	/// Front right wing damage (percentage).
	/// </summary>
	public byte FrontRightWingDamage { get; init; }
	/// <summary>
	/// Rear wing damage (percentage).
	/// </summary>
	public byte RearWingDamage { get; init; }
	/// <summary>
	/// Floor damage (percentage).
	/// </summary>
	public byte FloorDamage { get; init; }
	/// <summary>
	/// Diffuser damage (percentage).
	/// </summary>
	public byte DiffuserDamage { get; init; }
	/// <summary>
	/// Sidepod damage (percentage).
	/// </summary>
	public byte SidepodDamage { get; init; }
	/// <summary>
	/// Indicator for DRS fault
	/// </summary>
	public bool DrsFault { get; init; }
	/// <summary>
	/// Indicator for ERS fault
	/// </summary>
	public bool ErsFault { get; init; }
	/// <summary>
	/// Gear box damage (percentage).
	/// </summary>
	public byte GearBoxDamage { get; init; }
	/// <summary>
	/// Engine damage (percentage).
	/// </summary>
	public byte EngineDamage { get; init; }
	/// <summary>
	/// Engine wear MGU-H (percentage).
	/// </summary>
	public byte EngineMGUHWear { get; init; }
	/// <summary>
	/// Engine wear ES (percentage).
	/// </summary>
	public byte EngineESWear { get; init; }
	/// <summary>
	/// Engine wear CE (percentage).
	/// </summary>
	public byte EngineCEWear { get; init; }
	/// <summary>
	/// Engine wear ICE (percentage).
	/// </summary>
	public byte EngineICEWear { get; init; }
	/// <summary>
	/// Engine wear MGU-K (percentage).
	/// </summary>
	public byte EngineMGUKWear { get; init; }
	/// <summary>
	/// Engine wear TC (percentage).
	/// </summary>
	public byte EngineTCWear { get; init; }
	/// <summary>
	/// Engine blown
	/// </summary>
	public bool EngineBlown { get; init; }
	/// <summary>
	/// Engine seized
	/// </summary>
	public bool EngineSeized { get; init; }

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
