using System.Runtime.CompilerServices;

using F1Game.UDP.Data;

namespace F1Game.UDP.Internal;

static class BytesReaderArrayExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] GetNextObjects<T>(this ref BytesReader reader, int count) where T : IByteParsable<T>
	{
		var array = new T[count];

		ref T first = ref MemoryMarshal.GetArrayDataReference(array);

		for (var i = 0; i < count; i++)
		{
			ref T current = ref Unsafe.Add(ref first, i);
			current = T.Parse(ref reader);
		}

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[] GetNextEnums<T>(this ref BytesReader reader, int count) where T : struct, Enum, IConvertible
	{
		var array = new T[count];
		var bytes = reader.GetNextBytes(count);

		MemoryMarshal.Cast<byte, T>(bytes).CopyTo(array);
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array8<T> GetNextArray8Enum<T>(this ref BytesReader reader) where T : struct, Enum, IConvertible
	{
		var array = new Array8<T>();

		var byteValues = reader.GetNextBytes(array.Length);
		var enumValues = MemoryMarshal.Cast<byte, T>(byteValues);

		enumValues.CopyTo(array);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array8<byte> GetNextArray8Bytes(this ref BytesReader reader)
	{
		var array = new Array8<byte>();

		var span = reader.GetNextBytes(array.Length);
		span.CopyTo(array);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array48<byte> GetNextArray48Bytes(this ref BytesReader reader)
	{
		var span = reader.GetNextBytes(48);
		var array = new Array48<byte>();

		span.CopyTo(array);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array8<T> GetNextArray8<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		var array = new Array8<T>();

		for (var i = 0; i < array.Length; i++)
			array[i] = T.Parse(ref reader);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array20<T> GetNextArray20<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		var array = new Array20<T>();

		for (var i = 0; i < array.Length; i++)
			array[i] = T.Parse(ref reader);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array21<T> GetNextArray21<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		var array = new Array21<T>();

		for (var i = 0; i < array.Length; i++)
			array[i] = T.Parse(ref reader);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array22<T> GetNextArray22<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		var array = new Array22<T>();

		for (var i = 0; i < array.Length; i++)
			array[i] = T.Parse(ref reader);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array56<T> GetNextArray56<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		var array = new Array56<T>();

		for (var i = 0; i < array.Length; i++)
			array[i] = T.Parse(ref reader);

		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array100<T> GetNextArray100<T>(this ref BytesReader reader) where T : IByteParsable<T>
	{
		var array = new Array100<T>();

		for (var i = 0; i < array.Length; i++)
			array[i] = T.Parse(ref reader);

		return array;
	}
}
