```

BenchmarkDotNet v0.15.6, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host] : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  NET10  : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  NET8   : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  NET9   : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3


```
| Method     | Job   | Runtime   | Type                | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------- |------ |---------- |-------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| **ReadPacket** | **NET10** | **.NET 10.0** | **Motion**              | **57.41 ns** | **0.222 ns** | **0.197 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Motion              | 60.05 ns | 0.231 ns | 0.205 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Motion              | 58.03 ns | 0.265 ns | 0.248 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **Session**             | **56.08 ns** | **0.258 ns** | **0.242 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Session             | 50.98 ns | 0.142 ns | 0.133 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Session             | 54.99 ns | 0.153 ns | 0.128 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **LapData**             | **57.15 ns** | **0.175 ns** | **0.164 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | LapData             | 59.78 ns | 0.227 ns | 0.213 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | LapData             | 57.41 ns | 0.170 ns | 0.159 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **Event**               | **51.15 ns** | **0.159 ns** | **0.133 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Event               | 45.43 ns | 0.359 ns | 0.336 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Event               | 52.13 ns | 0.196 ns | 0.183 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **Participants**        | **58.79 ns** | **0.281 ns** | **0.219 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Participants        | 55.56 ns | 0.176 ns | 0.165 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Participants        | 57.52 ns | 0.314 ns | 0.294 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarSetups**           | **56.79 ns** | **0.224 ns** | **0.187 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarSetups           | 58.23 ns | 0.408 ns | 0.382 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarSetups           | 56.85 ns | 0.215 ns | 0.201 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarTelemetry**        | **59.80 ns** | **0.300 ns** | **0.281 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarTelemetry        | 62.16 ns | 0.398 ns | 0.372 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarTelemetry        | 58.30 ns | 0.261 ns | 0.218 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarStatus**           | **57.32 ns** | **0.269 ns** | **0.252 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarStatus           | 55.38 ns | 0.212 ns | 0.198 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarStatus           | 64.95 ns | 0.289 ns | 0.270 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **FinalClassification** | **56.70 ns** | **0.220 ns** | **0.206 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | FinalClassification | 58.32 ns | 0.372 ns | 0.348 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | FinalClassification | 57.80 ns | 0.217 ns | 0.203 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **LobbyInfo**           | **55.41 ns** | **0.212 ns** | **0.188 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | LobbyInfo           | 59.69 ns | 0.484 ns | 0.453 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | LobbyInfo           | 56.79 ns | 0.251 ns | 0.235 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarDamage**           | **56.58 ns** | **0.386 ns** | **0.342 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarDamage           | 52.11 ns | 0.173 ns | 0.153 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarDamage           | 56.23 ns | 0.263 ns | 0.246 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **SessionHistory**      | **57.59 ns** | **0.283 ns** | **0.265 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | SessionHistory      | 59.94 ns | 0.537 ns | 0.503 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | SessionHistory      | 58.46 ns | 0.368 ns | 0.344 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **TyreSets**            | **51.77 ns** | **0.239 ns** | **0.223 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | TyreSets            | 46.76 ns | 0.568 ns | 0.531 ns |  1.00 |    0.02 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | TyreSets            | 51.54 ns | 0.186 ns | 0.174 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **MotionEx**            | **51.83 ns** | **0.300 ns** | **0.281 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | MotionEx            | 48.59 ns | 0.445 ns | 0.416 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | MotionEx            | 54.15 ns | 0.233 ns | 0.218 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **TimeTrial**           | **51.56 ns** | **0.344 ns** | **0.322 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | TimeTrial           | 46.21 ns | 0.294 ns | 0.261 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | TimeTrial           | 57.60 ns | 0.173 ns | 0.161 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **LapPositions**        | **56.11 ns** | **0.268 ns** | **0.251 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | LapPositions        | 54.10 ns | 0.352 ns | 0.312 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | LapPositions        | 56.68 ns | 0.178 ns | 0.158 ns |  1.00 |    0.00 |         - |          NA |
