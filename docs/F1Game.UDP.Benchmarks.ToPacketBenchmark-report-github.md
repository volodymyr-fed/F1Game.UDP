```

BenchmarkDotNet v0.16.0-preview.2, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 31.92 GB Total, 14.89 GB Available
.NET SDK 11.0.100
  [Host] : .NET 9.0.23 (9.0.23, 9.0.2326.52216), X64 RyuJIT x86-64-v3
  NET9   : .NET 9.0.23 (9.0.23, 9.0.2326.52216), X64 RyuJIT x86-64-v3
  NET10  : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  NET11  : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v3


```
| Method     | Job   | Runtime   | Type                | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|----------- |------ |---------- |-------------------- |---------:|---------:|---------:|------:|----------:|------------:|
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **Motion**              | **77.78 ns** | **0.235 ns** | **0.208 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | Motion              | 74.58 ns | 1.482 ns | 1.522 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | Motion              | 69.61 ns | 1.028 ns | 0.962 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **Session**             | **71.25 ns** | **0.469 ns** | **0.439 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | Session             | 70.92 ns | 0.267 ns | 0.223 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | Session             | 80.93 ns | 0.421 ns | 0.394 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **LapData**             | **76.67 ns** | **0.352 ns** | **0.329 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | LapData             | 74.89 ns | 0.913 ns | 1.121 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | LapData             | 71.10 ns | 1.139 ns | 1.066 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **Event**               | **62.37 ns** | **0.329 ns** | **0.292 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | Event               | 62.15 ns | 0.562 ns | 0.439 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | Event               | 61.08 ns | 0.268 ns | 0.237 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **Participants**        | **76.87 ns** | **1.346 ns** | **1.259 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | Participants        | 71.59 ns | 0.706 ns | 0.661 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | Participants        | 81.59 ns | 0.954 ns | 0.892 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **CarSetups**           | **74.18 ns** | **0.615 ns** | **0.575 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | CarSetups           | 69.32 ns | 0.425 ns | 0.377 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | CarSetups           | 68.51 ns | 0.789 ns | 0.738 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **CarTelemetry**        | **72.96 ns** | **0.876 ns** | **0.819 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | CarTelemetry        | 93.21 ns | 0.790 ns | 0.739 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | CarTelemetry        | 71.11 ns | 0.827 ns | 0.774 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **CarStatus**           | **74.20 ns** | **0.603 ns** | **0.535 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | CarStatus           | 72.78 ns | 0.760 ns | 0.673 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | CarStatus           | 70.88 ns | 0.607 ns | 0.568 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **FinalClassification** | **80.52 ns** | **0.527 ns** | **0.493 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | FinalClassification | 71.25 ns | 0.797 ns | 0.706 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | FinalClassification | 68.97 ns | 0.278 ns | 0.246 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **LobbyInfo**           | **69.37 ns** | **0.355 ns** | **0.297 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | LobbyInfo           | 70.41 ns | 0.830 ns | 0.693 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | LobbyInfo           | 69.69 ns | 0.636 ns | 0.595 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **CarDamage**           | **71.61 ns** | **0.427 ns** | **0.378 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | CarDamage           | 71.21 ns | 0.828 ns | 0.774 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | CarDamage           | 74.62 ns | 0.295 ns | 0.262 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **SessionHistory**      | **73.38 ns** | **0.638 ns** | **0.565 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | SessionHistory      | 75.77 ns | 1.110 ns | 1.039 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | SessionHistory      | 71.74 ns | 0.326 ns | 0.305 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **TyreSets**            | **67.21 ns** | **1.047 ns** | **0.928 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | TyreSets            | 64.95 ns | 0.643 ns | 0.570 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | TyreSets            | 64.00 ns | 1.270 ns | 1.359 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **MotionEx**            | **65.11 ns** | **0.919 ns** | **0.768 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | MotionEx            | 62.72 ns | 0.447 ns | 0.373 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | MotionEx            | 63.93 ns | 1.253 ns | 1.287 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **TimeTrial**           | **62.81 ns** | **0.559 ns** | **0.467 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | TimeTrial           | 61.51 ns | 0.698 ns | 0.653 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | TimeTrial           | 60.07 ns | 0.266 ns | 0.236 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **LapPositions**        | **75.91 ns** | **0.686 ns** | **0.642 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | LapPositions        | 70.53 ns | 1.399 ns | 1.309 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | LapPositions        | 73.94 ns | 0.209 ns | 0.186 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| **ReadPacket** | **NET9**  | **.NET 9.0**  | **CarTelemetry2**       | **67.67 ns** | **0.511 ns** | **0.453 ns** |  **1.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET10 | .NET 10.0 | CarTelemetry2       | 65.11 ns | 0.450 ns | 0.376 ns |  1.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |           |             |
| ReadPacket | NET11 | .NET 11.0 | CarTelemetry2       | 65.53 ns | 0.678 ns | 0.529 ns |  1.00 |         - |          NA |
