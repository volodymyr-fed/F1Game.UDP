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
| **ReadF1GameUDPReader**  | **Motion**              |   **928.01 ns** |  **9.628 ns** |  **8.535 ns** | **23.18** |    **0.22** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Motion              |    40.03 ns |  0.147 ns |  0.130 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **Session**             |   **957.33 ns** |  **6.799 ns** |  **6.027 ns** | **25.38** |    **0.16** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Session             |    37.73 ns |  0.162 ns |  0.151 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **LapData**             | **1,187.54 ns** | **14.867 ns** | **13.907 ns** | **30.35** |    **0.37** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | LapData             |    39.13 ns |  0.153 ns |  0.143 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **Event**               |   **334.29 ns** |  **3.206 ns** |  **2.842 ns** |  **9.53** |    **0.10** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Event               |    35.09 ns |  0.164 ns |  0.146 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **Participants**        |   **735.68 ns** |  **5.868 ns** |  **5.202 ns** | **15.49** |    **0.16** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | Participants        |    47.51 ns |  0.619 ns |  0.548 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarSetups**           |   **998.24 ns** |  **3.367 ns** |  **3.149 ns** | **23.35** |    **0.14** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarSetups           |    42.74 ns |  0.167 ns |  0.156 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarTelemetry**        | **1,197.52 ns** |  **6.969 ns** |  **6.519 ns** | **24.98** |    **0.19** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarTelemetry        |    47.95 ns |  0.263 ns |  0.219 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarStatus**           | **1,109.56 ns** |  **5.077 ns** |  **4.501 ns** | **25.83** |    **0.18** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarStatus           |    42.94 ns |  0.229 ns |  0.214 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **FinalClassification** |   **771.78 ns** |  **2.309 ns** |  **2.047 ns** | **18.29** |    **0.06** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | FinalClassification |    42.20 ns |  0.140 ns |  0.117 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **LobbyInfo**           |   **621.30 ns** |  **2.740 ns** |  **2.288 ns** | **14.19** |    **0.09** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | LobbyInfo           |    43.78 ns |  0.179 ns |  0.159 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **CarDamage**           | **1,183.69 ns** |  **7.874 ns** |  **6.980 ns** | **28.46** |    **0.18** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | CarDamage           |    41.59 ns |  0.141 ns |  0.125 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **SessionHistory**      | **1,316.22 ns** |  **6.925 ns** |  **6.139 ns** | **29.73** |    **0.21** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | SessionHistory      |    44.26 ns |  0.252 ns |  0.236 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **TyreSets**            |   **511.76 ns** |  **1.835 ns** |  **1.716 ns** | **14.87** |    **0.06** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | TyreSets            |    34.41 ns |  0.133 ns |  0.117 ns |  1.00 |    0.00 |         - |          NA |
|                      |                     |             |           |           |       |         |           |             |
| **ReadF1GameUDPReader**  | **MotionEx**            |   **369.68 ns** |  **1.446 ns** |  **1.281 ns** | **10.93** |    **0.07** |         **-** |          **NA** |
| ReadF1GameUDPMarshal | MotionEx            |    33.80 ns |  0.141 ns |  0.132 ns |  1.00 |    0.00 |         - |          NA |
