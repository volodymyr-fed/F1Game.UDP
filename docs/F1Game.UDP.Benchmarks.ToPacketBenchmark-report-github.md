```

BenchmarkDotNet v0.15.0, Windows 10 (10.0.19045.5854/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host] : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  NET8   : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  NET9   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2


```
| Method     | Job  | Runtime  | Type                | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------- |----- |--------- |-------------------- |---------:|---------:|---------:|---------:|------:|--------:|----------:|------------:|
| **ReadPacket** | **NET8** | **.NET 8.0** | **Motion**              | **44.91 ns** | **0.823 ns** | **0.770 ns** | **44.64 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | Motion              | 57.44 ns | 1.177 ns | 1.209 ns | 57.64 ns |  1.00 |    0.03 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **Session**             | **40.22 ns** | **0.822 ns** | **0.880 ns** | **39.61 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | Session             | 53.74 ns | 0.889 ns | 0.788 ns | 53.55 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **LapData**             | **47.39 ns** | **0.616 ns** | **0.546 ns** | **47.31 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | LapData             | 56.36 ns | 0.910 ns | 0.806 ns | 56.34 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **Event**               | **36.58 ns** | **0.615 ns** | **0.575 ns** | **36.52 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | Event               | 49.79 ns | 0.843 ns | 0.788 ns | 49.77 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **Participants**        | **53.18 ns** | **0.717 ns** | **0.636 ns** | **53.26 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | Participants        | 58.12 ns | 1.029 ns | 1.185 ns | 58.02 ns |  1.00 |    0.03 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **CarSetups**           | **46.30 ns** | **0.491 ns** | **0.459 ns** | **46.25 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | CarSetups           | 55.72 ns | 0.627 ns | 0.586 ns | 55.70 ns |  1.00 |    0.01 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **CarTelemetry**        | **46.85 ns** | **0.749 ns** | **0.700 ns** | **47.01 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | CarTelemetry        | 60.97 ns | 0.885 ns | 0.828 ns | 60.87 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **CarStatus**           | **53.45 ns** | **0.893 ns** | **0.835 ns** | **52.99 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | CarStatus           | 61.30 ns | 0.871 ns | 0.814 ns | 61.40 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **FinalClassification** | **44.14 ns** | **0.515 ns** | **0.457 ns** | **44.16 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | FinalClassification | 61.60 ns | 0.932 ns | 0.778 ns | 61.49 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **LobbyInfo**           | **43.76 ns** | **0.888 ns** | **0.787 ns** | **43.66 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | LobbyInfo           | 56.42 ns | 1.155 ns | 2.082 ns | 56.33 ns |  1.00 |    0.05 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **CarDamage**           | **49.11 ns** | **0.982 ns** | **1.344 ns** | **48.63 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | CarDamage           | 63.11 ns | 1.284 ns | 2.381 ns | 62.74 ns |  1.00 |    0.05 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **SessionHistory**      | **53.13 ns** | **1.023 ns** | **1.050 ns** | **53.02 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | SessionHistory      | 59.69 ns | 1.009 ns | 0.895 ns | 59.95 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **TyreSets**            | **38.30 ns** | **0.748 ns** | **0.699 ns** | **38.47 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | TyreSets            | 54.29 ns | 0.814 ns | 0.721 ns | 54.42 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **MotionEx**            | **39.44 ns** | **0.790 ns** | **1.055 ns** | **39.33 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | MotionEx            | 53.53 ns | 0.828 ns | 0.734 ns | 53.53 ns |  1.00 |    0.02 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **TimeTrial**           | **36.68 ns** | **0.499 ns** | **0.389 ns** | **36.68 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | TimeTrial           | 53.09 ns | 1.063 ns | 1.524 ns | 52.58 ns |  1.00 |    0.04 |         - |          NA |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| **ReadPacket** | **NET8** | **.NET 8.0** | **LapPositions**        | **54.88 ns** | **1.102 ns** | **1.132 ns** | **54.64 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
|            |      |          |                     |          |          |          |          |       |         |           |             |
| ReadPacket | NET9 | .NET 9.0 | LapPositions        | 57.31 ns | 0.859 ns | 1.117 ns | 57.06 ns |  1.00 |    0.03 |         - |          NA |
