```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300-preview.24203.14
  [Host] : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  NET8   : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2

Job=NET8  Runtime=.NET 8.0  

```
| Method          | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------- |-------------------- |------------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ReadF1GameUDP**   | **Motion**              |   **181.83 ns** |  **3.693 ns** |  **8.918 ns** |  **1.00** |    **0.00** | **0.1674** |      **-** |    **1400 B** |        **1.00** |
| ReadF1Sharp     | Motion              |   241.37 ns |  4.530 ns |  4.237 ns |  1.26 |    0.03 | 0.1731 |      - |    1448 B |        1.03 |
| ReadF1Simracing | Motion              |   417.57 ns |  4.488 ns |  4.198 ns |  2.17 |    0.05 | 0.2675 | 0.0019 |    2240 B |        1.60 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **Session**             |   **260.35 ns** |  **4.192 ns** |  **3.922 ns** |  **1.00** |    **0.00** | **0.0877** |      **-** |     **736 B** |        **1.00** |
| ReadF1Sharp     | Session             |   325.82 ns |  3.782 ns |  3.537 ns |  1.25 |    0.02 | 0.0868 |      - |     728 B |        0.99 |
| ReadF1Simracing | Session             |   636.82 ns |  6.443 ns |  6.027 ns |  2.45 |    0.04 | 0.3414 | 0.0029 |    2856 B |        3.88 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **LapData**             |   **174.12 ns** |  **3.338 ns** |  **3.279 ns** |  **1.00** |    **0.00** | **0.1414** |      **-** |    **1184 B** |        **1.00** |
| ReadF1Sharp     | LapData             |   229.35 ns |  3.303 ns |  3.090 ns |  1.32 |    0.02 | 0.1471 |      - |    1232 B |        1.04 |
| ReadF1Simracing | LapData             |   469.79 ns |  6.576 ns |  5.829 ns |  2.70 |    0.04 | 0.2460 | 0.0010 |    2064 B |        1.74 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **Event**               |    **30.39 ns** |  **0.657 ns** |  **0.730 ns** |  **1.00** |    **0.00** | **0.0114** |     **-**  |      **96 B** |        **1.00** |
| ReadF1Sharp     | Event               |   164.62 ns |  2.106 ns |  1.970 ns |  5.44 |    0.17 | 0.0181 |      - |     152 B |        1.58 |
| ReadF1Simracing | Event               |   213.57 ns |  1.784 ns |  1.669 ns |  7.05 |    0.20 | 0.0458 |      - |     384 B |        4.00 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **Participants**        |   **483.75 ns** |  **8.880 ns** |  **8.307 ns** |  **1.00** |    **0.00** | **0.2613** | **0.0019** |    **2192 B** |        **1.00** |
| ReadF1Sharp     | Participants        | 2,490.59 ns | 25.628 ns | 23.972 ns |  5.15 |    0.09 | 0.3929 | 0.0038 |    3296 B |        1.50 |
| ReadF1Simracing | Participants        | 1,201.94 ns | 11.894 ns | 11.126 ns |  2.49 |    0.04 | 0.4768 | 0.0057 |    4000 B |        1.82 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarSetups**           |   **173.84 ns** |  **3.040 ns** |  **2.843 ns** |  **1.00** |    **0.00** | **0.1385** |      **-** |    **1160 B** |        **1.00** |
| ReadF1Sharp     | CarSetups           |   233.99 ns |  2.894 ns |  2.707 ns |  1.35 |    0.02 | 0.1366 |      - |    1144 B |        0.99 |
| ReadF1Simracing | CarSetups           |   425.20 ns |  5.392 ns |  5.043 ns |  2.45 |    0.04 | 0.2465 | 0.0010 |    2064 B |        1.78 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarTelemetry**        |   **173.61 ns** |  **2.005 ns** |  **1.777 ns** |  **1.00** |    **0.00** | **0.1674** |      **-** |    **1400 B** |        **1.00** |
| ReadF1Sharp     | CarTelemetry        | 6,731.60 ns | 42.860 ns | 37.995 ns | 38.78 |    0.45 | 0.6180 | 0.0076 |    5232 B |        3.74 |
| ReadF1Simracing | CarTelemetry        | 1,045.92 ns | 20.841 ns | 41.138 ns |  6.10 |    0.26 | 0.7095 | 0.0134 |    5936 B |        4.24 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarStatus**           |   **190.73 ns** |  **3.873 ns** |  **7.369 ns** |  **1.00** |    **0.00** | **0.1547** |      **-** |    **1296 B** |        **1.00** |
| ReadF1Sharp     | CarStatus           |   249.35 ns |  3.044 ns |  2.699 ns |  1.28 |    0.04 | 0.1607 |      - |    1344 B |        1.04 |
| ReadF1Simracing | CarStatus           |   454.14 ns |  6.951 ns |  6.162 ns |  2.33 |    0.05 | 0.2460 | 0.0010 |    2064 B |        1.59 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **FinalClassification** |   **785.16 ns** | **11.112 ns** |  **9.850 ns** |  **1.00** |    **0.00** | **0.3881** | **0.0038** |    **3248 B** |        **1.00** |
| ReadF1Sharp     | FinalClassification | 4,777.52 ns | 32.480 ns | 30.382 ns |  6.08 |    0.10 | 0.3891 |      - |    3296 B |        1.01 |
| ReadF1Simracing | FinalClassification |   883.96 ns | 10.269 ns |  9.606 ns |  1.13 |    0.02 | 0.4778 |      - |    4000 B |        1.23 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **LobbyInfo**           |   **344.91 ns** |  **3.633 ns** |  **3.398 ns** |  **1.00** |    **0.00** | **0.2408** | **0.0014** |    **2016 B** |        **1.00** |
| ReadF1Sharp     | LobbyInfo           | 2,440.62 ns | 20.986 ns | 19.630 ns |  7.08 |    0.11 | 0.3700 | 0.0038 |    3120 B |        1.55 |
| ReadF1Simracing | LobbyInfo           |          NA |        NA |        NA |     ? |       ? |     NA |     NA |        NA |           ? |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarDamage**           |   **169.35 ns** |  **2.607 ns** |  **2.439 ns** |  **1.00** |    **0.00** | **0.1204** |      **-** |    **1008 B** |        **1.00** |
| ReadF1Sharp     | CarDamage           | 4,398.67 ns | 49.256 ns | 46.074 ns | 25.98 |    0.40 | 0.4120 |      - |    3472 B |        3.44 |
| ReadF1Simracing | CarDamage           |   761.82 ns |  9.206 ns |  8.612 ns |  4.50 |    0.06 | 0.4988 | 0.0067 |    4176 B |        4.14 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **SessionHistory**      |   **264.73 ns** |  **5.309 ns** | **10.602 ns** |  **1.00** |    **0.00** | **0.1845** | **0.0010** |    **1544 B** |        **1.00** |
| ReadF1Sharp     | SessionHistory      |   327.60 ns |  4.810 ns |  4.016 ns |  1.25 |    0.03 | 0.1903 | 0.0010 |    1592 B |        1.03 |
| ReadF1Simracing | SessionHistory      |   912.02 ns | 10.332 ns |  9.664 ns |  3.45 |    0.09 | 0.5484 | 0.0086 |    4592 B |        2.97 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **TyreSets**            |   **127.41 ns** |  **1.257 ns** |  **1.176 ns** |  **1.00** |    **0.00** | **0.0334** |      **-** |     **280 B** |        **1.00** |
| ReadF1Sharp     | TyreSets            |   187.13 ns |  1.624 ns |  1.519 ns |  1.47 |    0.02 | 0.0372 |      - |     312 B |        1.11 |
| ReadF1Simracing | TyreSets            |   251.97 ns |  2.959 ns |  2.310 ns |  1.98 |    0.03 | 0.1316 |      - |    1104 B |        3.94 |
|                 |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDP**   | **MotionEx**            |    **29.59 ns** |  **0.404 ns** |  **0.378 ns** |  **1.00** |    **0.00** | **0.0287** |      **-** |     **240 B** |        **1.00** |
| ReadF1Sharp     | MotionEx            |   609.60 ns |  7.163 ns |  6.700 ns | 20.60 |    0.33 | 0.0687 |      - |     576 B |        2.40 |
| ReadF1Simracing | MotionEx            |   191.94 ns |  1.831 ns |  1.713 ns |  6.49 |    0.10 | 0.0899 |      - |     752 B |        3.13 |

Benchmarks with issues:
  ThirdPartyComparisonBenchmark.ReadF1Simracing: NET8(Runtime=.NET 8.0) [Type=LobbyInfo] due to the bug in SimRacing.Telemetry.Receiver.F1.23
