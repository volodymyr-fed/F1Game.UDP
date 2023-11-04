namespace F1Game.UDP.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class BytesReaderExtensionsFixture
{
	[Test]
	public void GetNextBoolean_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x00, 0xFF };
		var reader = CreateBytesReader(bytes);

		var value1 = reader.GetNextBoolean();
		var value2 = reader.GetNextBoolean();

		value1.Should().BeFalse();
		value2.Should().BeTrue();
	}

	[Test]
	public void GetNextSbyte_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x7F, 0x80 };
		var reader = CreateBytesReader(bytes);

		var value1 = reader.GetNextSbyte();
		var value2 = reader.GetNextSbyte();

		value1.Should().Be(127);
		value2.Should().Be(-128);
	}

	[Test]
	public void GetNextShort_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x01, 0x02 };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextShort();

		value.Should().Be(0x0201);
	}

	[Test]
	public void GetNextUShort_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x01, 0x02 };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextUShort();

		value.Should().Be(0x0201);
	}

	[Test]
	public void GetNextFloat_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0xCD, 0xCC, 0x8C, 0x3F };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextFloat();

		value.Should().BeApproximately(1.1f, 0.0001f);
	}

	[Test]
	public void GetNextInt_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextInt();

		value.Should().Be(0x04030201);
	}

	[Test]
	public void GetNextUInt_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextUInt();

		value.Should().Be(0x04030201u);
	}

	[Test]
	public void GetNextULong_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextULong();

		value.Should().Be(0x0807060504030201ul);
	}

	[Test]
	public void GetNextDouble_ShouldReturnCorrectValue()
	{
		var bytes = new byte[] { 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x0A, 0x40 };
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextDouble();

		value.Should().BeApproximately(3.3, 0.0001);
	}

	[Test]
	public void GetNextString_ShouldReturnCorrectString()
	{
		var bytes = "\0\0Hello, World!\0"u8.ToArray();
		var reader = CreateBytesReader(bytes);

		var value = reader.GetNextString(bytes.Length);

		value.Should().Be("Hello, World!");
	}

	[Test]
	public void GetNextObjects_ShouldReturnArrayOfParsedObjects()
	{
		var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x02, 0x03, 0x04 };
		var reader = CreateBytesReader(bytes);

		var result = reader.GetNextObjects<TestInt>(2);

		result.Should().Equal(new TestInt(0x04030201), new TestInt(0x04030205));
	}

	[Test]
	public void GetNextObject_ShouldReturnParsedObject()
	{
		var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };
		var reader = CreateBytesReader(bytes);

		var result = reader.GetNextObject<TestInt>();

		result.Should().Be(new TestInt(0x04030201));
	}

	[Test]
	public void GetNextEnums_ShouldReturnArrayOfEnums()
	{
		var bytes = new byte[] { 0x01, 0x02, 0x03 };
		var reader = CreateBytesReader(bytes);

		var result = reader.GetNextEnums<TestEnum>(3);

		result.Should().Equal(TestEnum.One, TestEnum.Two, TestEnum.Three);
	}

	[Test]
	public void GetNextEnum_ShouldReturnEnumValue()
	{
		var bytes = new byte[] { 0x02 };
		var reader = CreateBytesReader(bytes);

		var result = reader.GetNextEnum<TestEnum>();

		result.Should().Be(TestEnum.Two);
	}

	[Test]
	public void GetNextUIntEnum_ShouldReturnEnumValue()
	{
		var bytes = new byte[] { 0x02, 0x00, 0x00, 0x00 };
		var reader = CreateBytesReader(bytes);

		var result = reader.GetNextUIntEnum<TestEnum>();

		result.Should().Be(TestEnum.Two);
	}

	static BytesReader CreateBytesReader(byte[] bytes)
	{
		return new BytesReader(bytes);
	}

	enum TestEnum
	{
		One = 1,
		Two = 2,
		Three = 3
	}

	record TestInt(int Value) : IByteParsable<TestInt>
	{
		static TestInt IByteParsable<TestInt>.Parse(ref BytesReader reader)
		{
			return new(reader.GetNextInt());
		}
	}
}
