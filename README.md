# F1Game.UDP

[![NuGet](https://img.shields.io/nuget/v/F1Game.UDP.svg)](https://www.nuget.org/packages/F1Game.UDP/)
![BuildStatus](https://github.com/volodymyr-fed/F1Game.UDP/actions/workflows/ci.yaml/badge.svg)

Library to parse UDP telemetry packets from the F1 25 2026 Season Pack packet layout.

# Supported .NET versions

The library targets .NET 9, .NET 10, and .NET 11. .NET 8 is no longer supported.
Building the solution requires the .NET 11 SDK specified in `global.json`; .NET 9 and .NET 10 runtimes are also needed to run all tests.

# UDP Specification

UDP specification is [here](https://forums.ea.com/blog/f1-games-game-info-hub-en/ea-sports%E2%84%A2-f1%C2%AE25-2026-season-pack-udp-specification/12187347).

# Versioning

Each major version of the `F1Game.UDP` library is designed to support a specific version of the F1 game. The major version number of the library corresponds to the version of the game it supports. For example, `F1Game.UDP` version 23.x supports F1 23 game, and version 24.x supports F1 24 game and so on.

# Usages

You can parse an array of bytes to packets using the `ToPacket` extension method.
The `ToPacket` method returns a `UnionPacket` struct, which has properties for different types of packets, such as:
- `CarDamageDataPacket`
- `CarSetupDataPacket`
- `CarStatusDataPacket`
- `CarTelemetryDataPacket`
- `CarTelemetry2DataPacket`
- `EventDataPacket`
- `FinalClassificationDataPacket`
- `LapDataPacket`
- `LapPositionsDataPacket`
- `LobbyInfoDataPacket`
- `MotionDataPacket`
- `MotionExDataPacket`
- `ParticipantsDataPacket`
- `SessionDataPacket`
- `SessionHistoryDataPacket`
- `TimeTrialDataPacket`
- `TyreSetsDataPacket`

First, check the packet type using the `PacketType` property. Then, access the specific packet data by calling `TryGetValue` with an explicitly typed output parameter.

```
using F1Game.UDP;

UnionPacket packet = arrayOfBytes.ToPacket();

if (packet.TryGetValue(out CarTelemetryDataPacket carTelemetryData))
{
	// Access car telemetry data
}

switch (packet.PacketType)
{
	case PacketType.CarTelemetry when packet.TryGetValue(out CarTelemetryDataPacket carTelemetryData):
		// Access car telemetry data
		break;
	case PacketType.CarTelemetry2 when packet.TryGetValue(out CarTelemetry2DataPacket carTelemetry2Data):
			// Access additional 2026 telemetry data
			break;
	case PacketType.CarStatus when packet.TryGetValue(out CarStatusDataPacket carStatusData):
		// Access car status data
		break;
	// Add other cases for different packet types
}

var someResult = packet.PacketType switch
{
	PacketType.CarTelemetry when packet.TryGetValue(out CarTelemetryDataPacket carTelemetryData) => // Access car telemetry data,
	PacketType.CarTelemetry2 when packet.TryGetValue(out CarTelemetry2DataPacket carTelemetry2Data) => // Access additional 2026 telemetry data,
	PacketType.CarStatus when packet.TryGetValue(out CarStatusDataPacket carStatusData) => // Access car status data,
	_ => "default"
};
```

On .NET 11 with C# 15, both `UnionPacket` and `EventDetails` support direct type patterns:

```csharp
if (packet is CarTelemetryDataPacket telemetry)
{
	Console.WriteLine(telemetry.Header.SessionTime);
}

if (packet is EventDataPacket { EventDetails: FastestLapEvent lap })
{
	Console.WriteLine(lap.LapTime);
}
```

Both unions expose `Value`, `HasValue`, and typed `TryGetValue(out T)` overloads.
Type patterns use `TryGetValue` to avoid boxing. Reading `Value` boxes the payload.
Events without a payload (such as session start/end), default `EventDetails`, and unknown discriminators have `HasValue == false` and `Value == null`; check `EventType` to distinguish those events.
A default `UnionPacket` contains a default `MotionDataPacket`, since `PacketType.Motion` is zero.
The existing named `TryGet...` methods are deprecated wrappers around `TryGetValue` on all supported frameworks.

# Benchmarks

You can check performance of the library by running benchmarks in `F1Game.UDP.Benchmarks` project.

Latest results from November 23, 2026, cover .NET 9, .NET 10, and .NET 11 using SDK 11.0.100 and BenchmarkDotNet 0.16.0-preview.2 on an Intel Core i7-10700K:

- [Packet parsing results](./docs/F1Game.UDP.Benchmarks.ToPacketBenchmark-report-github.md)
- [Reader versus marshal results](./docs/F1Game.UDP.Benchmarks.InternalBenchmark-report-github.md)

The [third-party comparison](./docs/F1Game.UDP.Benchmarks.ThirdPartyComparisonBenchmark-report-github.md) contains historical F1 23 results on .NET 8.
