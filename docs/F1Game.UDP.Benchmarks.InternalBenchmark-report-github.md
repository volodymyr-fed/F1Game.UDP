```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300-preview.24203.14
  [Host] : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  NET8   : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2

Job=NET8  Runtime=.NET 8.0  

```
| Method               | Type                | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------- |-------------------- |------------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ReadF1GameUDPReader**  | **Motion**              |   **585.06 ns** |  **7.177 ns** |  **6.362 ns** |  **3.26** |    **0.07** | **0.1669** |      **-** |    **1400 B** |        **1.00** |
| ReadF1GameUDPMarshal | Motion              |   179.37 ns |  2.738 ns |  2.561 ns |  1.00 |    0.00 | 0.1674 |      - |    1400 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **Session**             |   **678.08 ns** |  **5.578 ns** |  **4.658 ns** |  **2.54** |    **0.05** | **0.0877** |      **-** |     **736 B** |        **1.00** |
| ReadF1GameUDPMarshal | Session             |   265.57 ns |  5.259 ns |  5.846 ns |  1.00 |    0.00 | 0.0877 |      - |     736 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **LapData**             |   **901.73 ns** | **15.567 ns** | **13.800 ns** |  **5.04** |    **0.17** | **0.1411** |      **-** |    **1184 B** |        **1.00** |
| ReadF1GameUDPMarshal | LapData             |   179.78 ns |  3.347 ns |  3.721 ns |  1.00 |    0.00 | 0.1414 |      - |    1184 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **Participants**        |   **490.53 ns** |  **7.929 ns** |  **6.621 ns** |  **0.27** |    **0.00** | **0.2613** | **0.0019** |    **2192 B** |        **1.00** |
| ReadF1GameUDPMarshal | Participants        | 1,845.94 ns | 12.897 ns | 11.433 ns |  1.00 |    0.00 | 0.2613 | 0.0019 |    2192 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **CarSetups**           |   **663.14 ns** |  **4.585 ns** |  **4.289 ns** |  **3.71** |    **0.05** | **0.1383** |      **-** |    **1160 B** |        **1.00** |
| ReadF1GameUDPMarshal | CarSetups           |   178.71 ns |  2.508 ns |  2.346 ns |  1.00 |    0.00 | 0.1385 |      - |    1160 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **CarTelemetry**        |   **893.29 ns** |  **8.508 ns** |  **7.958 ns** |  **5.03** |    **0.06** | **0.1669** |      **-** |    **1400 B** |        **1.00** |
| ReadF1GameUDPMarshal | CarTelemetry        |   177.54 ns |  1.702 ns |  1.592 ns |  1.00 |    0.00 | 0.1674 |      - |    1400 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **CarStatus**           |   **779.16 ns** |  **5.981 ns** |  **5.302 ns** |  **4.37** |    **0.09** | **0.1545** |      **-** |    **1296 B** |        **1.00** |
| ReadF1GameUDPMarshal | CarStatus           |   178.15 ns |  3.611 ns |  3.378 ns |  1.00 |    0.00 | 0.1547 |      - |    1296 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **FinalClassification** |   **803.83 ns** | **14.872 ns** | **13.911 ns** |  **0.17** |    **0.00** | **0.3881** | **0.0038** |    **3248 B** |        **1.00** |
| ReadF1GameUDPMarshal | FinalClassification | 4,725.70 ns | 32.287 ns | 30.201 ns |  1.00 |    0.00 | 0.3815 |      - |    3248 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **LobbyInfo**           |   **356.22 ns** |  **5.386 ns** |  **5.038 ns** |  **0.20** |    **0.00** | **0.2408** | **0.0014** |    **2016 B** |        **1.00** |
| ReadF1GameUDPMarshal | LobbyInfo           | 1,784.09 ns | 13.864 ns | 11.577 ns |  1.00 |    0.00 | 0.2403 |      - |    2016 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **CarDamage**           |   **861.42 ns** |  **6.619 ns** |  **5.868 ns** |  **5.02** |    **0.15** | **0.1202** |      **-** |    **1008 B** |        **1.00** |
| ReadF1GameUDPMarshal | CarDamage           |   166.66 ns |  3.313 ns |  5.625 ns |  1.00 |    0.00 | 0.1204 |      - |    1008 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **SessionHistory**      | **1,075.48 ns** | **18.597 ns** | **16.486 ns** |  **4.01** |    **0.08** | **0.1831** |      **-** |    **1544 B** |        **1.00** |
| ReadF1GameUDPMarshal | SessionHistory      |   268.47 ns |  3.659 ns |  3.244 ns |  1.00 |    0.00 | 0.1845 | 0.0010 |    1544 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **TyreSets**            |   **222.58 ns** |  **0.862 ns** |  **0.806 ns** |  **1.66** |    **0.04** | **0.0334** |      **-** |     **280 B** |        **1.00** |
| ReadF1GameUDPMarshal | TyreSets            |   135.33 ns |  2.659 ns |  2.955 ns |  1.00 |    0.00 | 0.0334 |      - |     280 B |        1.00 |
|                      |                     |             |           |           |       |         |        |        |           |             |
| **ReadF1GameUDPReader**  | **MotionEx**            |    **83.74 ns** |  **1.710 ns** |  **3.375 ns** |  **2.72** |    **0.13** | **0.0286** |      **-** |     **240 B** |        **1.00** |
| ReadF1GameUDPMarshal | MotionEx            |    30.75 ns |  0.606 ns |  0.943 ns |  1.00 |    0.00 | 0.0287 |      - |     240 B |        1.00 |
