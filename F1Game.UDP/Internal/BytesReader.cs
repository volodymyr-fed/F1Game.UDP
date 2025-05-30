﻿namespace F1Game.UDP.Internal;

ref struct BytesReader(ReadOnlySpan<byte> bytes, int startIndex)
{
	readonly ReadOnlySpan<byte> spanBytes = bytes;
	int currentIndex = startIndex;

	public readonly int CurrentIndex => currentIndex;
	public readonly int TotalCount => spanBytes.Length;

	public BytesReader(ReadOnlySpan<byte> bytes) : this(bytes, 0) { }

	public ReadOnlySpan<byte> GetNextBytes(int count)
	{
		var startIndex = currentIndex;
		currentIndex += count;

		return spanBytes.Slice(startIndex, count);
	}

	public byte GetNextByte() => spanBytes[currentIndex++];

	public void Skip(int count) => currentIndex += count;
	public void Reset() => currentIndex = 0;
}
