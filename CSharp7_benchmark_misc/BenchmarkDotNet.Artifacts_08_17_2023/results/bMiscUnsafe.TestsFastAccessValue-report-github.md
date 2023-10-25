```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                 Method | Index |      Mean |     Error |    StdDev | Rank | Allocated |
|----------------------- |------ |----------:|----------:|----------:|-----:|----------:|
|     **tNormalAccessValue** |     **0** | **0.0295 ns** | **0.0244 ns** | **0.0290 ns** |    **1** |         **-** |
|       tFastAccessValue |     0 | 0.2943 ns | 0.0362 ns | 0.0338 ns |    3 |         - |
| tFastAccessValueUnsafe |     0 | 1.0432 ns | 0.0469 ns | 0.0366 ns |    4 |         - |
|     **tNormalAccessValue** |   **100** | **0.0420 ns** | **0.0315 ns** | **0.0350 ns** |    **1** |         **-** |
|       tFastAccessValue |   100 | 0.2648 ns | 0.0388 ns | 0.0476 ns |    2 |         - |
| tFastAccessValueUnsafe |   100 | 1.0756 ns | 0.0515 ns | 0.0551 ns |    4 |         - |
|     **tNormalAccessValue** |   **999** | **0.0542 ns** | **0.0331 ns** | **0.0325 ns** |    **1** |         **-** |
|       tFastAccessValue |   999 | 0.2602 ns | 0.0162 ns | 0.0144 ns |    2 |         - |
| tFastAccessValueUnsafe |   999 | 1.0220 ns | 0.0159 ns | 0.0124 ns |    4 |         - |
