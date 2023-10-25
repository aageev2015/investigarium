using System.Diagnostics;

namespace LearnHistoricalNet7_8Features.Stocks
{
    internal class Stock9_Ticks_in_MinSleep
    {

        private static ulong _counter;
        private static Stopwatch sw;

        public static void Do()
        {
            isDebuggerMessage();
            _counter = 0;
            sw = Stopwatch.StartNew();
            var cts = new CancellationTokenSource();
            var counterTask = Task.Run(() =>
            {
            loop:
                _counter++;
                if ((_counter & 0xFFFF) == 0)
                {
                    if (cts.Token.IsCancellationRequested) return;
                }
                goto loop;
            }, cts.Token);

            Thread.Sleep(1);
            Console.WriteLine("Start");

            var delays = new int[] { 0, 1, 2, 5, 10, 15, 20, 30, 60, 120 };
            int iterationsCount = 100;

            RunMeasurements(TestSleep, iterationsCount, delays);
            RunMeasurements(TestSleep_winmm, iterationsCount, delays);
            RunMeasurements(TestSpinWait, iterationsCount, new int[] { 1, 2, 5, 10, 100, 1000, 10000, 100000, 1000000 });
            RunMeasurements(TestLoopWait, iterationsCount, new int[] { 1, 2, 5, 10, 100, 1000, 10000, 100000, 1000000 });

            Console.WriteLine($"Cancel counter. {_counter}");
            cts.Cancel();
            Console.WriteLine($"Wait counter.  {_counter}");
            counterTask.Wait();
            Console.WriteLine($"Done.  {_counter}");

            isDebuggerMessage();
        }

        public static void RunMeasurements(Func<string, int, int> action, int iterationsCount, int[] delays)
        {
            for (var iteration = 0; iteration < iterationsCount; iteration++)
            {
                var testInstanceId = Guid.NewGuid().ToString();
                foreach (var delay in delays)
                {
                    sw.Reset();
                    sw.Start();
                    var counter = action(testInstanceId, delay);
                    sw.Stop();
                    Console.WriteLine($"('{action.Method.Name}', '{testInstanceId}', '{delay}', {counter}, {sw.ElapsedTicks}),");
                }
            }
        }

        public static int TestSleep(string testInstanceId, int delay)
        {

            var prevCounter = _counter;
            Thread.Sleep(delay);
            return (int)(_counter - prevCounter); // must be short enough
        }

        public static int TestSleep_winmm(string testInstanceId, int delay)
        {
            var prevCounter = _counter;
            Delay.Wait(delay);
            return (int)(_counter - prevCounter);  // must be short enough
        }

        public static int TestSpinWait(string testInstanceId, int delay)
        {
            var prevCounter = _counter;
            Thread.SpinWait(delay);
            return (int)(_counter - prevCounter);  // must be short enough
        }

        public static int TestLoopWait(string testInstanceId, int delay)
        {
            var prevCounter = _counter;
            for (var i = 0; i < delay; i++) { }
            return (int)(_counter - prevCounter);  // must be short enough
        }

        private static void isDebuggerMessage()
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Warning: Debugger attached");
            }
        }

    }
}

/*
MSSQL statistic analyse:
- table creation
create table Stats(
	Id uniqueidentifier not null primary key		default(newid()),
	CreatedOn datetime2 not null					default(sysdatetime()),
	TestName nvarchar(50) not null,
	TestInstance uniqueidentifier not null,
	Param1 int not null,
	Measure int not null,
	MeasureTicks int not null,
		index IX_comb clustered(TestName, TestInstance, Param1)
)
- insert prefix
insert into Stats(TestName, TestInstance, Param1, Measure, MeasureTicks) values
 */