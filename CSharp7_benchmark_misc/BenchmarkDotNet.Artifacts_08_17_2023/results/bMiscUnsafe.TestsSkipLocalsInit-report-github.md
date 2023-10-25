```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|          Method | Size |       Mean |     Error |    StdDev | Rank | Allocated |
|---------------- |----- |-----------:|----------:|----------:|-----:|----------:|
|   **tMethodNoInit** |    **0** |   **2.091 ns** | **0.0352 ns** | **0.0312 ns** |    **1** |         **-** |
| tMethodWithInit |    0 |   2.053 ns | 0.0283 ns | 0.0251 ns |    1 |         - |
|   **tMethodNoInit** |   **10** |   **8.523 ns** | **0.1787 ns** | **0.1672 ns** |    **2** |         **-** |
| tMethodWithInit |   10 |   9.077 ns | 0.1445 ns | 0.1352 ns |    3 |         - |
|   **tMethodNoInit** |   **64** |  **38.207 ns** | **0.3310 ns** | **0.2935 ns** |    **4** |         **-** |
| tMethodWithInit |   64 |  42.665 ns | 0.5055 ns | 0.4729 ns |    5 |         - |
|   **tMethodNoInit** |  **255** | **169.042 ns** | **0.8071 ns** | **0.7155 ns** |    **6** |         **-** |
| tMethodWithInit |  255 | 193.427 ns | 1.3279 ns | 1.1089 ns |    7 |         - |
