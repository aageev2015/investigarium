// from
// https://www.linkedin.com/posts/elliotone_net-cancellation-token-explianed-by-elliot-ugcPost-7188841067465650176--5tb

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock30_CancelToken2
    {

        public static async Task Do()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            Task longTask = Task.Run(() =>
            {
                for (var i = 0; i < 1000_000; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine(i);
                }
            }, token);

            await Task.Delay(1000, token);
            await cts.CancelAsync();

            try
            {
                await longTask;
                Console.WriteLine("success");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancelled");
            }
        }

    }
}
