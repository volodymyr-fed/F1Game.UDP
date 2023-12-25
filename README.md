# F1Game.UDP

Library to parse UDP telemetry packets from F1 23 game.

# UDP Specification

UDP specification is [here](https://answers.ea.com/t5/General-Discussion/F1-23-UDP-Specification/td-p/12632888).

# Usages

You can parse array to packets with `ToPacket` extension method.
It will be instance of one of structs:
* `CarDamageDataPacket`
* `CarSetupDataPacket`
* `CarStatusDataPacket`
* `CarTelemetryDataPacket`
* `EventDataPacket`
* `FinalClassificationDataPacket`
* `LapDataPacket`
* `LobbyInfoDataPacket`
* `MotionDataPacket`
* `MotionExDataPacket`
* `ParticipantsDataPacket`
* `SessionDataPacket`
* `SessionHistoryDataPacket`
* `TyreSetsDataPacket`

```
using F1Game.UDP;

IPacket packet = arrayOfBytes.ToPacket();
```