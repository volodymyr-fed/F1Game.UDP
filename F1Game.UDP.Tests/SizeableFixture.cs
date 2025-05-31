using System.Reflection;
using System.Runtime.InteropServices;

using F1Game.UDP.Internal;

namespace F1Game.UDP.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class SizeableFixture
{
	static readonly MethodInfo ShouldHaveCorrectSizeMethod = typeof(SizeableFixture).GetMethod(nameof(ShouldHaveCorrectSize), BindingFlags.NonPublic | BindingFlags.Instance)!;

	[TestCaseSource(nameof(PacketSizeableTypes))]
	public void Packet_ShouldHaveCorrectSize(Type sizableType)
	{
		ShouldHaveCorrectSizeMethod.MakeGenericMethod(sizableType).Invoke(this, null);
	}

	[TestCaseSource(nameof(EventSizeableTypes))]
	public void Event_ShouldHaveCorrectSize(Type sizableType)
	{
		ShouldHaveCorrectSizeMethod.MakeGenericMethod(sizableType).Invoke(this, null);
	}

	[TestCaseSource(nameof(DataSizeableTypes))]
	public void Data_ShouldHaveCorrectSize(Type sizableType)
	{
		ShouldHaveCorrectSizeMethod.MakeGenericMethod(sizableType).Invoke(this, null);
	}

	static IEnumerable<Type> SizeableTypes => typeof(ISizeable).Assembly.GetTypes()
		.Where(t => t.IsValueType && !t.IsAbstract && typeof(ISizeable).IsAssignableFrom(t));

	static IEnumerable<Type> PacketSizeableTypes => SizeableTypes.Where(x => x.Namespace?.EndsWith(nameof(Packets)) ?? false);
	static IEnumerable<Type> EventSizeableTypes => SizeableTypes.Where(x => x.Namespace?.EndsWith(nameof(Events)) ?? false);
	static IEnumerable<Type> DataSizeableTypes => SizeableTypes.Where(x => x.Namespace?.EndsWith(nameof(Data)) ?? false);

	void ShouldHaveCorrectSize<T>() where T : struct, ISizeable
	{
		var defaultValue = default(T);
		var structSpan = MemoryMarshal.CreateSpan(ref defaultValue, 1);
		var bytesStructSpan = MemoryMarshal.AsBytes(structSpan);

		bytesStructSpan.Length.Should().Be(T.Size);
	}
}
