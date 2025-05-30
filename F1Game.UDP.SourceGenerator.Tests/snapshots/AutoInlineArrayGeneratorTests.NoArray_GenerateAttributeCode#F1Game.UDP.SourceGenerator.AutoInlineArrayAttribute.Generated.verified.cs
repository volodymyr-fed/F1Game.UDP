﻿//HintName: F1Game.UDP.SourceGenerator.AutoInlineArrayAttribute.Generated.cs
// <auto-generated/>
#nullable enable

using System;

namespace F1Game.UDP.SourceGenerator;

/// <summary>
/// Source Generator helper attribute. Apply to a partial struct definition
/// to generate an inline array implementation with the specified length.
/// The generator adds the <see cref="System.Runtime.CompilerServices.InlineArrayAttribute"/>,
/// implements <see cref="IEquatable{T}"/>, and provides common boilerplate code.
/// </summary>
/// <remarks>
/// <para>The struct must be declared as partial.</para>
/// <para>The first argument is the desired length (number of elements), must be greater than 0.</para>
/// <para>The second argument is type of instance field. Could be omitted if struct is generic or contains instance field.</para>
/// <para>
/// Field and Type Inference Rules:
/// <list type="number">
/// <item><description>If the partial struct does not contain an instance field, element type should be provided.</description></item>
/// <item><description>If the partial struct contains exactly one instance field (e.g., <c>private byte _element0;</c>), its type is used as the element type, and the generator DOES NOT add a field.</description></item>
/// <item><description>If the partial struct contains zero instance fields AND is generic (e.g., <c>partial struct MyArray&lt;T&gt;</c>), the first type parameter (<c>T</c>) is used as the element type, and the generator ADDS a field (e.g., <c>private T _element0;</c>).</description></item>
/// <item><description>If the partial struct contains zero instance fields AND is NOT generic, it's a compile-time error (element type cannot be inferred).</description></item>
/// <item><description>If the partial struct contains more than one instance field, it's a compile-time error.</description></item>
/// </list>
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
internal sealed class AutoInlineArrayAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="AutoInlineArrayAttribute"/> class.</summary>
	/// <param name="length">The number of elements in the inline array. Must be greater than 0.</param>
	public AutoInlineArrayAttribute(int length, Type? elementType = null)
	{
		if (length <= 0)
			throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");
		Length = length;
		ElementType = elementType;
	}

	/// <summary>Gets the number of elements intended for the inline array.</summary>
	public int Length { get; }

	/// <summary>Gets the type of the element in the inline array.</summary>
	public Type? ElementType { get; init; } = null;
}