using System.Text;

using F1Game.UDP.Data;

namespace F1Game.UDP.Internal;

static class Extensions
{
	public static string AsString(this Array48<byte> bytes)
	{
		Span<byte> bytesSpan = bytes;
		return Encoding.UTF8.GetString(bytesSpan.Trim((byte)'\0'));
	}

	public static Array48<byte> AsArray48Bytes(this string value)
	{
		var array = new Array48<byte>();
		Encoding.UTF8.TryGetBytes(value, array, out var _);

		return array;
	}

	public static Array8<T> ToArray8<T>(this IEnumerable<T> source)
	{
		var array = new Array8<T>();
		var enumerator = source.GetEnumerator();

		for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
			array[i] = enumerator.Current;

		return array;
	}

	public static Array20<T> ToArray20<T>(this IEnumerable<T> source)
	{
		var array = new Array20<T>();
		var enumerator = source.GetEnumerator();

		for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
			array[i] = enumerator.Current;

		return array;
	}

	public static Array22<T> ToArray22<T>(this IEnumerable<T> source)
	{
		var array = new Array22<T>();
		var enumerator = source.GetEnumerator();

		for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
			array[i] = enumerator.Current;

		return array;
	}

	public static Array21<T> ToArray21<T>(this IEnumerable<T> source)
	{
		var array = new Array21<T>();
		var enumerator = source.GetEnumerator();

		for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
			array[i] = enumerator.Current;

		return array;
	}

	public static Array56<T> ToArray56<T>(this IEnumerable<T> source)
	{
		var array = new Array56<T>();
		var enumerator = source.GetEnumerator();

		for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
			array[i] = enumerator.Current;

		return array;
	}

	public static Array100<T> ToArray100<T>(this IEnumerable<T> source)
	{
		var array = new Array100<T>();
		var enumerator = source.GetEnumerator();

		for (var i = 0; i < array.Length && enumerator.MoveNext(); i++)
			array[i] = enumerator.Current;

		return array;
	}
}
