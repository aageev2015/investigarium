using net6benchmark.Benchmark;
using net6benchmark.Benchmark.StopWatch;


var runner = new BenchmarkRunnerViaStopWatch();
var publisher = new BenchmarkResultsPublisherConsole();

publisher.Publish(runner.Run(new net6benchmark.SingleAspect.Exceptions.BenchmarkThrowCatchException_Throw()));
publisher.Publish(runner.Run(new net6benchmark.SingleAspect.Exceptions.BenchmarkThrowCatchException_NotThrow()));
publisher.Publish(runner.Run(new net6benchmark.SingleAspect.Exceptions.BenchmarkThrowCatchException_ValueCheckFail()));
publisher.Publish(runner.Run(new net6benchmark.SingleAspect.Exceptions.BenchmarkThrowCatchException_ValueCheckSuccess()));

