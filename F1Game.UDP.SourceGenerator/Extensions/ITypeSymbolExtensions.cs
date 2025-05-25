using Microsoft.CodeAnalysis;

namespace F1Game.UDP.SourceGenerator.Extensions;

static class ITypeSymbolExtensions
{
	public static string GetTypeDeclarationKeyword(this ITypeSymbol symbol)
	{
		return symbol.TypeKind switch
		{
			TypeKind.Struct => symbol.IsRecord ? "record struct" : "struct",
			TypeKind.Class => symbol.IsRecord ? "record" : "class",
			_ => symbol.TypeKind.ToString().ToLowerInvariant(),
		};
	}

	public static string GetFullMetaDataName(this ITypeSymbol symbol)
	{
		return symbol.ContainingNamespace.IsGlobalNamespace
			? symbol.MetadataName
			: $"{symbol.ContainingNamespace}.{symbol.MetadataName}";
	}
}
