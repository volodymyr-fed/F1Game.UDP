```

BenchmarkDotNet v0.15.6, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.300
  [Host] : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  NET10  : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  NET8   : .NET 8.0.27 (8.0.27, 8.0.2726.22922), X64 RyuJIT x86-64-v3
  NET9   : .NET 9.0.16 (9.0.16, 9.0.1626.22923), X64 RyuJIT x86-64-v3


```
| Method     | Job   | Runtime   | Type                | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------- |------ |---------- |-------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| **ReadPacket** | **NET10** | **.NET 10.0** | **Motion**              | **58.07 ns** | **0.115 ns** | **0.102 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Motion              | 50.96 ns | 0.227 ns | 0.201 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Motion              | 76.24 ns | 0.356 ns | 0.278 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **Session**             | **68.96 ns** | **0.120 ns** | **0.093 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Session             | 49.64 ns | 0.141 ns | 0.118 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Session             | 57.06 ns | 0.042 ns | 0.035 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **LapData**             | **59.66 ns** | **0.229 ns** | **0.214 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | LapData             | 52.07 ns | 0.081 ns | 0.072 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | LapData             | 61.87 ns | 0.229 ns | 0.203 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **Event**               | **51.86 ns** | **0.106 ns** | **0.094 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Event               | 45.17 ns | 0.036 ns | 0.030 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Event               | 52.69 ns | 0.064 ns | 0.050 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **Participants**        | **60.61 ns** | **0.317 ns** | **0.296 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | Participants        | 65.87 ns | 0.367 ns | 0.344 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | Participants        | 61.58 ns | 0.056 ns | 0.050 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarSetups**           | **57.77 ns** | **0.328 ns** | **0.274 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarSetups           | 50.32 ns | 0.097 ns | 0.086 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarSetups           | 59.00 ns | 0.248 ns | 0.207 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarTelemetry**        | **58.25 ns** | **0.042 ns** | **0.039 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarTelemetry        | 59.32 ns | 0.080 ns | 0.067 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarTelemetry        | 63.13 ns | 0.084 ns | 0.070 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarStatus**           | **61.70 ns** | **1.269 ns** | **1.860 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarStatus           | 60.35 ns | 0.126 ns | 0.112 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarStatus           | 60.12 ns | 0.071 ns | 0.063 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **FinalClassification** | **57.59 ns** | **0.038 ns** | **0.032 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | FinalClassification | 54.88 ns | 0.137 ns | 0.121 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | FinalClassification | 59.26 ns | 0.195 ns | 0.173 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **LobbyInfo**           | **57.91 ns** | **0.179 ns** | **0.159 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | LobbyInfo           | 49.99 ns | 0.057 ns | 0.048 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | LobbyInfo           | 69.24 ns | 0.101 ns | 0.079 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarDamage**           | **57.31 ns** | **0.232 ns** | **0.206 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarDamage           | 49.30 ns | 0.122 ns | 0.095 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarDamage           | 65.49 ns | 0.070 ns | 0.065 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **SessionHistory**      | **63.58 ns** | **0.108 ns** | **0.090 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | SessionHistory      | 60.38 ns | 0.283 ns | 0.265 ns |  1.00 |    0.01 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | SessionHistory      | 61.34 ns | 0.050 ns | 0.042 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **TyreSets**            | **52.52 ns** | **0.197 ns** | **0.184 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | TyreSets            | 45.98 ns | 0.112 ns | 0.093 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | TyreSets            | 53.62 ns | 0.033 ns | 0.026 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **MotionEx**            | **53.40 ns** | **0.126 ns** | **0.111 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | MotionEx            | 45.38 ns | 0.047 ns | 0.042 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | MotionEx            | 53.68 ns | 0.048 ns | 0.037 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **TimeTrial**           | **52.23 ns** | **0.028 ns** | **0.022 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | TimeTrial           | 44.92 ns | 0.098 ns | 0.086 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | TimeTrial           | 52.50 ns | 0.027 ns | 0.025 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **LapPositions**        | **57.56 ns** | **0.036 ns** | **0.028 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | LapPositions        | 52.58 ns | 0.142 ns | 0.126 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | LapPositions        | 58.54 ns | 0.129 ns | 0.100 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| **ReadPacket** | **NET10** | **.NET 10.0** | **CarTelemetry2**       | **53.53 ns** | **0.089 ns** | **0.074 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET8  | .NET 8.0  | CarTelemetry2       | 45.95 ns | 0.042 ns | 0.033 ns |  1.00 |    0.00 |         - |          NA |
|            |       |           |                     |          |          |          |       |         |           |             |
| ReadPacket | NET9  | .NET 9.0  | CarTelemetry2       | 53.19 ns | 0.032 ns | 0.027 ns |  1.00 |    0.00 |         - |          NA |
