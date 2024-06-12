using System.Runtime.CompilerServices;

namespace F1Game.UDP.Data;

#pragma warning disable IDE0044 // Add readonly modifier
[InlineArray(8)]
public struct Array8<T>
{
	public int Length => 8;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}

[InlineArray(48)]
public struct Array48<T>
{
	public int Length => 48;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}

[InlineArray(20)]
public struct Array20<T>
{
	public int Length => 20;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}

[InlineArray(21)]
public struct Array21<T>
{
	public int Length => 21;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}

[InlineArray(22)]
public struct Array22<T>
{
	public int Length => 22;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}

[InlineArray(56)]
public struct Array56<T>
{
	public int Length => 56;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}

[InlineArray(100)]
public struct Array100<T>
{
	public int Length => 100;

	T _0;

	public IEnumerable<T> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}
}
#pragma warning restore IDE0044 // Add readonly modifier
