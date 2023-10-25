// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(typeof(Program).Assembly, new CustomConfig());

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        Options = ConfigOptions.KeepBenchmarkFiles;
    }
}