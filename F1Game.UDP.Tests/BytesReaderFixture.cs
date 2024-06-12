using F1Game.UDP.Internal;

namespace F1Game.UDP.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class BytesReaderTests
{
	[Test]
	public void CurrentIndex_ShouldReturnZero_WhenNoBytesRead()
	{
		var bytes = new byte[10];
		var reader = new BytesReader(bytes);

		var currentIndex = reader.CurrentIndex;

		currentIndex.Should().Be(0);
	}

	[Test]
	public void CurrentIndex_ShouldReturnCorrectValue_AfterReadingBytes()
	{
		var bytes = new byte[10];
		var reader = new BytesReader(bytes);

		reader.GetNextByte();
		reader.GetNextBytes(3);
		reader.Skip(2);

		var currentIndex = reader.CurrentIndex;

		currentIndex.Should().Be(6);
	}

	[Test]
	public void TotalCount_ShouldReturnCorrectValue()
	{
		var bytes = new byte[10];
		var reader = new BytesReader(bytes);

		var totalCount = reader.TotalCount;

		totalCount.Should().Be(10);
	}

	[Test]
	public void GetNextBytes_ShouldReturnCorrectSlice()
	{
		var bytes = new byte[] { 1, 2, 3, 4, 5 };
		var reader = new BytesReader(bytes);
		reader.Skip(1);

		var slice = reader.GetNextBytes(3);

		slice.ToArray().Should().Equal(new byte[] { 2, 3, 4 });
	}

	[Test]
	public void GetNextByte_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 1, 2, 3, 4, 5 };
		var reader = new BytesReader(bytes);
		reader.Skip(2);

		var value = reader.GetNextByte();

		value.Should().Be(3);
	}

	[Test]
	public void Skip_ShouldIncrementCurrentIndex()
	{
		var bytes = new byte[10];
		var reader = new BytesReader(bytes);

		reader.Skip(3);

		var currentIndex = reader.CurrentIndex;

		currentIndex.Should().Be(3);
	}

	[Test]
	public void Constructor_WithOffset_ShouldSetCurrentIndexToOffset()
	{
		var bytes = new byte[] { 1, 2, 3, 4, 5 };
		var offset = 2;

		var reader = new BytesReader(bytes, offset);

		var currentIndex = reader.CurrentIndex;

		currentIndex.Should().Be(offset);
	}
}
