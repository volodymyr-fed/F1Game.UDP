```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300
  [Host] : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  NET8   : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=NET8  Runtime=.NET 8.0  

```
| Method               | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |-------------------- |------------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ReadF1GameUDPReader**  | **Motion**              |   **941.13 ns** | **11.378 ns** | **10.087 ns** | **20.97** |    **0.26** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Motion              |    44.90 ns |  0.317 ns |  0.265 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **Session**             | **1,104.96 ns** |  **1.141 ns** |  **1.012 ns** | **27.24** |    **0.10** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Session             |    40.56 ns |  0.149 ns |  0.132 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **LapData**             | **1,366.87 ns** |  **0.619 ns** |  **0.579 ns** | **33.46** |    **0.34** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | LapData             |    40.85 ns |  0.481 ns |  0.427 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **Event**               |   **365.66 ns** |  **0.590 ns** |  **0.461 ns** | **10.79** |    **0.01** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Event               |    33.89 ns |  0.026 ns |  0.022 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **Participants**        |   **753.83 ns** |  **7.301 ns** |  **6.829 ns** | **18.47** |    **0.16** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Participants        |    40.85 ns |  0.255 ns |  0.213 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarSetups**           | **1,090.62 ns** |  **8.947 ns** |  **8.369 ns** | **27.99** |    **0.20** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarSetups           |    38.99 ns |  0.122 ns |  0.102 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarTelemetry**        | **1,236.30 ns** |  **1.205 ns** |  **0.941 ns** | **27.27** |    **0.08** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarTelemetry        |    45.33 ns |  0.166 ns |  0.139 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarStatus**           | **1,149.97 ns** |  **9.092 ns** |  **8.505 ns** | **25.71** |    **0.38** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarStatus           |    44.74 ns |  0.588 ns |  0.550 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **FinalClassification** |   **780.27 ns** |  **0.749 ns** |  **0.701 ns** | **18.29** |    **0.03** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | FinalClassification |    42.67 ns |  0.064 ns |  0.050 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **LobbyInfo**           |   **695.22 ns** |  **2.963 ns** |  **2.474 ns** | **13.39** |    **0.05** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | LobbyInfo           |    51.94 ns |  0.080 ns |  0.063 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarDamage**           | **1,208.53 ns** |  **2.006 ns** |  **1.566 ns** | **29.50** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarDamage           |    40.97 ns |  0.071 ns |  0.060 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **SessionHistory**      | **1,322.21 ns** |  **1.463 ns** |  **1.297 ns** | **28.61** |    **0.34** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | SessionHistory      |    46.18 ns |  0.609 ns |  0.570 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **TyreSets**            |   **546.73 ns** |  **1.664 ns** |  **1.299 ns** | **14.95** |    **0.20** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | TyreSets            |    36.49 ns |  0.453 ns |  0.424 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **MotionEx**            |   **408.82 ns** |  **0.429 ns** |  **0.381 ns** | **11.61** |    **0.02** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | MotionEx            |    35.21 ns |  0.037 ns |  0.035 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **TimeTrial**           |   **381.71 ns** |  **0.588 ns** |  **0.491 ns** | **10.81** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | TimeTrial           |    35.32 ns |  0.168 ns |  0.131 ns |  1.00 |    0.00 |         - |          NA |
