using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimingComponent;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestWithoutAsync();
            TestWithAsync();
        }

        private static void TestWithoutAsync()
        {
            var config = new TimingComponentConfiguration
            {
                ServiceName = "Rick's Service",
                IntervalInMillseconds = 2000,
                Perform = () =>
                {
                    Console.WriteLine("Fired");
                    var t = new Test();
                    t.Run();
                }
            };

            var timing = new TimingComponent.TimingComponent(config, new ConsoleLogger());
            timing.Start();
            Console.ReadLine();
        }
        private static async void TestWithAsync()
        {
            var config = new TimingComponentConfiguration
            {
                ServiceName = "Rick's Service",
                IntervalInMillseconds = 2000,
                Perform = async () =>
                {
                    Console.WriteLine("Fired");
                    var t = new TestAsync();
                    await t.RunAsync();
                }
            };

            var timing = new TimingComponent.TimingComponent(config, new ConsoleLogger());
            timing.Start();
            Console.ReadLine();
        }

    }

    public class Test
    {
        public bool Run()
        {
            return Step1();
        }

        public bool Step1()
        {
            return Step2();
        }

        public bool Step2()
        {
            Thread.Sleep(2000);
            return true;
        }

    }

    public class TestAsync
    {
        public async Task<bool> RunAsync()
        {
            return await Step1Async();
        }

        public async Task<bool> Step1Async()
        {
            return await Step2Async();
        }

        public async Task<bool> Step2Async()
        {
            Thread.Sleep(2000);

            await Task.Delay(1);
            return true;
        }

    }

}
