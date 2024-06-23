// Not finished
using System.Runtime.CompilerServices;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_ArgsExpressionLogPerformance
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private class FakeLogger
        {
            private int LogState { get; set; }

            public void Log(string text)
            {
                LogState += text.Length;
            }
        }

        private FakeLogger Logger { get; set; }

        private string DefaultLogExpression { get; set; }
        private int InputValue { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Logger = new FakeLogger();
            DefaultLogExpression = "Unkown expression";
            InputValue = (new Random()).Next();
        }


        [Benchmark(Baseline = true)]
        public int tWithoutExp_ConstLog() => WithoutExpressionConstDefault(InputValue);

        [Benchmark]
        public int tWithoutExp_PropLog() => WithoutExpressionPropertyDefault(InputValue);

        [Benchmark]
        public int tWithExpButDefault() => WithExpression(InputValue);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int WithoutExpressionConstDefault(int inputParam)
        {
            Logger.Log(nameof(inputParam) + " = " + "Unkown expression");
            return inputParam * 2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int WithoutExpressionPropertyDefault(int inputParam)
        {
            Logger.Log(nameof(inputParam) + " = " + DefaultLogExpression);
            return inputParam * 2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int WithExpression(int inputParam,
            [CallerArgumentExpression("inputParam")] string inputParamExpression = "Unkown expression")
        {
            Logger.Log(nameof(inputParam) + " = " + inputParamExpression);
            return inputParam * 2;
        }

    }
}