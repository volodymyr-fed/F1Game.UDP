```

BenchmarkDotNet v0.15.6, Windows 10 (10.0.19045.6466/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host] : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  NET10  : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  NET8   : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  NET9   : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v3


```
| Method               | Job   | Runtime   | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |------ |---------- |-------------------- |------------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Motion**              | **1,292.13 ns** |  **7.100 ns** |  **6.641 ns** | **22.71** |    **0.16** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Motion              |    56.91 ns |  0.329 ns |  0.308 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Motion              | 1,349.09 ns |  9.636 ns |  9.013 ns | 24.21 |    0.18 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Motion              |    55.73 ns |  0.215 ns |  0.201 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Motion              | 1,436.44 ns |  6.658 ns |  5.902 ns | 23.08 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Motion              |    62.23 ns |  0.385 ns |  0.361 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Session**             | **1,196.62 ns** |  **5.626 ns** |  **5.262 ns** | **20.72** |    **0.10** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Session             |    57.76 ns |  0.172 ns |  0.161 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Session             | 1,384.75 ns |  3.788 ns |  3.163 ns | 26.95 |    0.09 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Session             |    51.37 ns |  0.151 ns |  0.141 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Session             | 1,406.30 ns |  5.356 ns |  5.010 ns | 24.81 |    0.11 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Session             |    56.69 ns |  0.183 ns |  0.171 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **LapData**             | **1,634.18 ns** |  **7.418 ns** |  **6.939 ns** | **29.18** |    **0.18** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LapData             |    56.01 ns |  0.287 ns |  0.255 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | LapData             | 1,768.75 ns |  6.599 ns |  6.173 ns | 29.87 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | LapData             |    59.22 ns |  0.234 ns |  0.207 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | LapData             | 1,831.75 ns |  6.171 ns |  5.772 ns | 31.42 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LapData             |    58.30 ns |  0.096 ns |  0.075 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Event**               |   **607.62 ns** |  **5.280 ns** |  **4.939 ns** | **11.82** |    **0.10** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Event               |    51.40 ns |  0.185 ns |  0.173 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Event               |   501.87 ns |  4.429 ns |  3.926 ns | 11.13 |    0.09 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Event               |    45.08 ns |  0.160 ns |  0.150 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Event               |   586.35 ns |  2.535 ns |  2.371 ns | 11.28 |    0.06 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Event               |    52.00 ns |  0.201 ns |  0.188 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **Participants**        | **1,929.61 ns** |  **8.916 ns** |  **8.340 ns** | **33.55** |    **0.18** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | Participants        |    57.51 ns |  0.211 ns |  0.198 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | Participants        | 1,704.80 ns | 24.251 ns | 22.685 ns | 30.66 |    0.41 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | Participants        |    55.61 ns |  0.243 ns |  0.228 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | Participants        | 1,747.88 ns |  4.867 ns |  3.799 ns | 29.53 |    0.15 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | Participants        |    59.19 ns |  0.304 ns |  0.284 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarSetups**           | **1,298.25 ns** |  **4.388 ns** |  **4.104 ns** | **23.32** |    **0.14** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarSetups           |    55.67 ns |  0.323 ns |  0.287 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarSetups           | 1,409.40 ns |  7.281 ns |  6.811 ns | 26.07 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarSetups           |    54.06 ns |  0.234 ns |  0.219 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarSetups           | 1,474.63 ns |  8.507 ns |  7.957 ns | 25.42 |    0.18 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarSetups           |    58.02 ns |  0.318 ns |  0.297 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarTelemetry**        | **1,524.17 ns** |  **5.345 ns** |  **4.999 ns** | **24.49** |    **0.15** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarTelemetry        |    62.23 ns |  0.353 ns |  0.330 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarTelemetry        | 1,681.07 ns |  6.123 ns |  5.727 ns | 29.99 |    0.14 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarTelemetry        |    56.06 ns |  0.205 ns |  0.192 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarTelemetry        | 1,726.59 ns |  5.729 ns |  5.079 ns | 29.28 |    0.15 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarTelemetry        |    58.96 ns |  0.285 ns |  0.266 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarStatus**           | **1,390.98 ns** |  **9.767 ns** |  **8.658 ns** | **24.52** |    **0.16** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarStatus           |    56.72 ns |  0.181 ns |  0.169 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarStatus           | 1,514.45 ns |  6.765 ns |  6.328 ns | 25.51 |    0.20 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarStatus           |    59.37 ns |  0.434 ns |  0.406 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarStatus           | 1,600.97 ns |  5.804 ns |  5.429 ns | 27.21 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarStatus           |    58.85 ns |  0.323 ns |  0.302 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **FinalClassification** | **1,204.83 ns** |  **6.371 ns** |  **5.648 ns** | **21.43** |    **0.12** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | FinalClassification |    56.23 ns |  0.230 ns |  0.204 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | FinalClassification | 1,452.59 ns |  5.003 ns |  4.680 ns | 27.39 |    0.13 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | FinalClassification |    53.02 ns |  0.216 ns |  0.202 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | FinalClassification | 1,664.42 ns |  5.422 ns |  5.071 ns | 28.24 |    0.15 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | FinalClassification |    58.95 ns |  0.295 ns |  0.276 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **LobbyInfo**           | **1,106.90 ns** |  **4.888 ns** |  **4.572 ns** | **19.35** |    **0.25** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LobbyInfo           |    57.20 ns |  0.775 ns |  0.725 ns |  1.00 |    0.02 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | LobbyInfo           |   997.38 ns |  5.590 ns |  5.229 ns | 17.26 |    0.12 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | LobbyInfo           |    57.78 ns |  0.308 ns |  0.273 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | LobbyInfo           | 1,063.81 ns |  4.320 ns |  4.041 ns | 18.59 |    0.08 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LobbyInfo           |    57.23 ns |  0.157 ns |  0.139 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **CarDamage**           | **1,457.84 ns** |  **5.691 ns** |  **5.323 ns** | **25.39** |    **0.20** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | CarDamage           |    57.42 ns |  0.450 ns |  0.421 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | CarDamage           | 1,702.12 ns |  7.428 ns |  6.948 ns | 28.62 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | CarDamage           |    59.47 ns |  0.278 ns |  0.232 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | CarDamage           | 1,692.72 ns |  7.501 ns |  6.649 ns | 29.12 |    0.16 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | CarDamage           |    58.14 ns |  0.261 ns |  0.232 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **SessionHistory**      | **1,554.23 ns** |  **7.113 ns** |  **6.653 ns** | **26.60** |    **0.17** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | SessionHistory      |    58.43 ns |  0.315 ns |  0.295 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | SessionHistory      | 1,701.76 ns |  5.421 ns |  5.071 ns | 28.64 |    0.19 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | SessionHistory      |    59.42 ns |  0.403 ns |  0.377 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | SessionHistory      | 1,732.01 ns |  5.861 ns |  5.482 ns | 29.21 |    0.15 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | SessionHistory      |    59.30 ns |  0.271 ns |  0.253 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **TyreSets**            |   **804.42 ns** |  **2.701 ns** |  **2.526 ns** | **15.65** |    **0.08** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | TyreSets            |    51.40 ns |  0.238 ns |  0.223 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | TyreSets            |   727.21 ns |  2.383 ns |  2.112 ns | 15.45 |    0.09 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | TyreSets            |    47.07 ns |  0.265 ns |  0.248 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | TyreSets            |   828.19 ns |  4.167 ns |  3.898 ns | 15.99 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | TyreSets            |    51.79 ns |  0.224 ns |  0.210 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **MotionEx**            |   **461.25 ns** |  **1.503 ns** |  **1.406 ns** |  **8.60** |    **0.03** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | MotionEx            |    53.66 ns |  0.165 ns |  0.154 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | MotionEx            |   609.04 ns |  2.167 ns |  2.027 ns | 12.85 |    0.06 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | MotionEx            |    47.41 ns |  0.191 ns |  0.179 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | MotionEx            |   663.51 ns |  2.656 ns |  2.355 ns | 12.63 |    0.06 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | MotionEx            |    52.55 ns |  0.187 ns |  0.175 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **TimeTrial**           |   **406.55 ns** |  **1.087 ns** |  **0.964 ns** |  **7.97** |    **0.05** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | TimeTrial           |    51.00 ns |  0.336 ns |  0.298 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | TimeTrial           |   535.93 ns |  1.704 ns |  1.423 ns | 11.60 |    0.05 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | TimeTrial           |    46.18 ns |  0.173 ns |  0.161 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | TimeTrial           |   606.61 ns |  3.038 ns |  2.842 ns | 11.81 |    0.07 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | TimeTrial           |    51.39 ns |  0.197 ns |  0.184 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET10** | **.NET 10.0** | **LapPositions**        |   **802.84 ns** |  **2.467 ns** |  **2.308 ns** | **14.59** |    **0.07** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET10 | .NET 10.0 | LapPositions        |    55.02 ns |  0.222 ns |  0.208 ns |  1.00 |    0.01 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET8  | .NET 8.0  | LapPositions        |   940.90 ns |  3.393 ns |  3.173 ns | 16.27 |    0.08 |         - |          NA |
| ReadF1GameUDPMarshal | NET8  | .NET 8.0  | LapPositions        |    57.82 ns |  0.209 ns |  0.195 ns |  1.00 |    0.00 |         - |          NA |
|                      |       |           |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9  | .NET 9.0  | LapPositions        |   961.00 ns |  4.799 ns |  4.489 ns | 16.98 |    0.10 |         - |          NA |
| ReadF1GameUDPMarshal | NET9  | .NET 9.0  | LapPositions        |    56.59 ns |  0.233 ns |  0.218 ns |  1.00 |    0.01 |         - |          NA |
