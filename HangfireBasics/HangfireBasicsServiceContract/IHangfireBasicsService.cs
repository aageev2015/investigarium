namespace HangfireBasicsServiceContract
{
    public interface IHangfireBasicsService
    {
        public void DoSomeWeatherJob();

        public void DoSomethingRecurringJob();
    }
}
