using Benchmark;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<DictionaryBenchmark_ForEach>();
BenchmarkRunner.Run<DictionaryBenchmark_For>();
BenchmarkRunner.Run<DictionaryBenchmark_TryGetValue>();
BenchmarkRunner.Run<DictionaryBenchmark_IsDouble>();
