using System.Reflection;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace F1Game.UDP.SourceGenerator.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class AutoInlineArrayGeneratorTests
{
	readonly VerifySettings _settings = new();

	public AutoInlineArrayGeneratorTests()
	{
		_settings.UseDirectory("snapshots");
	}

	[Test]
	public Task NoArray_GenerateAttributeCode()
	{
		var inputCode = """
			namespace MyCode;

			public class Program
			{
				public static void Main(string[] args)
				{
				}
			}
			""";

		return Verify(RunGenerator<AutoInlineArrayGenerator>(inputCode), _settings);
	}

	[Test]
	public Task GenericArray_GeneratesArrayCode()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(69)]
			public partial struct MyInlineArray<T> where T : class;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task GenericArrayWithInstanceField_GeneratesArrayCode()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(69)]
			public partial record struct MyInlineArray<T, T2> where T : class
			{
				private T2 _field;
			}
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task GenericArrayWithTypeInAttribute_GeneratesArrayCode()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(69, typeof(double))]
			public partial record struct MyInlineArray<T, T2, T3> where T : class;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithField_GeneratesArrayCode()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			public class Element;

			[AutoInlineArray(42)]
			public partial struct InlineArray
			{
				private Element _field;
			}
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithTypeInAttribute_GeneratesArrayCode()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(42, typeof(byte))]
			public partial record struct ByteInlineArray;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithTypeInAttributeAndField_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(42, typeof(byte))]
			public partial struct ByteInlineArray
			{
				private byte _field;
			}
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task NonGenericArrayWithoutTypeInAttributeAndWithoutField_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(42)]
			public partial struct ByteInlineArray;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithTwoAttributes_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(42)]
			[AutoInlineArray(69)]
			public partial struct InlineArray<T>;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithTwoInstanceFields_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(42)]
			public partial struct InlineArray
			{
				private int _field1;
				private int _field2;
			}
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithNegativeLength_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(-42)]
			public partial struct InlineArray<T>;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayWithZeroLength_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(0)]
			public partial struct InlineArray<T>;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	[Test]
	public Task ArrayIsNotPartial_AddsDiagnostic()
	{
		var inputCode = """
			using F1Game.UDP.SourceGenerator;

			namespace MyCode;

			[AutoInlineArray(42)]
			public struct InlineArray<T>;
			""";

		var runResult = RunGenerator<AutoInlineArrayGenerator>(inputCode);

		return Verify(runResult, _settings);
	}

	static GeneratorDriverRunResult RunGenerator<T>(string inputCode) where T : IIncrementalGenerator, new()
	{
		var compilation = CSharpCompilation.Create("compilation",
			[CSharpSyntaxTree.ParseText(inputCode)],
			[MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location)],
			new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)); ;

		var driver = CSharpGeneratorDriver.Create(new T().AsSourceGenerator())
			.RunGenerators(compilation);

		return driver.GetRunResult();
	}
}
