# F1Game.UDP

[![NuGet](https://img.shields.io/nuget/v/F1Game.UDP.svg)](https://www.nuget.org/packages/F1Game.UDP/)
![BuildStatus](https://github.com/volodymyr-fed/F1Game.UDP/actions/workflows/ci.yaml/badge.svg)

Library to parse UDP telemetry packets from F1 24 game.

# UDP Specification

UDP specification is [here](https://answers.ea.com/t5/General-Discussion/F1-24-UDP-Specification/td-p/13745220).

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
- `LobbyInfoDataPacket`
- `MotionDataPacket`
- `MotionExDataPacket`
- `ParticipantsDataPacket`
- `SessionDataPacket`
- `SessionHistoryDataPacket`
* `TimeTrialDataPacket`
- `TyreSetsDataPacket`

You can access the specific packet data by accessing the corresponding property of the `UnionPacket` struct, you should check what packet type it is first using `PacketType` property.

```
using F1Game.UDP;

UnionPacket packet = arrayOfBytes.ToPacket();

if (packet.PacketType == PacketType.CarTelemetry)
{
	CarTelemetryDataPacket carTelemetryData = packet.CarTelemetryData;
	// Access car telemetry data
}

switch (packet.PacketType)
{
	case PacketType.CarTelemetry:
		CarTelemetryDataPacket carTelemetryData = packet.CarTelemetryData;
		// Access car telemetry data
		break;
	case PacketType.CarStatus:
		CarStatusDataPacket carStatusData = packet.CarStatusData;
		// Access car status data
		break;
	// Add other cases for different packet types
}
```

# Benchmarks

You can check performance of the library by running benchmarks in `F1Game.UDP.Benchmarks` project.

Results on my machine are [here](./docs/F1Game.UDP.Benchmarks.InternalBenchmark-report-github.md).