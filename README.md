# F1Game.UDP

Library to parse UDP telemetry packets from F1 23 game.

# UDP Specification

UDP specification is [here](https://answers.ea.com/t5/General-Discussion/F1-23-UDP-Specification/td-p/12632888).

# Usages

You can parse an array of bytes to packets with `ToPacket` extension method.
It returns instance of one of the classes:
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