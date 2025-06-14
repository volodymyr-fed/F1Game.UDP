﻿using System.Text;

using F1Game.UDP.Data;

namespace F1Game.UDP.Internal;

static class Extensions
{
	public static string AsString(this Array32<byte> bytes)
	{
		return Encoding.UTF8.GetString(bytes.AsReadOnlySpan().Trim((byte)'\0'));
	}

	public static Array32<byte> AsArray32Bytes(this string value)
	{
		var array = new Array32<byte>();
		Encoding.UTF8.TryGetBytes(value, array, out var _);

		return array;
	}
}
