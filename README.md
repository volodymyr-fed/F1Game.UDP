# F1Game.UDP

[![NuGet](https://img.shields.io/nuget/v/F1Game.UDP.svg)](https://www.nuget.org/packages/F1Game.UDP/)
![BuildStatus](https://github.com/volodymyr-fed/F1Game.UDP/actions/workflows/ci.yaml/badge.svg)

Library to parse UDP telemetry packets from F1 25 game.

# UDP Specification

UDP specification is [here](https://forums.ea.com/blog/f1-games-game-info-hub-en/ea-sports%E2%84%A2-f1%C2%AE25-udp-specification/12187347).

# Versioning

Each major version of the `F1Game.UDP` library is designed to support a specific version of the F1 game. The major version number of the library corresponds to the version of the game it supports. For example, `F1Game.UDP` version 23.x supports F1 23 game, and version 24.x supports F1 24 game and so on.

# Usages

You can parse an array of bytes to packets using the `ToPacket` extension method.
The `ToPacket` method returns a `UnionPacket` struct, which has properties for different types of packets, such as:
- `CarDamageDataPacket`
- `CarSetupDataPacket`
- `CarStatusDataPacket`
- `CarTelemetryDataPacket`
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

First, check the packet type using the `PacketType` property. Then, access the specific packet data by calling the corresponding `TryGet<PacketName>` method of the `UnionPacket` struct.

```
using F1Game.UDP;

UnionPacket packet = arrayOfBytes.ToPacket();

if (packet.TryGetCarTelemetryDataPacket(out var carTelemetryData))
{
	// Access car telemetry data
}

switch (packet.PacketType)
{
	case PacketType.CarTelemetry when packet.TryGetCarTelemetryDataPacket(out var carTelemetryData):
		// Access car telemetry data
		break;
	case PacketType.CarStatus when packet.TryGetCarStatusDataPacket(out var carStatusData):
		// Access car status data
		break;
	// Add other cases for different packet types
}

var someResult = packet.PacketType switch
{
	PacketType.CarTelemetry when packet.TryGetCarTelemetryDataPacket(out var carTelemetryData) => // Access car telemetry data,
	PacketType.CarStatus when packet.TryGetCarStatusDataPacket(out var carStatusData) => // Access car status data,
	_ => "default"
};
```

# Benchmarks

You can check performance of the library by running benchmarks in `F1Game.UDP.Benchmarks` project.

Results on my machine are [here](./docs/F1Game.UDP.Benchmarks.ToPacketBenchmark-report-github.md).