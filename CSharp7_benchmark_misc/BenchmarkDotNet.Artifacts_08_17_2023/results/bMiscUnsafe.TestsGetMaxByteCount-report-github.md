```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|           Method |              Example |          Mean |      Error |     StdDev |        Median | Rank | Allocated |
|----------------- |--------------------- |--------------:|-----------:|-----------:|--------------:|-----:|----------:|
|          **tLength** |                     **** |     **0.0133 ns** |  **0.0114 ns** |  **0.0107 ns** |     **0.0130 ns** |    **1** |         **-** |
|    tGetByteCount |                      |     5.6837 ns |  0.1342 ns |  0.1255 ns |     5.6440 ns |    4 |         - |
| tGetMaxByteCount |                      |     1.9616 ns |  0.0273 ns |  0.0242 ns |     1.9560 ns |    3 |         - |
|          **tLength** |                    **A** |     **0.0066 ns** |  **0.0098 ns** |  **0.0087 ns** |     **0.0025 ns** |    **1** |         **-** |
|    tGetByteCount |                    A |     7.0448 ns |  0.0892 ns |  0.0745 ns |     7.0203 ns |    5 |         - |
| tGetMaxByteCount |                    A |     1.9711 ns |  0.0249 ns |  0.0208 ns |     1.9708 ns |    3 |         - |
|          **tLength** | **Orig(...)▅▆▇█ [7422]** |     **0.0022 ns** |  **0.0055 ns** |  **0.0049 ns** |     **0.0000 ns** |    **1** |         **-** |
|    tGetByteCount | Orig(...)▅▆▇█ [7422] | 1,208.0793 ns | 17.4515 ns | 15.4703 ns | 1,202.5057 ns |    7 |         - |
| tGetMaxByteCount | Orig(...)▅▆▇█ [7422] |     1.8912 ns |  0.0362 ns |  0.0321 ns |     1.8829 ns |    2 |         - |
|          **tLength** |    **Short Normal Text** |     **0.0036 ns** |  **0.0081 ns** |  **0.0072 ns** |     **0.0000 ns** |    **1** |         **-** |
|    tGetByteCount |    Short Normal Text |     8.5659 ns |  0.1995 ns |  0.3106 ns |     8.4236 ns |    6 |         - |
| tGetMaxByteCount |    Short Normal Text |     2.0115 ns |  0.0731 ns |  0.0750 ns |     1.9827 ns |    3 |         - |
