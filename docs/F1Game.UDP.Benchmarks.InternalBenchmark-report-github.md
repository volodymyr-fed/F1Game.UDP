```

BenchmarkDotNet v0.16.0-preview.2, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 31.92 GB Total, 14.11 GB Available
.NET SDK 11.0.100
  [Host] : .NET 9.0.23 (9.0.23, 9.0.2326.52216), X64 RyuJIT x86-64-v3
  NET9   : .NET 9.0.23 (9.0.23, 9.0.2326.52216), X64 RyuJIT x86-64-v3
  NET10  : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  NET11  : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v3


```
| Method               | Job   | Runtime   | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |------ |---------- |-------------------- |------------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **Motion**              | **1,521.49 ns** |  **1.115 ns** |  **0.931 ns** | **21.42** |    **0.14** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Motion              |    71.03 ns |  0.575 ns |  0.480 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | Motion              | 1,355.08 ns | 11.066 ns | 10.351 ns | 18.24 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Motion              |    74.31 ns |  0.238 ns |  0.199 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | Motion              | 1,349.38 ns |  3.079 ns |  2.730 ns | 18.77 |    0.07 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | Motion              |    71.88 ns |  0.292 ns |  0.228 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **Session**             | **1,800.98 ns** | **10.367 ns** |  **8.094 ns** | **25.46** |    **0.15** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Session             |    70.74 ns |  0.315 ns |  0.294 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | Session             | 1,622.27 ns |  6.923 ns |  6.137 ns | 23.13 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Session             |    70.14 ns |  0.250 ns |  0.196 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | Session             | 1,628.05 ns |  7.517 ns |  6.663 ns | 23.93 |    0.17 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | Session             |    68.04 ns |  0.427 ns |  0.400 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **LapData**             | **1,963.40 ns** |  **5.507 ns** |  **4.598 ns** | **25.78** |    **0.33** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LapData             |    76.18 ns |  1.050 ns |  0.982 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | LapData             | 1,806.75 ns | 13.146 ns | 11.654 ns | 24.72 |    0.19 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LapData             |    73.08 ns |  0.383 ns |  0.340 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | LapData             | 1,797.03 ns |  9.899 ns |  8.775 ns | 24.37 |    0.19 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | LapData             |    73.74 ns |  0.493 ns |  0.461 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **Event**               |   **653.67 ns** |  **2.138 ns** |  **1.785 ns** |  **9.91** |    **0.05** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Event               |    65.93 ns |  0.334 ns |  0.312 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | Event               |   718.35 ns |  1.916 ns |  1.600 ns | 11.50 |    0.06 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Event               |    62.46 ns |  0.338 ns |  0.300 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | Event               |   701.93 ns |  2.071 ns |  1.836 ns | 11.07 |    0.04 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | Event               |    63.41 ns |  0.187 ns |  0.175 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **Participants**        | **2,152.63 ns** |  **9.236 ns** |  **8.187 ns** | **28.59** |    **0.20** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Participants        |    75.28 ns |  0.546 ns |  0.456 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | Participants        | 2,071.50 ns | 20.037 ns | 18.743 ns | 27.48 |    0.25 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Participants        |    75.39 ns |  0.256 ns |  0.214 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | Participants        | 2,041.72 ns |  5.667 ns |  4.732 ns | 26.16 |    0.24 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | Participants        |    78.04 ns |  0.775 ns |  0.725 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **CarSetups**           | **1,626.92 ns** |  **6.001 ns** |  **5.011 ns** | **21.92** |    **0.09** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarSetups           |    74.21 ns |  0.266 ns |  0.236 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | CarSetups           | 1,422.81 ns |  3.078 ns |  2.729 ns | 18.95 |    0.07 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarSetups           |    75.08 ns |  0.320 ns |  0.250 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | CarSetups           | 1,425.37 ns |  5.943 ns |  4.962 ns | 19.91 |    0.32 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | CarSetups           |    71.61 ns |  1.243 ns |  1.162 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **CarTelemetry**        | **1,911.36 ns** | **15.551 ns** | **13.785 ns** | **25.52** |    **0.21** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarTelemetry        |    74.88 ns |  0.416 ns |  0.325 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | CarTelemetry        | 1,929.90 ns |  7.786 ns |  7.283 ns | 25.65 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarTelemetry        |    75.25 ns |  0.417 ns |  0.390 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | CarTelemetry        | 1,942.01 ns |  6.654 ns |  6.224 ns | 24.37 |    0.23 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | CarTelemetry        |    79.69 ns |  0.969 ns |  0.757 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **CarStatus**           | **1,793.96 ns** |  **4.411 ns** |  **3.683 ns** | **24.26** |    **0.15** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarStatus           |    73.95 ns |  0.510 ns |  0.452 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | CarStatus           | 1,620.22 ns | 15.051 ns | 14.078 ns | 21.68 |    0.19 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarStatus           |    74.72 ns |  0.275 ns |  0.215 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | CarStatus           | 1,595.48 ns |  6.084 ns |  4.750 ns | 22.36 |    0.09 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | CarStatus           |    71.36 ns |  0.224 ns |  0.187 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **FinalClassification** | **2,050.14 ns** |  **4.542 ns** |  **3.793 ns** | **26.37** |    **0.19** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | FinalClassification |    77.75 ns |  0.589 ns |  0.551 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | FinalClassification | 1,919.74 ns |  5.157 ns |  4.026 ns | 27.63 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | FinalClassification |    69.49 ns |  0.446 ns |  0.395 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | FinalClassification | 1,972.23 ns | 11.203 ns |  9.931 ns | 28.08 |    0.27 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | FinalClassification |    70.24 ns |  0.641 ns |  0.600 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **LobbyInfo**           | **1,334.97 ns** |  **4.241 ns** |  **3.759 ns** | **18.81** |    **0.07** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LobbyInfo           |    70.98 ns |  0.182 ns |  0.170 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | LobbyInfo           | 1,417.58 ns |  4.778 ns |  4.236 ns | 20.56 |    0.07 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LobbyInfo           |    68.94 ns |  0.175 ns |  0.146 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | LobbyInfo           | 1,401.01 ns | 13.957 ns | 13.056 ns | 20.28 |    0.26 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | LobbyInfo           |    69.09 ns |  0.799 ns |  0.667 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **CarDamage**           | **1,886.04 ns** |  **2.890 ns** |  **2.562 ns** | **25.41** |    **0.11** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarDamage           |    74.23 ns |  0.351 ns |  0.311 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | CarDamage           | 1,638.00 ns |  9.363 ns |  8.758 ns | 22.18 |    0.19 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarDamage           |    73.85 ns |  0.645 ns |  0.538 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | CarDamage           | 1,632.58 ns | 10.645 ns |  9.436 ns | 23.69 |    0.23 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | CarDamage           |    68.92 ns |  0.641 ns |  0.568 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **SessionHistory**      | **1,838.91 ns** |  **5.594 ns** |  **4.367 ns** | **24.33** |    **0.32** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | SessionHistory      |    75.58 ns |  1.074 ns |  1.004 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | SessionHistory      | 1,704.54 ns | 10.321 ns |  8.619 ns | 23.68 |    0.13 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | SessionHistory      |    71.99 ns |  0.209 ns |  0.175 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | SessionHistory      | 1,747.35 ns | 13.136 ns | 11.645 ns | 24.32 |    0.17 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | SessionHistory      |    71.85 ns |  0.248 ns |  0.232 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **TyreSets**            |   **891.07 ns** |  **8.655 ns** |  **8.096 ns** | **12.91** |    **0.17** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | TyreSets            |    69.05 ns |  0.761 ns |  0.675 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | TyreSets            |   997.19 ns | 19.707 ns | 25.624 ns | 15.76 |    0.42 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | TyreSets            |    63.29 ns |  0.669 ns |  0.626 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | TyreSets            |   969.44 ns |  4.152 ns |  3.884 ns | 15.19 |    0.09 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | TyreSets            |    63.83 ns |  0.304 ns |  0.284 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **MotionEx**            |   **741.19 ns** |  **1.234 ns** |  **1.030 ns** | **11.14** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | MotionEx            |    66.51 ns |  0.288 ns |  0.256 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | MotionEx            |   519.04 ns |  1.022 ns |  0.906 ns |  7.88 |    0.02 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | MotionEx            |    65.83 ns |  0.145 ns |  0.135 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | MotionEx            |   513.14 ns |  1.242 ns |  1.101 ns |  8.18 |    0.02 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | MotionEx            |    62.76 ns |  0.142 ns |  0.111 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **TimeTrial**           |   **698.77 ns** |  **1.808 ns** |  **1.510 ns** | **10.98** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | TimeTrial           |    63.64 ns |  0.186 ns |  0.165 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | TimeTrial           |   464.47 ns |  0.489 ns |  0.382 ns |  7.51 |    0.02 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | TimeTrial           |    61.83 ns |  0.192 ns |  0.160 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | TimeTrial           |   472.24 ns |  2.698 ns |  2.392 ns |  7.49 |    0.04 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | TimeTrial           |    63.02 ns |  0.208 ns |  0.184 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **LapPositions**        | **1,037.27 ns** |  **3.507 ns** |  **2.738 ns** | **14.03** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LapPositions        |    73.92 ns |  0.164 ns |  0.137 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | LapPositions        |   893.64 ns |  2.821 ns |  2.356 ns | 12.06 |    0.04 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LapPositions        |    74.11 ns |  0.197 ns |  0.175 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | LapPositions        |   830.30 ns |  2.480 ns |  2.320 ns | 10.67 |    0.20 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | LapPositions        |    77.88 ns |  1.509 ns |  1.482 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET9**  | **.NET 9.0**  | **CarTelemetry2**       |   **955.89 ns** |  **4.303 ns** |  **3.815 ns** | **14.62** |    **0.11** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarTelemetry2       |    65.37 ns |  0.516 ns |  0.457 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET10 | .NET 10.0 | CarTelemetry2       |   918.40 ns | 12.323 ns | 10.290 ns | 14.10 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarTelemetry2       |    65.13 ns |  0.188 ns |  0.167 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET11 | .NET 11.0 | CarTelemetry2       |   895.63 ns |  2.039 ns |  1.907 ns | 13.81 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET11 | .NET 11.0 | CarTelemetry2       |    64.87 ns |  0.506 ns |  0.474 ns |  1.00 |    0.00 |         - |          NA |
