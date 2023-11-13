﻿namespace F1Game.UDP.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class BytesWriterFixture
{
	[Test]
	public void CurrentIndex_ShouldReturnZero_WhenNoBytesWereWritten()
	{
		var bytes = new byte[10];
		var writer = new BytesWriter(bytes);

		var currentIndex = writer.CurrentIndex;

		currentIndex.Should().Be(0);
	}

	[Test]
	public void WriteByte_ShouldWriteByteAndChangeCurrentIndex()
	{
		byte byteToWrite = 251;
		var bytes = new byte[10];
		var writer = new BytesWriter(bytes);

		writer.WriteByte(byteToWrite);

		writer.CurrentIndex.Should().Be(1);
		bytes[0].Should().Be(byteToWrite);
	}

	[Test]
	public void WriteBytes_ShouldWriteBytesAndChangeCurrentIndex()
	{
		var bytesToWrite = new byte[] { 251, 250 };
		var bytes = new byte[10];
		var writer = new BytesWriter(bytes);

		writer.WriteBytes(bytesToWrite);

		writer.CurrentIndex.Should().Be(2);
		bytes[0].Should().Be(bytesToWrite[0]);
		bytes[1].Should().Be(bytesToWrite[1]);
	}

	[Test]
	public void WriteSByte_ShouldWriteSByteAndChangeCurrentIndex()
	{
		sbyte sbyteToWrite = -128;
		var bytes = new byte[10];
		var writer = new BytesWriter(bytes);

		writer.WriteSByte(sbyteToWrite);

		writer.CurrentIndex.Should().Be(1);
		bytes[0].Should().Be(0x80);
	}

	[Test]
	public void WriteBoolean_ShouldWriteBooleanAndChangeCurrentIndex()
	{
		var bytes = new byte[10];
		var writer = new BytesWriter(bytes);

		writer.WriteBoolean(false);
		writer.WriteBoolean(true);

		writer.CurrentIndex.Should().Be(2);
		bytes[0].Should().Be(0);
		bytes[1].Should().Be(1);
	}

	[Test]
	public void WriteShort_ShouldWriteShortAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0, 0 };
		var bytes = new byte[4];
		var writer = new BytesWriter(bytes);

		writer.WriteShort(0x0201);

		writer.CurrentIndex.Should().Be(2);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteUShort_ShouldWriteUShortAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0, 0 };
		var bytes = new byte[4];
		var writer = new BytesWriter(bytes);

		writer.WriteUShort(0x0201);

		writer.CurrentIndex.Should().Be(2);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteFloat_ShouldWriteFloatAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0xCD, 0xCC, 0x8C, 0x3F, 0 };
		var bytes = new byte[5];
		var writer = new BytesWriter(bytes);

		writer.WriteFloat(1.1f);

		writer.CurrentIndex.Should().Be(4);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteInt_ShouldWriteIntAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0 };
		var bytes = new byte[5];
		var writer = new BytesWriter(bytes);

		writer.WriteInt(0x04030201);

		writer.CurrentIndex.Should().Be(4);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteUInt_ShouldWriteUIntAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0 };
		var bytes = new byte[5];
		var writer = new BytesWriter(bytes);

		writer.WriteUInt(0x04030201);

		writer.CurrentIndex.Should().Be(4);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteULong_ShouldWriteULongAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0 };
		var bytes = new byte[9];
		var writer = new BytesWriter(bytes);

		writer.WriteULong(0x0807060504030201ul);

		writer.CurrentIndex.Should().Be(8);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteDouble_ShouldWriteDoubleAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x0A, 0x40, 0 };
		var bytes = new byte[9];
		var writer = new BytesWriter(bytes);

		writer.WriteDouble(3.3);

		writer.CurrentIndex.Should().Be(8);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteString_ShouldWriteStringAndChangeCurrentIndex()
	{
		var expectedBytes = "Hello, World!\0"u8.ToArray();
		var bytes = new byte[14];
		var writer = new BytesWriter(bytes);

		writer.WriteString("Hello, World!", 14);

		writer.CurrentIndex.Should().Be(14);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteObjects_ShouldWriteObjectsAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x02, 0x03, 0x04, 0 };
		var bytes = new byte[9];
		var writer = new BytesWriter(bytes);

		writer.WriteObjects(new TestInt[] { new(0x04030201), new(0x04030205) });

		writer.CurrentIndex.Should().Be(8);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteObject_ShouldWriteObjectAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0 };
		var bytes = new byte[5];
		var writer = new BytesWriter(bytes);

		writer.WriteObject(new TestInt(0x04030201));

		writer.CurrentIndex.Should().Be(4);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteEnums_ShouldWriteEnumsAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x01, 0x02, 0x03, 0 };
		var bytes = new byte[4];
		var writer = new BytesWriter(bytes);

		writer.WriteEnums(new[] { TestEnum.One, TestEnum.Two, TestEnum.Three });

		writer.CurrentIndex.Should().Be(3);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteEnum_ShouldWriteEnumAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x02, 0 };
		var bytes = new byte[2];
		var writer = new BytesWriter(bytes);

		writer.WriteEnum(TestEnum.Two);

		writer.CurrentIndex.Should().Be(1);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	[Test]
	public void WriteUIntEnum_ShouldWriteUIntEnumAndChangeCurrentIndex()
	{
		var expectedBytes = new byte[] { 0x02, 0x00, 0x00, 0x00, 0 };
		var bytes = new byte[5];
		var writer = new BytesWriter(bytes);

		writer.WriteUIntEnum(TestEnum.Two);

		writer.CurrentIndex.Should().Be(4);
		bytes.Should().BeEquivalentTo(expectedBytes, options => options.WithStrictOrdering());
	}

	enum TestEnum
	{
		One = 1,
		Two = 2,
		Three = 3
	}

	record TestInt(int Value) : IByteWritable
	{
		public void WriteBytes(ref BytesWriter writer)
		{
			writer.WriteInt(Value);
		}
	}
}
