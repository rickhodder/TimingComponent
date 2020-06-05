using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public class TestServiceBase : ServiceBase
    {
        public static void Main()
        {
            using (var service = new TestServiceBase())
            {
                if (Environment.UserInteractive)
                {
                    Console.Title = "Test Service";
                    Console.SetBufferSize(Console.BufferWidth, 32766);
                    Console.CancelKeyPress += (sender, e) => { service.OnStart(null); };

                    Console.WriteLine("Press Esc To End");
                    Console.Read();
                    service.OnStop();

                }
            }
        }
    }
}