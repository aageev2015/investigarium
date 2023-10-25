using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHistoricalNet7_8Features.Tests
{
	internal static class EventsTests
	{
		public static void Test1()
		{
            EventProgram.Main();
		}


        public delegate string MyDel(string str);
	
        class EventProgram {
            public event MyDel MyEvent;
            public event Func<int, int> DigEvent;
		
            public EventProgram() {
                this.MyEvent += new MyDel(this.WelcomeUser);
                this.MyEvent += new MyDel(this.WelcomeUser2);
                this.DigEvent += (x) => x * 2;
                this.DigEvent += (x) => x * 3; 
            }
            public string WelcomeUser(string username) {
                Console.WriteLine("1");
                return "Welcome " + username;
            }

            public string WelcomeUser2(string username) {
                Console.WriteLine("2");
                return "Welcome 2 " + username;
            }

            public static void Main() {
                EventProgram obj1 = new EventProgram();
                var combined = (Func<int, int>?)Delegate.Combine(obj1.DigEvent.GetInvocationList());
                var res = combined?.DynamicInvoke(2);
                //string result = obj1.MyEvent("Tutorials Point");
                Console.WriteLine(res);
          }
        }
	}

}
