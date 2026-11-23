using System.Reflection;
using System.Runtime.CompilerServices;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Packets;

namespace F1Game.UDP.Tests;

sealed class UnionFixture
{
	static IEnumerable<TestCaseData> PayloadCases =>
		from unionType in new[] { typeof(UnionPacket), typeof(EventDetails) }
		from constructor in unionType.GetConstructors()
		where constructor.GetParameters().Length == 1
		select new TestCaseData(constructor).SetName($"{unionType.Name}_{constructor.GetParameters()[0].ParameterType.Name}");

	[TestCaseSource(nameof(PayloadCases))]
	public void Payload_AccessorsAgreeAndRejectOtherCases(ConstructorInfo constructor)
	{
		var unionType = constructor.DeclaringType!;
		var payloadType = constructor.GetParameters()[0].ParameterType;
		var payload = Activator.CreateInstance(payloadType)!;
		var union = constructor.Invoke([payload]);
		var value = unionType.GetProperty("Value")!.GetValue(union);

		value.Should().BeOfType(payloadType);
		unionType.GetProperty("HasValue")!.GetValue(union).Should().Be(true);
#if NET11_0_OR_GREATER
		((IUnion)union).Value.Should().Be(value);
#endif

		foreach (var method in unionType.GetMethods().Where(m => m.Name == "TryGetValue"))
		{
			object?[] arguments = [null];
			var matches = method.GetParameters()[0].ParameterType.GetElementType() == payloadType;
			method.Invoke(union, arguments).Should().Be(matches);
			arguments[0].Should().Be(matches ? value : Activator.CreateInstance(method.GetParameters()[0].ParameterType.GetElementType()!));

			var caseType = method.GetParameters()[0].ParameterType.GetElementType()!;
			var legacyMethod = unionType.GetMethod($"TryGet{caseType.Name}")!;
			legacyMethod.GetCustomAttribute<ObsoleteAttribute>()!.Message.Should().Be("Use TryGetValue instead.");
			object?[] legacyArguments = [null];
			legacyMethod.Invoke(union, legacyArguments).Should().Be(matches);
			legacyArguments[0].Should().Be(arguments[0]);
		}
	}

	[TestCase(EventType.SessionStarted)]
	[TestCase(EventType.SessionEnded)]
	[TestCase(EventType.ChequeredFlag)]
	[TestCase(EventType.DRSEnabled)]
	[TestCase(EventType.LightsOut)]
	[TestCase(EventType.RedFlag)]
	[TestCase((EventType)0)]
	[TestCase((EventType)uint.MaxValue)]
	public void EventWithoutPayload_HasNoValue(EventType eventType)
	{
		var details = new EventDetails { EventType = eventType };

		details.HasValue.Should().BeFalse();
		details.Value.Should().BeNull();
		details.TryGetValue(out FastestLapEvent value).Should().BeFalse();
		value.Should().Be(default(FastestLapEvent));
#if NET11_0_OR_GREATER
		(details is null).Should().BeTrue();
#endif
	}

	[Test]
	public void DefaultPacket_ContainsDefaultMotionPacket()
	{
		var packet = default(UnionPacket);

		packet.HasValue.Should().BeTrue();
		packet.Value.Should().Be(default(MotionDataPacket));
		packet.TryGetValue(out MotionDataPacket motion).Should().BeTrue();
		motion.Should().Be(default(MotionDataPacket));
	}

	[Test]
	public void UnknownPacket_HasNoValue()
	{
		var packet = new UnionPacket { PacketType = (PacketType)255 };

		packet.HasValue.Should().BeFalse();
		packet.Value.Should().BeNull();
		packet.TryGetValue(out MotionDataPacket motion).Should().BeFalse();
		motion.Should().Be(default(MotionDataPacket));
	}

#if NET11_0_OR_GREATER
	[Test]
	public void PatternMatching_ExtractsPacketAndNestedEvent()
	{
		var fastestLap = new FastestLapEvent { VehicleIdx = 7, LapTime = 81.5f };
		UnionPacket packet = new EventDataPacket
		{
			Header = new PacketHeader { PacketType = PacketType.Event },
			EventDetails = fastestLap
		};

		var lapTime = packet switch
		{
			EventDataPacket { EventDetails: FastestLapEvent lap } => lap.LapTime,
			_ => -1f
		};

		lapTime.Should().Be(fastestLap.LapTime);
		(packet is MotionDataPacket).Should().BeFalse();
		(packet is null).Should().BeFalse();
		EventDetails details = fastestLap;
		(details is FastestLapEvent { VehicleIdx: 7 }).Should().BeTrue();
		(details is CollisionEvent).Should().BeFalse();
	}
#endif
}
