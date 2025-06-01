```

BenchmarkDotNet v0.15.0, Windows 10 (10.0.19045.5854/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz (Max: 3.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host] : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  NET8   : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  NET9   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2


```
| Method               | Job  | Runtime  | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |----- |--------- |-------------------- |------------:|----------:|----------:|------:|--------:|----------:|------------:|
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **Motion**              | **1,379.34 ns** | **13.908 ns** | **12.329 ns** | **26.98** |    **0.39** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | Motion              |    51.14 ns |  0.650 ns |  0.608 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | Motion              | 1,507.84 ns | 23.495 ns | 21.978 ns | 26.90 |    0.54 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | Motion              |    56.07 ns |  0.959 ns |  0.850 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **Session**             | **1,412.34 ns** |  **4.197 ns** |  **3.505 ns** | **31.18** |    **0.23** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | Session             |    45.29 ns |  0.371 ns |  0.329 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | Session             | 1,457.26 ns |  1.537 ns |  1.200 ns | 27.18 |    0.18 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | Session             |    53.62 ns |  0.436 ns |  0.364 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **LapData**             | **1,789.02 ns** | **14.558 ns** | **13.617 ns** | **33.93** |    **0.26** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | LapData             |    52.73 ns |  0.129 ns |  0.101 ns |  1.00 |    0.00 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | LapData             | 1,845.69 ns | 10.030 ns |  8.892 ns | 33.36 |    0.20 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | LapData             |    55.33 ns |  0.262 ns |  0.219 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **Event**               |   **510.36 ns** |  **7.678 ns** |  **6.806 ns** | **15.07** |    **0.22** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | Event               |    33.88 ns |  0.297 ns |  0.263 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | Event               |   587.53 ns |  6.119 ns |  5.724 ns | 12.18 |    0.12 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | Event               |    48.25 ns |  0.132 ns |  0.103 ns |  1.00 |    0.00 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **Participants**        | **1,740.57 ns** | **19.133 ns** | **16.961 ns** | **33.99** |    **0.33** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | Participants        |    51.21 ns |  0.152 ns |  0.134 ns |  1.00 |    0.00 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | Participants        | 1,818.04 ns |  9.042 ns |  7.550 ns | 32.15 |    0.26 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | Participants        |    56.56 ns |  0.476 ns |  0.422 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **CarSetups**           | **1,438.43 ns** | **15.438 ns** | **14.441 ns** | **26.04** |    **0.26** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | CarSetups           |    55.24 ns |  0.123 ns |  0.103 ns |  1.00 |    0.00 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | CarSetups           | 1,517.42 ns | 15.186 ns | 14.205 ns | 26.98 |    0.39 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | CarSetups           |    56.26 ns |  0.687 ns |  0.642 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **CarTelemetry**        | **1,704.61 ns** | **24.040 ns** | **22.487 ns** | **31.87** |    **0.70** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | CarTelemetry        |    53.50 ns |  1.078 ns |  1.008 ns |  1.00 |    0.03 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | CarTelemetry        | 1,836.84 ns | 29.413 ns | 27.513 ns | 33.02 |    0.56 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | CarTelemetry        |    55.63 ns |  0.547 ns |  0.511 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **CarStatus**           | **1,562.87 ns** | **18.036 ns** | **16.871 ns** | **34.54** |    **0.54** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | CarStatus           |    45.25 ns |  0.578 ns |  0.540 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | CarStatus           | 1,662.47 ns | 32.094 ns | 30.021 ns | 25.69 |    0.56 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | CarStatus           |    64.73 ns |  0.944 ns |  0.883 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **FinalClassification** | **1,498.61 ns** | **12.478 ns** | **11.061 ns** | **33.37** |    **0.36** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | FinalClassification |    44.92 ns |  0.410 ns |  0.384 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | FinalClassification | 1,507.41 ns | 16.666 ns | 14.774 ns | 25.50 |    0.39 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | FinalClassification |    59.13 ns |  0.803 ns |  0.751 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **LobbyInfo**           | **1,015.72 ns** | **10.376 ns** |  **9.705 ns** | **21.31** |    **0.22** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | LobbyInfo           |    47.68 ns |  0.243 ns |  0.216 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | LobbyInfo           | 1,118.90 ns |  5.137 ns |  4.010 ns | 20.91 |    0.15 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | LobbyInfo           |    53.51 ns |  0.383 ns |  0.339 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **CarDamage**           | **1,714.22 ns** | **22.088 ns** | **20.661 ns** | **40.51** |    **0.78** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | CarDamage           |    42.33 ns |  0.722 ns |  0.675 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | CarDamage           | 1,729.80 ns | 14.726 ns | 13.055 ns | 32.12 |    0.37 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | CarDamage           |    53.85 ns |  0.594 ns |  0.496 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **SessionHistory**      | **1,744.47 ns** | **25.720 ns** | **24.059 ns** | **31.71** |    **0.44** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | SessionHistory      |    55.01 ns |  0.284 ns |  0.237 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | SessionHistory      | 1,777.92 ns | 17.759 ns | 15.743 ns | 30.27 |    0.42 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | SessionHistory      |    58.75 ns |  0.707 ns |  0.661 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **TyreSets**            |   **786.66 ns** | **11.549 ns** | **10.803 ns** | **21.71** |    **0.35** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | TyreSets            |    36.24 ns |  0.412 ns |  0.344 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | TyreSets            |   872.31 ns | 10.385 ns |  9.714 ns | 17.00 |    0.29 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | TyreSets            |    51.31 ns |  0.757 ns |  0.708 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **MotionEx**            |   **596.43 ns** |  **6.372 ns** |  **5.649 ns** | **15.70** |    **0.27** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | MotionEx            |    37.99 ns |  0.622 ns |  0.582 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | MotionEx            |   681.68 ns |  9.990 ns |  9.345 ns | 12.95 |    0.23 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | MotionEx            |    52.64 ns |  0.726 ns |  0.643 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **TimeTrial**           |   **531.38 ns** |  **5.718 ns** |  **5.069 ns** | **14.97** |    **0.31** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | TimeTrial           |    35.51 ns |  0.734 ns |  0.686 ns |  1.00 |    0.03 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | TimeTrial           |   615.79 ns |  7.679 ns |  7.183 ns | 12.31 |    0.22 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | TimeTrial           |    50.02 ns |  0.822 ns |  0.729 ns |  1.00 |    0.02 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **NET8** | **.NET 8.0** | **LapPositions**        |   **939.72 ns** | **14.472 ns** | **13.537 ns** | **21.17** |    **0.34** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | NET8 | .NET 8.0 | LapPositions        |    44.39 ns |  0.430 ns |  0.381 ns |  1.00 |    0.01 |         - |          NA |
|                      |      |          |                     |             |           |           |       |         |           |             |
| ReadF1GameUDPReader  | NET9 | .NET 9.0 | LapPositions        | 1,033.24 ns | 10.692 ns | 10.002 ns | 18.31 |    0.25 |         - |          NA |
| ReadF1GameUDPMarshal | NET9 | .NET 9.0 | LapPositions        |    56.44 ns |  0.600 ns |  0.561 ns |  1.00 |    0.01 |         - |          NA |
