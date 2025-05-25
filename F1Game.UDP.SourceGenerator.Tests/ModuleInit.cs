using System.Runtime.CompilerServices;

namespace F1Game.UDP.SourceGenerator.Tests;

public static class ModuleInit
{
	[ModuleInitializer]
	public static void Init() => VerifySourceGenerators.Initialize();
}
