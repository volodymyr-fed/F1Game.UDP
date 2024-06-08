using System.Runtime.CompilerServices;
using System.Text;

namespace F1Game.UDP;

static class Extensions
{
	public static byte AsByte(this bool value)
	{
		return Unsafe.As<bool, byte>(ref value);
	}

	public static bool AsBool(this byte value)
	{
		return Unsafe.As<byte, bool>(ref value);
	}

	public static string AsString(this byte[] bytes)
	{
		Span<byte> span = bytes;
		return Encoding.UTF8.GetString(span.Trim((byte)'\0'));
	}

	public static byte[] AsBytes(this string value)
	{
		return Encoding.UTF8.GetBytes(value);
	}
}
