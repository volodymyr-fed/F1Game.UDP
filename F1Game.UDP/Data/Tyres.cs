using System.Runtime.CompilerServices;

namespace F1Game.UDP.Data;

public readonly record struct Tyres<TValue>(TValue RearLeft, TValue RearRight, TValue FrontLeft, TValue FrontRight);

static class TyresBytesReaderExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<byte> GetNextTyresByte(this ref BytesReader reader)
	{
		return new Tyres<byte>(
			reader.GetNextByte(),
			reader.GetNextByte(),
			reader.GetNextByte(),
			reader.GetNextByte());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<ushort> GetNextTyresUShort(this ref BytesReader reader)
	{
		return new Tyres<ushort>(
			reader.GetNextUShort(),
			reader.GetNextUShort(),
			reader.GetNextUShort(),
			reader.GetNextUShort());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<float> GetNextTyresFloat(this ref BytesReader reader)
	{
		return new Tyres<float>(
			reader.GetNextFloat(),
			reader.GetNextFloat(),
			reader.GetNextFloat(),
			reader.GetNextFloat());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<T> GetNextTyresEnum<T>(this ref BytesReader reader) where T : struct, Enum, IConvertible
	{
		return new Tyres<T>(
			reader.GetNextEnum<T>(),
			reader.GetNextEnum<T>(),
			reader.GetNextEnum<T>(),
			reader.GetNextEnum<T>());
	}
}

static class TyresBytesWriterExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresByte(this ref BytesWriter writer, Tyres<byte> tyres)
	{
		writer.WriteByte(tyres.RearLeft);
		writer.WriteByte(tyres.RearRight);
		writer.WriteByte(tyres.FrontLeft);
		writer.WriteByte(tyres.FrontRight);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresUShort(this ref BytesWriter writer, Tyres<ushort> tyres)
	{
		writer.WriteUShort(tyres.RearLeft);
		writer.WriteUShort(tyres.RearRight);
		writer.WriteUShort(tyres.FrontLeft);
		writer.WriteUShort(tyres.FrontRight);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresFloat(this ref BytesWriter writer, Tyres<float> tyres)
	{
		writer.WriteFloat(tyres.RearLeft);
		writer.WriteFloat(tyres.RearRight);
		writer.WriteFloat(tyres.FrontLeft);
		writer.WriteFloat(tyres.FrontRight);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresEnum<T>(this ref BytesWriter writer, Tyres<T> tyres) where T : struct, Enum, IConvertible
	{
		writer.WriteEnum(tyres.RearLeft);
		writer.WriteEnum(tyres.RearRight);
		writer.WriteEnum(tyres.FrontLeft);
		writer.WriteEnum(tyres.FrontRight);
	}
}
