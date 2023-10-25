```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|    Method |      Mean |     Error |    StdDev | Median | Ratio | RatioSD |
|---------- |----------:|----------:|----------:|-------:|------:|--------:|
| Scenario1 | 0.0110 ns | 0.0208 ns | 0.0194 ns | 0.0 ns |     ? |       ? |
| Scenario2 | 0.0086 ns | 0.0156 ns | 0.0139 ns | 0.0 ns |     ? |       ? |
