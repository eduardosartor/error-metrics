```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5247/22H2/2022Update)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2


```
| Method                  | Mean         | Error      | StdDev     |
|------------------------ |-------------:|-----------:|-----------:|
| UsingExceptions         | 61,719.63 μs | 843.365 μs | 788.884 μs |
| UsingSpecialReturnValue |     31.67 μs |   0.440 μs |   0.411 μs |
| UsingResponseObject     |    652.63 μs |  12.937 μs |  23.328 μs |
