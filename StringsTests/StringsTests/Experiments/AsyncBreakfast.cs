// Copypasted from somewhere
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringsTests.Experiments;

namespace StringsTests.Experiments.AsyncBreakfast
{
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class AsyncBreakfast: IExperimentAsync
    {
        public async Task RunAsync(int eCode = 0)
        {
            Coffee cup = PourCoffee();
            WriteLineWithTime("coffee is ready");

            var eggsTask = FryEggsAsync(2, 3000, 3000);
            var baconTask = FryBaconAsync(3, 3000, 3000);
            var toastTask = MakeToastWithButterAndJamAsync(2, 2000);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    WriteLineWithTime("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    WriteLineWithTime("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    WriteLineWithTime("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            WriteLineWithTime("oj is ready");
            WriteLineWithTime("Breakfast is ready!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number, int time1)
        {
            var toast = await ToastBreadAsync(number, time1);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            WriteLineWithTime("4 Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            WriteLineWithTime("3.2 Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            WriteLineWithTime("3.1 Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices, int time1)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                WriteLineWithTime("3 Putting a slice of bread in the toaster");
            }
            WriteLineWithTime("3 Start toasting...");
            await Task.Delay(time1);
            WriteLineWithTime("3 Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices, int time1, int time2)
        {
            WriteLineWithTime($"2 putting {slices} slices of bacon in the pan");
            WriteLineWithTime("2 cooking first side of bacon...");
            await Task.Delay(time1);
            for (int slice = 0; slice < slices; slice++)
            {
                WriteLineWithTime("2 flipping a slice of bacon");
            }
            WriteLineWithTime("2 cooking the second side of bacon...");
            await Task.Delay(time2);
            WriteLineWithTime("2 Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany, int time1, int time2)
        {
            WriteLineWithTime("1 Warming the egg pan...");
            await Task.Delay(time1);
            WriteLineWithTime($"1 cracking {howMany} eggs");
            WriteLineWithTime("1 cooking the eggs ...");
            await Task.Delay(time2);
            WriteLineWithTime("1 Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            WriteLineWithTime("Pouring coffee");
            return new Coffee();
        }

        private static void WriteLineWithTime(string message)
        {
            Console.WriteLine("{0:H:mm:ss ffff} {1}", DateTime.Now, message);
        }

	}
}
