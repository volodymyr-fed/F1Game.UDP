```

BenchmarkDotNet v0.15.6, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.300
  [Host] : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  NET10  : .NET 10.0.8 (10.0.8, 10.0.826.23019), X64 RyuJIT x86-64-v3
  NET8   : .NET 8.0.27 (8.0.27, 8.0.2726.22922), X64 RyuJIT x86-64-v3
  NET9   : .NET 9.0.16 (9.0.16, 9.0.1626.22923), X64 RyuJIT x86-64-v3


```
| Method               | Job   | Runtime   | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |------ |---------- |-------------------- |------------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Motion**              | **1,371.15 ns** |  **6.838 ns** |  **6.396 ns** | **23.82** |    **0.18** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Motion              |    57.57 ns |  0.382 ns |  0.357 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Motion              | 1,413.23 ns |  6.092 ns |  5.698 ns | 25.60 |    0.12 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Motion              |    55.21 ns |  0.139 ns |  0.130 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Motion              | 1,537.32 ns |  5.452 ns |  4.833 ns | 25.55 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Motion              |    60.18 ns |  0.181 ns |  0.160 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Session**             | **1,595.53 ns** |  **8.241 ns** |  **7.708 ns** | **28.65** |    **0.16** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Session             |    55.69 ns |  0.217 ns |  0.181 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Session             | 1,739.08 ns |  5.592 ns |  5.231 ns | 29.87 |    0.18 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Session             |    58.22 ns |  0.345 ns |  0.322 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Session             | 1,790.73 ns |  7.752 ns |  6.872 ns | 31.59 |    0.15 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Session             |    56.69 ns |  0.186 ns |  0.165 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **LapData**             | **1,783.23 ns** |  **5.096 ns** |  **4.517 ns** | **30.44** |    **0.13** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LapData             |    58.59 ns |  0.221 ns |  0.207 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | LapData             | 1,898.45 ns |  6.881 ns |  6.100 ns | 36.30 |    0.20 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | LapData             |    52.29 ns |  0.258 ns |  0.241 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | LapData             | 1,971.49 ns |  8.134 ns |  7.210 ns | 29.86 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LapData             |    66.02 ns |  0.223 ns |  0.198 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Event**               |   **683.07 ns** |  **3.124 ns** |  **2.922 ns** | **13.17** |    **0.07** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Event               |    51.87 ns |  0.171 ns |  0.160 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Event               |   547.59 ns |  1.365 ns |  1.210 ns | 11.98 |    0.05 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Event               |    45.71 ns |  0.193 ns |  0.171 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Event               |   658.48 ns |  3.766 ns |  3.338 ns | 12.49 |    0.08 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Event               |    52.73 ns |  0.212 ns |  0.198 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Participants**        | **2,056.13 ns** |  **4.605 ns** |  **3.846 ns** | **34.12** |    **0.13** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Participants        |    60.26 ns |  0.221 ns |  0.206 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Participants        | 2,078.70 ns | 10.433 ns |  9.249 ns | 31.27 |    0.35 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Participants        |    66.48 ns |  0.769 ns |  0.719 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Participants        | 2,188.71 ns | 29.836 ns | 26.448 ns | 35.01 |    0.46 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Participants        |    62.52 ns |  0.408 ns |  0.381 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarSetups**           | **1,480.79 ns** | **14.540 ns** | **13.601 ns** | **25.55** |    **0.24** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarSetups           |    57.95 ns |  0.204 ns |  0.191 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarSetups           | 1,571.83 ns |  5.906 ns |  5.235 ns | 26.36 |    0.12 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarSetups           |    59.62 ns |  0.218 ns |  0.193 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarSetups           | 1,609.76 ns |  5.386 ns |  5.038 ns | 27.62 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarSetups           |    58.29 ns |  0.318 ns |  0.297 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarTelemetry**        | **1,959.08 ns** | **12.134 ns** | **10.132 ns** | **33.73** |    **0.18** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarTelemetry        |    58.08 ns |  0.149 ns |  0.124 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarTelemetry        | 1,793.16 ns |  4.415 ns |  3.687 ns | 28.01 |    0.08 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarTelemetry        |    64.01 ns |  0.152 ns |  0.142 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarTelemetry        | 1,927.58 ns | 12.481 ns | 11.675 ns | 31.36 |    0.62 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarTelemetry        |    61.48 ns |  1.236 ns |  1.214 ns |  1.00 |    0.03 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarStatus**           | **1,620.74 ns** |  **7.821 ns** |  **7.316 ns** | **25.66** |    **0.44** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarStatus           |    63.19 ns |  1.163 ns |  1.088 ns |  1.00 |    0.02 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarStatus           | 1,771.14 ns |  7.406 ns |  6.566 ns | 32.30 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarStatus           |    54.83 ns |  0.172 ns |  0.143 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarStatus           | 1,824.17 ns |  7.754 ns |  7.253 ns | 30.01 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarStatus           |    60.78 ns |  0.219 ns |  0.183 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **FinalClassification** | **1,925.82 ns** | **12.782 ns** | **11.331 ns** | **32.98** |    **0.33** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | FinalClassification |    58.40 ns |  0.529 ns |  0.495 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | FinalClassification | 2,029.23 ns | 11.329 ns |  8.845 ns | 37.49 |    0.21 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | FinalClassification |    54.13 ns |  0.255 ns |  0.213 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | FinalClassification | 2,086.21 ns |  6.483 ns |  5.747 ns | 34.43 |    0.13 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | FinalClassification |    60.59 ns |  0.168 ns |  0.157 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **LobbyInfo**           | **1,595.57 ns** | **15.028 ns** | **13.322 ns** | **27.97** |    **0.24** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LobbyInfo           |    57.04 ns |  0.160 ns |  0.142 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | LobbyInfo           | 1,268.40 ns |  5.986 ns |  5.600 ns | 25.74 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | LobbyInfo           |    49.28 ns |  0.203 ns |  0.180 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | LobbyInfo           | 1,369.66 ns |  6.684 ns |  5.582 ns | 23.53 |    0.27 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LobbyInfo           |    58.22 ns |  0.729 ns |  0.646 ns |  1.00 |    0.02 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarDamage**           | **1,625.51 ns** |  **2.947 ns** |  **2.301 ns** | **27.94** |    **0.14** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarDamage           |    58.17 ns |  0.360 ns |  0.300 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarDamage           | 1,874.43 ns | 11.208 ns | 10.484 ns | 37.21 |    0.29 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarDamage           |    50.38 ns |  0.323 ns |  0.286 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarDamage           | 1,901.15 ns |  1.198 ns |  1.062 ns | 29.30 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarDamage           |    64.90 ns |  0.281 ns |  0.234 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **SessionHistory**      | **1,703.69 ns** |  **1.631 ns** |  **1.362 ns** | **28.43** |    **0.08** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | SessionHistory      |    59.93 ns |  0.218 ns |  0.170 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | SessionHistory      | 1,716.83 ns |  6.051 ns |  5.364 ns | 31.19 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | SessionHistory      |    55.04 ns |  0.077 ns |  0.060 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | SessionHistory      | 1,848.68 ns |  2.145 ns |  1.675 ns | 30.62 |    0.04 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | SessionHistory      |    60.38 ns |  0.077 ns |  0.064 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **TyreSets**            |   **950.11 ns** |  **1.364 ns** |  **1.275 ns** | **17.69** |    **0.05** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | TyreSets            |    53.72 ns |  0.152 ns |  0.127 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | TyreSets            |   798.82 ns |  1.458 ns |  1.218 ns | 17.09 |    0.12 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | TyreSets            |    46.75 ns |  0.382 ns |  0.339 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | TyreSets            |   920.72 ns |  2.115 ns |  1.978 ns | 17.08 |    0.07 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | TyreSets            |    53.90 ns |  0.207 ns |  0.184 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **MotionEx**            |   **533.37 ns** |  **1.924 ns** |  **1.706 ns** |  **9.63** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | MotionEx            |    55.39 ns |  0.156 ns |  0.131 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | MotionEx            |   657.68 ns | 10.379 ns |  9.201 ns | 14.09 |    0.20 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | MotionEx            |    46.69 ns |  0.172 ns |  0.153 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | MotionEx            |   743.97 ns |  4.390 ns |  4.107 ns | 13.95 |    0.08 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | MotionEx            |    53.32 ns |  0.175 ns |  0.146 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **TimeTrial**           |   **450.22 ns** |  **1.537 ns** |  **1.438 ns** |  **8.59** |    **0.04** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | TimeTrial           |    52.39 ns |  0.233 ns |  0.206 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | TimeTrial           |   615.20 ns |  2.944 ns |  2.458 ns | 13.49 |    0.07 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | TimeTrial           |    45.59 ns |  0.205 ns |  0.182 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | TimeTrial           |   672.56 ns |  2.636 ns |  2.465 ns | 12.76 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | TimeTrial           |    52.72 ns |  0.432 ns |  0.361 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **LapPositions**        |   **847.23 ns** |  **6.009 ns** |  **4.691 ns** | **14.25** |    **0.26** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LapPositions        |    59.46 ns |  1.212 ns |  1.074 ns |  1.00 |    0.02 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | LapPositions        |   978.59 ns |  1.370 ns |  1.214 ns | 17.52 |    0.12 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | LapPositions        |    55.87 ns |  0.448 ns |  0.397 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | LapPositions        | 1,070.57 ns |  2.482 ns |  2.201 ns | 14.64 |    0.05 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LapPositions        |    73.11 ns |  0.248 ns |  0.207 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarTelemetry2**       |   **956.96 ns** |  **3.929 ns** |  **3.483 ns** | **18.06** |    **0.12** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarTelemetry2       |    53.00 ns |  0.367 ns |  0.325 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarTelemetry2       |   822.76 ns |  3.457 ns |  3.234 ns | 17.38 |    0.11 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarTelemetry2       |    47.34 ns |  0.261 ns |  0.232 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarTelemetry2       | 1,020.22 ns | 17.419 ns | 16.294 ns | 18.53 |    0.36 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarTelemetry2       |    55.06 ns |  0.738 ns |  0.690 ns |  1.00 |    0.02 |         - |          NA |
