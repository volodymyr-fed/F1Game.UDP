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
