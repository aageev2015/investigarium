```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|          Method |   Qty |          Mean |         Error |        StdDev | Rank |    Gen0 | Allocated |
|---------------- |------ |--------------:|--------------:|--------------:|-----:|--------:|----------:|
|         **tBoxing** |    **10** |     **70.533 ns** |     **1.4274 ns** |     **2.0922 ns** |    **2** |  **0.0381** |     **240 B** |
| tBoxingUnboxing |    10 |     89.822 ns |     1.8191 ns |     2.2340 ns |    3 |  0.0381 |     240 B |
|        tNothing |    10 |      3.186 ns |     0.1014 ns |     0.1207 ns |    1 |       - |         - |
|         **tBoxing** | **10000** | **68,995.884 ns** | **1,330.3711 ns** | **2,626.0227 ns** |    **5** | **38.2080** |  **240000 B** |
| tBoxingUnboxing | 10000 | 77,783.068 ns | 1,545.2885 ns | 2,062.9158 ns |    6 | 38.2080 |  240000 B |
|        tNothing | 10000 |  2,609.831 ns |    51.1669 ns |    54.7480 ns |    4 |       - |         - |
