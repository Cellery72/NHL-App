using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Timers;
using Topshelf;

namespace NHLService
{
    class Program
    {
        private static readonly string CONFIGURATION_FILE = "Configuration/config.json";
        public class NHLParser
        {
            readonly Timer _timer;
            public NHLParser()
            {
                _timer = new Timer(1000) { AutoReset = true };
                _timer.Elapsed += (sender, eventArgs) => Console.WriteLine($"It is {DateTime.Now} and all is well");
            }
            public void Start() { _timer.Start(); }
            public void Stop() { _timer.Stop(); }
        }

        public static void Main(string[] args)
        {
            var config = JObject.Parse(File.ReadAllText(CONFIGURATION_FILE));

            var rc = HostFactory.Run(x =>
            {
                x.Service<NHLParser>(p =>
                {
                    p.ConstructUsing(name => new NHLParser());
                    p.WhenStarted(ps => ps.Start());
                    p.WhenStopped(ps => ps.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("This is an NHL Service");
                x.SetDisplayName("The NHL Service");
                x.SetServiceName("NHLService");
            });
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
