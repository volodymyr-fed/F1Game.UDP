using F1Game.UDP.SourceGenerator.Extensions;

using Microsoft.CodeAnalysis;

namespace F1Game.UDP.SourceGenerator;

sealed record TypeData(string? Namespace, string TypeName, string TypeDeclaration, string TypeMetadataName)
{
	public TypeData(ITypeSymbol typeSymbol) :
		this(
			typeSymbol.ContainingNamespace.ToDisplayString(),
			typeSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
			typeSymbol.GetTypeDeclarationKeyword(),
			typeSymbol.GetFullMetaDataName())
	{ }
}

sealed record GenerationData(TypeData TypeData, int Length, string ElementType, bool ShouldGenerateField)
{
	public GenerationData(ITypeSymbol typeSymbol, int Length, ITypeSymbol ElementType, bool ShouldGenerateField)
		: this(new(typeSymbol), Length, ElementType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat), ShouldGenerateField)
	{ }
}

sealed record BuildTarget(Diagnostic? Diagnostic, GenerationData? GenerationData)
{
	public static implicit operator BuildTarget(Diagnostic diagnostic) => new(diagnostic, null);
	public static implicit operator BuildTarget(GenerationData data) => new(null, data);
}
