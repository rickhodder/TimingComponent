using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TestConsole;
using TimingComponent;


namespace TestService
{
    public partial class TestService: ServiceBase
    {
        private TimingComponent.TimingComponent timing;

        public TestService()
        {
            //InitializeComponent();

            //var config = WithoutAsync();
            var config = WithAsync();

            timing = new TimingComponent.TimingComponent(config, new ConsoleLogger());
        }

        private TimingComponentConfiguration WithoutAsync()
        {
            return new TimingComponentConfiguration
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
        }

        private TimingComponentConfiguration WithAsync()
        {
            return new TimingComponentConfiguration
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

        }

        protected override void OnStart(string[] args)
        {
            timing.Start();
        }

        protected override void OnStop()
        {
            timing.Stop();
        }
    }
}
