using System.Runtime.CompilerServices;

namespace F1Game.UDP.Data;

/// <summary>
/// Represents a set of values associated with the four tyres of a vehicle: rear left, rear right, front left, and front
/// right.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with each tyre position.</typeparam>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct Tyres<TValue>()
{
	/// <summary>
	/// Value for the rear left tyre.
	/// </summary>
	public required TValue RearLeft { get; init; }
	/// <summary>
	/// Value for the rear right tyre.
	/// </summary>
	public required TValue RearRight { get; init; }
	/// <summary>
	/// Value for the front left tyre.
	/// </summary>
	public required TValue FrontLeft { get; init; }
	/// <summary>
	/// Value for the front right tyre.
	/// </summary>
	public required TValue FrontRight { get; init; }
}

static class TyresBytesReaderExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<byte> GetNextTyresByte(this ref BytesReader reader)
	{
		return new Tyres<byte>
		{
			RearLeft = reader.GetNextByte(),
			RearRight = reader.GetNextByte(),
			FrontLeft = reader.GetNextByte(),
			FrontRight = reader.GetNextByte()
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<ushort> GetNextTyresUShort(this ref BytesReader reader)
	{
		return new Tyres<ushort>
		{
			RearLeft = reader.GetNextUShort(),
			RearRight = reader.GetNextUShort(),
			FrontLeft = reader.GetNextUShort(),
			FrontRight = reader.GetNextUShort()
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<float> GetNextTyresFloat(this ref BytesReader reader)
	{
		return new Tyres<float>
		{
			RearLeft = reader.GetNextFloat(),
			RearRight = reader.GetNextFloat(),
			FrontLeft = reader.GetNextFloat(),
			FrontRight = reader.GetNextFloat()
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Tyres<T> GetNextTyresEnum<T>(this ref BytesReader reader) where T : struct, Enum, IConvertible
	{
		return new Tyres<T>
		{
			RearLeft = reader.GetNextEnum<T>(),
			RearRight = reader.GetNextEnum<T>(),
			FrontLeft = reader.GetNextEnum<T>(),
			FrontRight = reader.GetNextEnum<T>()
		};
	}
}

static class TyresBytesWriterExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresByte(this ref BytesWriter writer, Tyres<byte> tyres)
	{
		writer.Write(tyres.RearLeft);
		writer.Write(tyres.RearRight);
		writer.Write(tyres.FrontLeft);
		writer.Write(tyres.FrontRight);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresUShort(this ref BytesWriter writer, Tyres<ushort> tyres)
	{
		writer.Write(tyres.RearLeft);
		writer.Write(tyres.RearRight);
		writer.Write(tyres.FrontLeft);
		writer.Write(tyres.FrontRight);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteTyresFloat(this ref BytesWriter writer, Tyres<float> tyres)
	{
		writer.Write(tyres.RearLeft);
		writer.Write(tyres.RearRight);
		writer.Write(tyres.FrontLeft);
		writer.Write(tyres.FrontRight);
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
