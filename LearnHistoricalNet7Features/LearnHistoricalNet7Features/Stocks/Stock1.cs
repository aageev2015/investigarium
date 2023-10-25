using System.ComponentModel.DataAnnotations;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock1
    {

        public static void Do()
        {
            //------------------------------------
            // RangeTests.Test1();
            // EventsTests.Test1();


            //------------------------------------
            //BenchmarkRunner.Run<ForEachVsFor>();

            //------------------------------------
            //EnumeratorFromArrayTricks.Run(Console.Out);

            //------------------------------------
            //RecordExperiments.Run(Console.Out);
            /*
			var t = new RecordExample[] {
				new RecordExample()
			};
	
			Console.WriteLine("------");
			var t2 = new RecordExample() { Name = "val1" };
			Console.WriteLine(t2.Name);
			Console.WriteLine(t2.Parent.Name);
			var p = t2.Parent;
			p = new RecordExample();
			t2.ChangeParent(new RecordExample() { Name = "val2" });
			Console.WriteLine(t2.Name);
			Console.WriteLine(t2.Parent.Name);
			var p2 = t2.Parent;
			Console.WriteLine(Object.ReferenceEquals(p, p2));
			Console.WriteLine(p.Name);
			Console.WriteLine(p2.Name);
			*/
            /*
			foreach(var i in typeof(DailyTemperature).GetInterfaces())
			{
				Console.WriteLine(i.Name);
			}
			*/

            //------------------------------------
            // 
            /*
			RRecord2 rec1 = new(new(10,20,"inner test1"), 30, "outer test2" );
			Console.WriteLine(rec1.rec1.val1);

			var tupl = (val1: 10, val2: 20, val3: "text");
			var tuple2 = (val1: 10, val2: 20, val3: "text1");



			object val = 500;
			val = "test";

			var t = val switch
			{
				10 => "ten",
				100 => "hundred",
				500 => "5 hundred",
				"test" => "test string",
				_ => "unknown"
			};

			var t2 = rec1 switch {
				{ val1: >5, val1: <=30, text2: not null} => "ok",
				_ => "unknown"
			};

			Console.WriteLine(t2);
			*/

            ////////////////////////////////////////
            RRecord3 rec3 = new(1, 44, 56, "Item 1", "some crazy item");

            var switchRec3 = rec3 switch
            {
                (_, _, _, "Item 1", var descr) => "rec3. ok1" + descr,
                { X: > 0, Description: var descr } => "rec3. ok2" + descr,
                _ => "unknown"
            };
            Console.WriteLine(switchRec3);

            ////////////////////////////////////////
            CClass4 class4 = new() { X = 1, Y = 44, Z = 56, Name = "Item 1", Description = "some crazy item" };
            var switchRes = class4 switch
            {
                { Name: "Item 1", Description: var descr } => "class4. ok1" + descr,
                { X: 1, Description: var descr } => "class4. ok2" + descr,
                _ => "unknown"
            };

            ////////////////////////////////////////
            var arr1 = new[] { "test1", "val1", "descr1", "data1" };
            var switchArr1Res = arr1 switch
            {
                [_, string t1, _, "data1", ..] when t1 == "val1" => $"found2 {t1}",
                [_, string t1, "descr1", ..] => $"found1 {t1}",
                _ => "unknown"
            };

            Console.WriteLine($"{nameof(switchArr1Res)} = {switchArr1Res}");

            ////////////////////////////////////////
            int outerInt = 0;

            var exp1 = () =>
            {
                for (int i = 0; i < 1; i++)
                {
                    SClass.doSomeghint(ref outerInt);
                }
            };
            int a = 2;
            var t = 1..^a;

            const int tasksCount = 10;
            var tasks = new Task[tasksCount];
            foreach (var i in Enumerable.Range(2, 7))
            {
                Console.WriteLine(i);
            }

            ////////////////////////////////////////
            ///
            Console.WriteLine($"Test MinLength");
            var obj1 = new TestMinLengthAttr();
            Console.WriteLine($"PropVal = {obj1.PropVal}");


            /*
			var task2 = new Task(exp1);
			task1.Start();
			task2.Start();
			Task.WaitAll(task1);
			Console.WriteLine(outerInt);
			*/

            /// /////////////////
            Console.WriteLine("list indexer + struct element");
            var strucList = (Span<SStruc1>)new SStruc1[1];
            strucList[0].Value = 52;

            /// /////////////////
            Console.WriteLine("record struct test");
            var recStr1Val = new RecStr1(10, "test val", DateTime.Now);
            (var v1, var v2, var v3) = recStr1Val;
            Console.WriteLine(recStr1Val);

            /// /////////////////
            Console.WriteLine("---- dynamic test ----");
            dynamic dynStruct = new RecStr1(10, "test val", DateTime.Now);
            Console.WriteLine(dynStruct.Val1);
            dynStruct = new int[] { 1, 2, 3 };
            Console.WriteLine(dynStruct.Length);

        }

        public static class SClass
        {
            public static void doSomeghint(ref int data)
            {
                data++;
            }

            public static ref int returnRef(int[] val)
            {
                var arr = new int[] { 1, 2, 3 };
                return ref arr[0];
            }
        }

        //////////////////////////////////////// --------------
        record RRecord1(int val1, int val2, string? text3);
        record RRecord2(RRecord1 rec1, int val1, string? text2);
        record RRecord3(int X, int Y, int Z, string Name, string Description);


        public class CClass4
        {
            public int X { get; init; }
            public int Y { get; init; }
            public int Z { get; init; }
            public string Name { get; init; } = string.Empty;
            public string Description { get; init; } = string.Empty;
        };

        public struct SStruc1
        {
            public int Value { get; set; }
        }

        public class TestMinLengthAttr
        {
            [MinLength(10)]
            public string PropVal { get; init; } = DefVAl;

            public static string DefVAl
            {
                get
                {
                    Console.WriteLine("return defVal");
                    return "defVal";
                }
            }
        }

        public record struct RecStr1(int Val1, string Val2, DateTime Date)
        {
            public int Val1 { get; set; } = Val1;
        }

    }
}
