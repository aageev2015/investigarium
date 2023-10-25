```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                Method |     Mean |   Error |  StdDev | Rank |   Gen0 | Allocated |
|---------------------- |---------:|--------:|--------:|-----:|-------:|----------:|
|    TestWhereDirectSum | 315.0 ns | 6.32 ns | 9.06 ns |    1 | 0.0215 |     136 B |
| TestWhereViaLambdaSum | 307.9 ns | 5.98 ns | 5.59 ns |    1 | 0.0215 |     136 B |
