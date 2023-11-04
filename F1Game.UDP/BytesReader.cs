namespace F1Game.UDP;

ref struct BytesReader
{
	readonly byte[] bytes;
	int currentIndex;

	public readonly int CurrentIndex => currentIndex;
	public readonly int TotalCount => bytes.Length;

	public BytesReader(byte[] bytes) : this(bytes, 0) { }

	public BytesReader(byte[] bytes, int startIndex)
	{
		this.bytes = bytes;
		currentIndex = startIndex;
	}

	public ReadOnlySpan<byte> GetNextBytes(int count)
	{
		var startIndex = currentIndex;
		currentIndex += count;

		return new ReadOnlySpan<byte>(bytes, startIndex, count);
	}

	public byte GetNextByte() => bytes[currentIndex++];

	public void Skip(int count) => currentIndex += count;
}
