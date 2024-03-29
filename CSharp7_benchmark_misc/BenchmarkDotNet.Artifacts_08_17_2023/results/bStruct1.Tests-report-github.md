```

BenchmarkDotNet v0.13.7, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                   Method | Length |          Mean |         Error |         StdDev |        Median | Rank |     Gen0 |     Gen1 |     Gen2 | Allocated |
|------------------------- |------- |--------------:|--------------:|---------------:|--------------:|-----:|---------:|---------:|---------:|----------:|
|               **class_case** |     **10** |      **61.22 ns** |      **1.169 ns** |       **1.093 ns** |      **61.15 ns** |    **6** |   **0.0548** |        **-** |        **-** |     **344 B** |
|  class_case_CachedLength |     10 |      64.36 ns |      1.325 ns |       2.178 ns |      63.53 ns |    7 |   0.0548 |        - |        - |     344 B |
|    class_WithString_case |     10 |      78.56 ns |      1.604 ns |       2.851 ns |      77.98 ns |    8 |   0.0675 |        - |        - |     424 B |
|        class_Huge20_case |     10 |      86.14 ns |      1.652 ns |       1.545 ns |      85.40 ns |    9 |   0.0802 |   0.0001 |        - |     504 B |
|        class_Huge36_case |     10 |      95.70 ns |      1.853 ns |       2.993 ns |      95.33 ns |   10 |   0.1057 |   0.0001 |        - |     664 B |
|        class_Huge52_case |     10 |     107.81 ns |      2.161 ns |       4.606 ns |     106.88 ns |   12 |   0.1312 |   0.0002 |        - |     824 B |
|       class_Huge116_case |     10 |     146.06 ns |      2.455 ns |       2.177 ns |     145.54 ns |   13 |   0.2332 |   0.0010 |        - |    1464 B |
|              struct_case |     10 |      26.46 ns |      0.268 ns |       0.238 ns |      26.44 ns |    2 |   0.0293 |        - |        - |     184 B |
|   struct_case_Stackalloc |     10 |      22.51 ns |      0.227 ns |       0.212 ns |      22.43 ns |    1 |        - |        - |        - |         - |
| struct_case_CachedLength |     10 |      31.29 ns |      0.593 ns |       0.526 ns |      31.26 ns |    3 |   0.0293 |        - |        - |     184 B |
|   struct_WithString_case |     10 |      41.78 ns |      0.850 ns |       1.012 ns |      41.58 ns |    4 |   0.0293 |        - |        - |     184 B |
|       struct_Huge20_case |     10 |      44.24 ns |      0.899 ns |       0.883 ns |      44.20 ns |    5 |   0.0357 |        - |        - |     224 B |
|       struct_Huge36_case |     10 |      98.66 ns |      1.275 ns |       1.193 ns |      98.04 ns |   11 |   0.0612 |        - |        - |     384 B |
|       struct_Huge52_case |     10 |     105.95 ns |      0.757 ns |       0.671 ns |     105.99 ns |   12 |   0.0867 |        - |        - |     544 B |
|      struct_Huge116_case |     10 |     166.47 ns |      1.525 ns |       1.351 ns |     166.68 ns |   14 |   0.1886 |        - |        - |    1184 B |
|               **class_case** |    **100** |     **577.53 ns** |      **7.930 ns** |       **7.029 ns** |     **577.36 ns** |   **20** |   **0.5131** |   **0.0038** |        **-** |    **3224 B** |
|  class_case_CachedLength |    100 |     598.64 ns |     11.559 ns |      13.760 ns |     593.62 ns |   21 |   0.5131 |   0.0038 |        - |    3224 B |
|    class_WithString_case |    100 |     752.68 ns |     11.061 ns |       9.236 ns |     750.01 ns |   22 |   0.6409 |   0.0095 |        - |    4024 B |
|        class_Huge20_case |    100 |     821.37 ns |      6.519 ns |       5.444 ns |     821.56 ns |   23 |   0.7687 |   0.0134 |        - |    4824 B |
|        class_Huge36_case |    100 |     920.56 ns |     17.541 ns |      17.227 ns |     917.46 ns |   24 |   1.0233 |   0.0238 |        - |    6424 B |
|        class_Huge52_case |    100 |   1,027.89 ns |     19.860 ns |      17.606 ns |   1,027.65 ns |   26 |   1.2779 |   0.0362 |        - |    8024 B |
|       class_Huge116_case |    100 |   1,459.97 ns |     27.784 ns |      25.989 ns |   1,455.40 ns |   28 |   2.2984 |   0.1144 |        - |   14424 B |
|              struct_case |    100 |     259.78 ns |      4.888 ns |       4.082 ns |     258.64 ns |   16 |   0.2584 |        - |        - |    1624 B |
|   struct_case_Stackalloc |    100 |     224.74 ns |      1.036 ns |       0.865 ns |     224.58 ns |   15 |        - |        - |        - |         - |
| struct_case_CachedLength |    100 |     295.38 ns |      4.586 ns |       3.829 ns |     295.51 ns |   17 |   0.2584 |        - |        - |    1624 B |
|   struct_WithString_case |    100 |     403.94 ns |      5.246 ns |       4.907 ns |     403.06 ns |   18 |   0.2584 |        - |        - |    1624 B |
|       struct_Huge20_case |    100 |     489.12 ns |      9.716 ns |      10.799 ns |     485.93 ns |   19 |   0.3223 |        - |        - |    2024 B |
|       struct_Huge36_case |    100 |     972.04 ns |      7.897 ns |       7.000 ns |     969.80 ns |   25 |   0.5779 |        - |        - |    3624 B |
|       struct_Huge52_case |    100 |   1,111.99 ns |     10.216 ns |       9.556 ns |   1,110.38 ns |   27 |   0.8316 |        - |        - |    5224 B |
|      struct_Huge116_case |    100 |   1,700.41 ns |     14.119 ns |      11.023 ns |   1,699.72 ns |   29 |   1.8482 |        - |        - |   11624 B |
|               **class_case** |   **1000** |   **5,834.42 ns** |     **51.759 ns** |      **43.221 ns** |   **5,821.19 ns** |   **35** |   **5.0964** |   **0.5035** |        **-** |   **32024 B** |
|  class_case_CachedLength |   1000 |   5,952.24 ns |     97.545 ns |      91.244 ns |   5,926.49 ns |   36 |   5.0964 |   0.5035 |        - |   32024 B |
|    class_WithString_case |   1000 |   8,034.31 ns |    113.582 ns |     100.687 ns |   8,014.88 ns |   37 |   6.3782 |   0.7019 |        - |   40024 B |
|        class_Huge20_case |   1000 |   8,775.41 ns |    129.993 ns |     115.236 ns |   8,767.54 ns |   38 |   7.6447 |   1.0223 |        - |   48024 B |
|        class_Huge36_case |   1000 |  10,336.27 ns |    166.477 ns |     139.016 ns |  10,325.03 ns |   39 |  10.1929 |   1.6937 |        - |   64024 B |
|        class_Huge52_case |   1000 |  13,668.89 ns |    452.504 ns |   1,327.117 ns |  13,497.46 ns |   40 |  12.7411 |   2.5482 |        - |   80024 B |
|       class_Huge116_case |   1000 |  17,535.80 ns |    321.148 ns |     268.173 ns |  17,486.82 ns |   41 |  22.9492 |   6.0425 |        - |  144024 B |
|              struct_case |   1000 |   2,591.80 ns |     51.651 ns |      55.266 ns |   2,584.56 ns |   31 |   2.5444 |        - |        - |   16024 B |
|   struct_case_Stackalloc |   1000 |   2,148.50 ns |     27.683 ns |      23.116 ns |   2,142.10 ns |   30 |        - |        - |        - |         - |
| struct_case_CachedLength |   1000 |   2,833.84 ns |     55.741 ns |      91.584 ns |   2,811.73 ns |   32 |   2.5444 |        - |        - |   16024 B |
|   struct_WithString_case |   1000 |   4,261.27 ns |     50.151 ns |      46.911 ns |   4,244.37 ns |   33 |   2.5406 |        - |        - |   16024 B |
|       struct_Huge20_case |   1000 |   4,364.60 ns |     83.545 ns |      89.393 ns |   4,365.82 ns |   34 |   3.1815 |        - |        - |   20024 B |
|       struct_Huge36_case |   1000 |   8,831.56 ns |    168.434 ns |     157.553 ns |   8,871.31 ns |   38 |   5.7068 |        - |        - |   36024 B |
|       struct_Huge52_case |   1000 |  10,377.62 ns |    124.901 ns |     104.298 ns |  10,386.16 ns |   39 |   8.2550 |        - |        - |   52024 B |
|      struct_Huge116_case |   1000 |  75,103.73 ns |  1,251.190 ns |   1,109.147 ns |  74,744.89 ns |   43 | 181.6406 | 181.6406 |  30.2734 |  116034 B |
|               **class_case** |  **10000** |  **75,023.88 ns** |  **1,175.496 ns** |   **1,099.560 ns** |  **74,988.70 ns** |   **43** |  **50.7813** |  **16.9678** |        **-** |  **320024 B** |
|  class_case_CachedLength |  10000 |  77,461.30 ns |  1,504.889 ns |   2,298.124 ns |  76,418.38 ns |   44 |  50.7813 |  16.9678 |        - |  320024 B |
|    class_WithString_case |  10000 | 107,911.40 ns |  1,582.435 ns |   1,321.405 ns | 107,770.70 ns |   46 |  63.5986 |  22.7051 |        - |  400024 B |
|        class_Huge20_case |  10000 | 120,097.42 ns |  2,353.089 ns |   3,521.993 ns | 118,648.06 ns |   48 |  76.4160 |  38.0859 |        - |  480024 B |
|        class_Huge36_case |  10000 | 146,709.52 ns |  2,914.546 ns |   2,862.474 ns | 146,180.68 ns |   50 | 101.8066 |  57.6172 |        - |  640024 B |
|        class_Huge52_case |  10000 | 169,359.14 ns |  3,081.248 ns |   4,113.377 ns | 168,230.03 ns |   51 | 127.4414 |  87.8906 |        - |  800024 B |
|       class_Huge116_case |  10000 | 264,039.23 ns |  4,460.717 ns |   4,580.828 ns | 263,900.34 ns |   54 | 229.4922 | 163.5742 |        - | 1440024 B |
|              struct_case |  10000 | 100,048.44 ns |  1,013.135 ns |     947.687 ns | 100,189.06 ns |   45 | 239.5020 | 239.5020 |  39.9170 |  160037 B |
|   struct_case_Stackalloc |  10000 |  23,008.00 ns |    450.340 ns |     585.570 ns |  22,841.05 ns |   42 |        - |        - |        - |         - |
| struct_case_CachedLength |  10000 | 100,837.57 ns |  1,522.236 ns |   1,271.136 ns | 100,806.30 ns |   45 | 239.5020 | 239.5020 |  39.9170 |  160037 B |
|   struct_WithString_case |  10000 | 126,858.54 ns |  1,482.751 ns |   1,386.966 ns | 126,753.00 ns |   49 | 239.0137 | 239.0137 |  39.7949 |  160037 B |
|       struct_Huge20_case |  10000 | 116,512.25 ns |  1,468.740 ns |   1,302.000 ns | 116,683.04 ns |   47 | 178.5889 | 178.5889 |  51.0254 |  200040 B |
|       struct_Huge36_case |  10000 | 232,808.01 ns |  2,769.880 ns |   2,590.948 ns | 232,569.21 ns |   53 | 285.4004 | 285.4004 |  81.5430 |  360051 B |
|       struct_Huge52_case |  10000 | 214,887.57 ns |  4,273.287 ns |   8,435.051 ns | 214,718.38 ns |   52 | 145.0195 | 145.0195 | 109.6191 |  520057 B |
|      struct_Huge116_case |  10000 | 677,285.19 ns | 54,540.396 ns | 160,813.587 ns | 750,873.95 ns |   55 | 196.7773 | 196.7773 | 194.3359 | 1160084 B |
