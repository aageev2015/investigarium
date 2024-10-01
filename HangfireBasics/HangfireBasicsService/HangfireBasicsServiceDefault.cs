using HangfireBasicsServiceContract;

namespace HangfireBasicsService
{
    public class HangfireBasicsServiceDefault : IHangfireBasicsService
    {
        public void DoSomeWeatherJob()
        {
            Console.WriteLine($"{DateTime.Now.Ticks}. {Thread.CurrentThread.ManagedThreadId}. Background job processing");
        }

        public void DoSomethingRecurringJob()
        {
            Console.WriteLine($"{DateTime.Now.Ticks}. {Thread.CurrentThread.ManagedThreadId}. Recurring job processing");
        }
    }
}
