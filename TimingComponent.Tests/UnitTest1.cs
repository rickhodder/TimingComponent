using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimingComponent.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWithoutAsync()
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

            var timing = new TimingComponent(config, new ConsoleLogger());
            timing.Start();
            Thread.Sleep(5000);
            timing.Stop() ;
		}

        //[TestMethod]
        //public void TestWithAsync()
        //{
        //    var config = new TimingComponentConfiguration
        //    {
        //        ServiceName = "Rick's Service",
        //        IntervalInMillseconds = 2000,
        //        Perform = async () =>
        //        {
        //            Console.WriteLine("Fired");
        //            var t = new TestAsync();
        //            await t.Run();
        //        }
        //    };

        //    var timing = new TimingComponent(config, new ConsoleLogger());
        //    timing.Start();
        //    Console.ReadLine();
        //}

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

    //public class TestAsync
    //{
    //    public async Task<bool> Run()
    //    {
    //        return await Step1();
    //    }

    //    public async Task<bool> Step1()
    //    {
    //        return await Step2();
    //    }

    //    public async Task<bool> Step2()
    //    {
    //        await Task Thread.Sleep(2000);
    //        return true;
    //    }

    //}


}
