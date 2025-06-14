﻿//HintName: MyCode.InlineArray.Generated.cs
// <auto-generated/>
#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MyCode;

/// <summary>
/// Represents an inline array InlineArray with 42 elements of type <see cref="global::MyCode.Element"/>.
/// Provides basic equality comparison and hashing. Access elements using the indexer (e.g., myArray[0]).
/// </summary>
[InlineArray(42)]
partial struct InlineArray
	: IEquatable<InlineArray>
{


	/// <summary>Gets the fixed length of the inline array: 42.</summary>
	public int Length => 42;

	/// <summary>
	/// Returns a <see cref="Span{T}"/> that represents the elements of this inline array.
	/// </summary>
	/// <returns>
	/// A <see cref="Span{T}"/> of length <c>42</c> that provides mutable access to the elements of the inline array.
	/// </returns>
	public Span<global::MyCode.Element> AsSpan()
		=> MemoryMarshal.CreateSpan(ref Unsafe.As<InlineArray, global::MyCode.Element>(ref this), 42);

	/// <summary>
	/// Returns a <see cref="ReadOnlySpan{T}"/> that represents the elements of this inline array.
	/// </summary>
	/// <returns>
	/// A <see cref="ReadOnlySpan{T}"/> of length <c>42</c> that provides read-only access to the elements of the inline array.
	/// </returns>
	public ReadOnlySpan<global::MyCode.Element> AsReadOnlySpan()
		=> MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<InlineArray, global::MyCode.Element>(ref this), 42);

	/// <summary>
	/// Returns an <see cref="IEnumerable{T}"/> that enumerates the elements of this inline array.
	/// </summary>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that iterates over the elements of the inline array in order.
	/// </returns>
	public IEnumerable<global::MyCode.Element> AsEnumerable()
	{
		foreach (var item in this)
			yield return item;
	}

	/// <inheritdoc/>
	public override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is InlineArray other && Equals(other);

	/// <summary>Indicates whether the current inline array is equal to another inline array of the same type by comparing their elements sequentially.</summary>
	/// <param name="other">An inline array to compare with this instance.</param>
	/// <returns><c>true</c> if the current array's elements are equal to the <paramref name="other"/> array's elements; otherwise, <c>false</c>.</returns>
	public bool Equals(InlineArray other)
		=> ((ReadOnlySpan<global::MyCode.Element>)this).SequenceEqual((ReadOnlySpan<global::MyCode.Element>)other);

	/// <inheritdoc/>
	public override int GetHashCode()
	{
		HashCode hashCode = default;
		ReadOnlySpan<global::MyCode.Element> span = this;
		var comparer = EqualityComparer<global::MyCode.Element>.Default;

		foreach (ref readonly global::MyCode.Element item in span)
			hashCode.Add(item, comparer);

		return hashCode.ToHashCode();
	}

	/// <summary>
	/// Creates a new <see cref="InlineArray"/> instance and populates it with elements from the specified <see cref="ReadOnlySpan{T}"/> source.
	/// </summary>
	/// <param name="source">
	/// The sequence of elements to copy into the inline array. If the sequence contains fewer elements than the array's length, the remaining elements are left at their default value.
	/// If the sequence contains more elements than the array's length, the extra elements are ignored.
	/// </param>
	/// <returns>
	/// A new <see cref="InlineArray"/> instance containing elements from <paramref name="source"/>.
	/// </returns>
	public static InlineArray Create(ReadOnlySpan<global::MyCode.Element> source)
	{
		var array = new InlineArray();
		source[..Math.Min(source.Length, 42)].CopyTo(array);
		return array;
	}

	/// <summary>Determines whether two specified instances of <see cref="InlineArray"/> are equal by comparing their elements sequence.</summary>
	/// <param name="left">The first inline array to compare.</param>
	/// <param name="right">The second inline array to compare.</param>
	/// <returns><c>true</c> if the arrays are equal; otherwise, <c>false</c>.</returns>
	public static bool operator ==(InlineArray left, InlineArray right)
		=> left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="InlineArray"/> are not equal by comparing their elements sequence.</summary>
	/// <param name="left">The first inline array to compare.</param>
	/// <param name="right">The second inline array to compare.</param>
	/// <returns><c>true</c> if the arrays are not equal; otherwise, <c>false</c>.</returns>
	public static bool operator !=(InlineArray left, InlineArray right)
		=> !(left == right);

	/// <summary>
	/// Implicitly converts an array of <see cref="global::MyCode.Element"/> to a <see cref="InlineArray"/>.
	/// Copies up to <c>42</c> elements from the source array; extra elements are ignored, and missing elements are default-initialized.
	/// </summary>
	/// <param name="source">
	/// The source array to copy elements from. If <paramref name="source"/> is <c>null</c>, a default-initialized <see cref="InlineArray"/> is returned.
	/// </param>
	/// <returns>
	/// A <see cref="InlineArray"/> containing elements from <paramref name="source"/>.
	/// </returns>
	public static implicit operator InlineArray(global::MyCode.Element[] source)
		=> source is null ? new() : Create(source);

	/// <summary>
	/// Implicitly converts a <see cref="ReadOnlySpan{T}"/> of <see cref="global::MyCode.Element"/> to a <see cref="InlineArray"/>.
	/// Copies up to <c>42</c> elements from the source span; extra elements are ignored, and missing elements are default-initialized.
	/// </summary>
	/// <param name="source">
	/// The source span to copy elements from.
	/// </param>
	/// <returns>
	/// A <see cref="InlineArray"/> containing elements from <paramref name="source"/>.
	/// </returns>
	public static implicit operator InlineArray(ReadOnlySpan<global::MyCode.Element> source)
		=> Create(source);

	/// <summary>
	/// Implicitly converts a <see cref="Span{T}"/> of <see cref="global::MyCode.Element"/> to a <see cref="InlineArray"/>.
	/// Copies up to <c>42</c> elements from the source span; extra elements are ignored, and missing elements are default-initialized.
	/// </summary>
	/// <param name="source">
	/// The source span to copy elements from.
	/// </param>
	/// <returns>
	/// A <see cref="InlineArray"/> containing elements from <paramref name="source"/>.
	/// </returns>
	public static implicit operator InlineArray(Span<global::MyCode.Element> source)
		=> Create(source);
}