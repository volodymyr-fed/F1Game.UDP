using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;

using F1Game.UDP.Data;

namespace F1Game.UDP.Internal;

static class BytesReaderExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetNextBoolean(this ref BytesReader reader)
	{
		return reader.GetNextByte() > 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte GetNextSbyte(this ref BytesReader reader)
	{
		var byteValue = reader.GetNextByte();
		return Unsafe.As<byte, sbyte>(ref byteValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short GetNextShort(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadInt16LittleEndian(reader.GetNextBytes(SizeConstants.ShortSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort GetNextUShort(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadUInt16LittleEndian(reader.GetNextBytes(SizeConstants.UShortSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float GetNextFloat(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadSingleLittleEndian(reader.GetNextBytes(SizeConstants.FloatSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetNextInt(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadInt32LittleEndian(reader.GetNextBytes(SizeConstants.IntSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint GetNextUInt(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadUInt32LittleEndian(reader.GetNextBytes(SizeConstants.UIntSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong GetNextULong(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadUInt64LittleEndian(reader.GetNextBytes(SizeConstants.ULongSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double GetNextDouble(this ref BytesReader reader)
	{
		return BinaryPrimitives.ReadDoubleLittleEndian(reader.GetNextBytes(SizeConstants.DoubleSize));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string GetNextString(this ref BytesReader reader, int count)
	{
		return Encoding.UTF8.GetString(reader.GetNextBytes(count).Trim((byte)'\0'));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetNextObject<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		return T.Parse(ref reader);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetNextEnum<T>(this ref BytesReader reader) where T : struct, Enum, IConvertible
	{
		var type = Enum.GetUnderlyingType(typeof(T));

		if (type == typeof(byte))
		{
			var byteEnumValue = reader.GetNextByte();
			return Unsafe.As<byte, T>(ref byteEnumValue);
		}

		if (type == typeof(sbyte))
		{
			var sbyteEnumValue = reader.GetNextSbyte();
			return Unsafe.As<sbyte, T>(ref sbyteEnumValue);
		}

		if (type == typeof(short))
		{
			var shortEnumValue = reader.GetNextShort();
			return Unsafe.As<short, T>(ref shortEnumValue);
		}

		if (type == typeof(ushort))
		{
			var ushortEnumValue = reader.GetNextUShort();
			return Unsafe.As<ushort, T>(ref ushortEnumValue);
		}

		if (type == typeof(int))
		{
			var intEnumValue = reader.GetNextInt();
			return Unsafe.As<int, T>(ref intEnumValue);
		}

		if (type == typeof(uint))
		{
			var uintEnumValue = reader.GetNextUInt();
			return Unsafe.As<uint, T>(ref uintEnumValue);
		}

		throw new NotSupportedException($"Unsupported enum underlying type '{type}' for {typeof(T)}.");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReadOnlySpan<T> GetNextObjects<T>(this ref BytesReader reader, int length, Array100<T> buffer = default) where T : IByteParsable<T>
	{
		for (var i = 0; i < length; i++)
			buffer[i] = T.Parse(ref reader);

		return buffer.AsReadOnlySpan()[..length];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReadOnlySpan<T> GetNextEnums<T>(this ref BytesReader reader, int length, Array100<T> buffer = default) where T : struct, Enum, IConvertible
	{
		for (var i = 0; i < length; i++)
			buffer[i] = reader.GetNextEnum<T>();

		return buffer.AsReadOnlySpan()[..length];
	}
}
