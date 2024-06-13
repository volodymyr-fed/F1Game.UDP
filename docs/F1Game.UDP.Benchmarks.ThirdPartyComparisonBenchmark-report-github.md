# Results for F1 23 packets

Didn't find any other library to parse F1 24 telemetry packets

```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300
  [Host] : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  NET8   : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=NET8  Runtime=.NET 8.0  

```
| Method          | Type                | Mean        | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------- |-------------------- |------------:|----------:|----------:|-------:|--------:|-------:|-------:|----------:|------------:|
| **ReadF1GameUDP**   | **Motion**              |    **45.72 ns** |  **0.411 ns** |  **0.384 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | Motion              |   251.82 ns |  4.446 ns |  3.941 ns |   5.50 |    0.11 | 0.1731 |      - |    1448 B |          NA |
| ReadF1Simracing | Motion              |   422.85 ns |  6.078 ns |  5.388 ns |   9.24 |    0.14 | 0.2675 | 0.0019 |    2240 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **Session**             |    **39.28 ns** |  **0.171 ns** |  **0.160 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | Session             |   327.42 ns |  3.144 ns |  2.941 ns |   8.34 |    0.09 | 0.0868 |      - |     728 B |          NA |
| ReadF1Simracing | Session             |   628.36 ns |  6.238 ns |  5.835 ns |  16.00 |    0.12 | 0.3414 | 0.0029 |    2856 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **LapData**             |    **43.11 ns** |  **0.196 ns** |  **0.183 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | LapData             |   239.81 ns |  4.513 ns |  4.221 ns |   5.56 |    0.10 | 0.1471 |      - |    1232 B |          NA |
| ReadF1Simracing | LapData             |   469.57 ns |  7.206 ns |  6.741 ns |  10.89 |    0.15 | 0.2465 | 0.0010 |    2064 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **Event**               |    **35.05 ns** |  **0.155 ns** |  **0.145 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | Event               |   173.42 ns |  1.098 ns |  0.973 ns |   4.95 |    0.03 | 0.0181 |      - |     152 B |          NA |
| ReadF1Simracing | Event               |   206.31 ns |  0.985 ns |  0.921 ns |   5.89 |    0.04 | 0.0458 |      - |     384 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **Participants**        |    **51.35 ns** |  **0.159 ns** |  **0.141 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | Participants        | 2,506.39 ns | 34.166 ns | 31.959 ns |  48.75 |    0.61 | 0.3929 | 0.0038 |    3296 B |          NA |
| ReadF1Simracing | Participants        | 1,183.16 ns | 15.204 ns | 14.222 ns |  23.05 |    0.29 | 0.4768 | 0.0057 |    4000 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarSetups**           |    **42.41 ns** |  **0.226 ns** |  **0.200 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | CarSetups           |   256.21 ns |  4.078 ns |  3.815 ns |   6.03 |    0.09 | 0.1364 |      - |    1144 B |          NA |
| ReadF1Simracing | CarSetups           |   423.44 ns |  6.341 ns |  5.621 ns |   9.98 |    0.12 | 0.2465 | 0.0010 |    2064 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarTelemetry**        |    **41.48 ns** |  **0.213 ns** |  **0.200 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | CarTelemetry        | 6,906.24 ns | 36.033 ns | 33.706 ns | 166.51 |    1.22 | 0.6180 | 0.0076 |    5232 B |          NA |
| ReadF1Simracing | CarTelemetry        | 1,096.45 ns | 12.541 ns | 11.731 ns |  26.44 |    0.30 | 0.7095 | 0.0134 |    5936 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarStatus**           |    **43.55 ns** |  **0.284 ns** |  **0.265 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | CarStatus           |   235.85 ns |  3.667 ns |  3.251 ns |   5.42 |    0.08 | 0.1607 |      - |    1344 B |          NA |
| ReadF1Simracing | CarStatus           |   451.42 ns |  3.662 ns |  3.426 ns |  10.37 |    0.10 | 0.2465 | 0.0010 |    2064 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **FinalClassification** |    **42.08 ns** |  **0.139 ns** |  **0.130 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | FinalClassification | 4,696.18 ns | 22.657 ns | 21.193 ns | 111.61 |    0.68 | 0.3891 |      - |    3296 B |          NA |
| ReadF1Simracing | FinalClassification |   884.97 ns |  8.386 ns |  7.434 ns |  21.03 |    0.18 | 0.4778 |      - |    4000 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **LobbyInfo**           |    **45.11 ns** |  **0.244 ns** |  **0.228 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | LobbyInfo           | 2,493.72 ns | 16.138 ns | 15.096 ns |  55.29 |    0.44 | 0.3700 | 0.0038 |    3120 B |          NA |
| ReadF1Simracing | LobbyInfo           |          NA |        NA |        NA |      ? |       ? |     NA |     NA |        NA |           ? |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **CarDamage**           |    **41.42 ns** |  **0.194 ns** |  **0.182 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | CarDamage           | 4,258.95 ns | 21.016 ns | 19.659 ns | 102.83 |    0.62 | 0.4120 |      - |    3472 B |          NA |
| ReadF1Simracing | CarDamage           |   759.31 ns | 12.546 ns | 11.736 ns |  18.33 |    0.30 | 0.4988 | 0.0067 |    4176 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **SessionHistory**      |    **50.24 ns** |  **0.199 ns** |  **0.177 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | SessionHistory      |   339.18 ns |  4.511 ns |  4.219 ns |   6.76 |    0.09 | 0.1903 | 0.0010 |    1592 B |          NA |
| ReadF1Simracing | SessionHistory      |   909.09 ns | 11.340 ns | 10.608 ns |  18.07 |    0.19 | 0.5484 | 0.0086 |    4592 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **TyreSets**            |    **35.39 ns** |  **0.242 ns** |  **0.215 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | TyreSets            |   190.44 ns |  1.280 ns |  1.198 ns |   5.38 |    0.03 | 0.0372 |      - |     312 B |          NA |
| ReadF1Simracing | TyreSets            |   251.29 ns |  3.067 ns |  2.869 ns |   7.10 |    0.10 | 0.1316 |      - |    1104 B |          NA |
|                 |                     |             |           |           |        |         |        |        |           |             |
| **ReadF1GameUDP**   | **MotionEx**            |    **35.53 ns** |  **0.168 ns** |  **0.157 ns** |   **1.00** |    **0.00** |      **-** |      **-** |         **-** |          **NA** |
| ReadF1Sharp     | MotionEx            |   614.17 ns |  2.718 ns |  2.542 ns |  17.29 |    0.07 | 0.0687 |      - |     576 B |          NA |
| ReadF1Simracing | MotionEx            |   190.14 ns |  1.636 ns |  1.530 ns |   5.35 |    0.05 | 0.0899 |      - |     752 B |          NA |

Benchmarks with issues:
  ThirdPartyComparisonBenchmark.ReadF1Simracing: NET8(Runtime=.NET 8.0) [Type=LobbyInfo] due to the bug in SimRacing.Telemetry.Receiver.F1.23
