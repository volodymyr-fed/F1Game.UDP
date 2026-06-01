using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace F1Game.UDP.Internal;

ref struct BytesWriter(byte[] bytes)
{
	readonly Span<byte> bytes = bytes;
	int currentIndex;

	public readonly int CurrentIndex => currentIndex;

	public void Write(byte value)
	{
		bytes[currentIndex++] = value;
	}

	public void Write(ReadOnlySpan<byte> values)
	{
		foreach (var value in values)
			Write(value);
	}

	public void Write(sbyte value)
	{
		bytes[currentIndex++] = Unsafe.As<sbyte, byte>(ref value);
	}

	public void Write(bool value)
	{
		bytes[currentIndex++] = Unsafe.As<bool, byte>(ref value);
	}

	public void Write(short value)
	{
		BinaryPrimitives.WriteInt16LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.ShortSize;
	}

	public void Write(ushort value)
	{
		BinaryPrimitives.WriteUInt16LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.UShortSize;
	}

	public void Write(int value)
	{
		BinaryPrimitives.WriteInt32LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.IntSize;
	}

	public void Write(uint value)
	{
		BinaryPrimitives.WriteUInt32LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.UIntSize;
	}

	public void Write(ulong value)
	{
		BinaryPrimitives.WriteUInt64LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.ULongSize;
	}

	public void Write(float value)
	{
		BinaryPrimitives.WriteSingleLittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.FloatSize;
	}

	public void Write(double value)
	{
		BinaryPrimitives.WriteDoubleLittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.DoubleSize;
	}

	public void Write<T>(T value) where T : IByteWritable
	{
		value.WriteBytes(ref this);
	}

	public void Write<T>(ReadOnlySpan<T> array) where T : IByteWritable
	{
		foreach (var value in array)
			value.WriteBytes(ref this);
	}

	public void WriteEnum<T>(T value) where T : struct, Enum, IConvertible
	{
		var type = Enum.GetUnderlyingType(typeof(T));

		if (type == typeof(byte))
			Write(Unsafe.As<T, byte>(ref value));
		else if (type == typeof(sbyte))
			Write(Unsafe.As<T, sbyte>(ref value));
		else if (type == typeof(short))
			Write(Unsafe.As<T, short>(ref value));
		else if (type == typeof(ushort))
			Write(Unsafe.As<T, ushort>(ref value));
		else if (type == typeof(int))
			Write(Unsafe.As<T, int>(ref value));
		else if (type == typeof(uint))
			Write(Unsafe.As<T, uint>(ref value));
		else
			throw new NotSupportedException($"Unsupported enum underlying type '{type}' for {typeof(T)}.");
	}

	public void WriteEnums<T>(ReadOnlySpan<T> values) where T : struct, Enum, IConvertible
	{
		foreach (T value in values)
			WriteEnum(value);
	}
}
