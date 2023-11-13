using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;

namespace F1Game.UDP;

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
	public static T[] GetNextObjects<T>(this ref BytesReader reader, int count) where T : IByteParsable<T>
	{
		var array = new T[count];
		var span = new Span<T>(array);

		for (var i = 0; i < span.Length; i++)
			span[i] = T.Parse(ref reader);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetNextObject<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		return T.Parse(ref reader);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] GetNextEnums<T>(this ref BytesReader reader, int count) where T : struct, Enum, IConvertible
	{
		var array = new T[count];
		var span = new Span<T>(array);

		for (var i = 0; i < span.Length; i++)
			span[i] = reader.GetNextEnum<T>();

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetNextEnum<T>(this ref BytesReader reader) where T : struct, Enum, IConvertible
	{
		var byteEnumValue = reader.GetNextByte();
		return Unsafe.As<byte, T>(ref byteEnumValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetNextUIntEnum<T>(this ref BytesReader reader) where T : struct, Enum, IConvertible
	{
		var uintEnumValue = reader.GetNextUInt();
		return Unsafe.As<uint, T>(ref uintEnumValue);
	}
}
