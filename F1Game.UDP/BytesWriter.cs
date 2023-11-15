using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;

namespace F1Game.UDP;

ref struct BytesWriter(byte[] bytes)
{
	readonly Span<byte> bytes = bytes;
	int currentIndex;

	public readonly int CurrentIndex => currentIndex;

	public void WriteByte(byte value)
	{
		bytes[currentIndex++] = value;
	}

	public void WriteBytes(byte[] values)
	{
		foreach (var value in values)
			WriteByte(value);
	}

	public void WriteSByte(sbyte value)
	{
		bytes[currentIndex++] = Unsafe.As<sbyte, byte>(ref value);
	}

	public void WriteBoolean(bool value)
	{
		bytes[currentIndex++] = value ? (byte)1 : (byte)0;
	}

	public void WriteShort(short value)
	{
		BinaryPrimitives.WriteInt16LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.ShortSize;
	}

	public void WriteUShort(ushort value)
	{
		BinaryPrimitives.WriteUInt16LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.UShortSize;
	}

	public void WriteInt(int value)
	{
		BinaryPrimitives.WriteInt32LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.IntSize;
	}

	public void WriteUInt(uint value)
	{
		BinaryPrimitives.WriteUInt32LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.UIntSize;
	}

	public void WriteULong(ulong value)
	{
		BinaryPrimitives.WriteUInt64LittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.ULongSize;
	}

	public void WriteFloat(float value)
	{
		BinaryPrimitives.WriteSingleLittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.FloatSize;
	}

	public void WriteDouble(double value)
	{
		BinaryPrimitives.WriteDoubleLittleEndian(bytes[currentIndex..], value);
		currentIndex += SizeConstants.DoubleSize;
	}

	public void WriteString(string value, int count)
	{
		Encoding.UTF8.GetBytes(value, bytes[currentIndex..]);
		currentIndex += count;
	}

	public void WriteObjects<T>(T[] values) where T : IByteWritable
	{
		foreach (T value in values)
			value.WriteBytes(ref this);
	}

	public void WriteObject<T>(T value) where T : IByteWritable
	{
		value.WriteBytes(ref this);
	}

	public void WriteEnum<T>(T value) where T : struct, Enum, IConvertible
	{
		WriteByte(Unsafe.As<T, byte>(ref value));
	}

	public void WriteEnums<T>(T[] values) where T : struct, Enum, IConvertible
	{
		foreach (T value in values)
			WriteEnum(value);
	}

	public void WriteUIntEnum<T>(T value) where T : struct, Enum, IConvertible
	{
		WriteUInt(Unsafe.As<T, uint>(ref value));
	}
}
