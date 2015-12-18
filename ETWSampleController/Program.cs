using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETWSampleController
{

    class Program
    {
        static void Main(string[] args)
        {

            var providerName = "DiagnosticsSample";
            //TraceEventProviders.get
            var providerGuid = TraceEventProviders.GetEventSourceGuidFromName(providerName);
            if (!(TraceEventSession.IsElevated() ?? false))
            {
                Console.WriteLine("To turn on ETW events you need to be Administrator, please run from an Admin process.");
            }

            Console.WriteLine("Creating a 'My Session' session");
            var sessionName = "My Session";
            using (var session = new TraceEventSession(sessionName, null))  // the null second parameter means 'real time session'
            {

                session.StopOnDispose = true;
                Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) { session.Dispose(); };
                using (var source = new ETWTraceEventSource(sessionName, TraceEventSourceType.Session))
                {

                    var parser = new DynamicTraceEventParser(source);
                    //source.Dynamic.All
                    //parser.All += delegate(TraceEvent data)
                    parser.All += delegate(TraceEvent data)
                    {

                        string level = "2";
                        if ((int)data.Level == Convert.ToInt32(level))
                        {
                            data.EventData();
                            if (data.ProviderGuid == providerGuid)  // We don't actually need this since we only turned one one provider. 
                            {
                                if (data.EventName.ToLower() != "manifestdata")
                                    SetLogInformation(data);
                            }
                        }
                    };


                    session.EnableProvider(providerGuid, TraceEventLevel.Informational);
                    Console.WriteLine("Staring Listing for events");
                    source.Process();
                    Console.WriteLine();
                    Console.WriteLine("Stopping the collection of events.");
                }
            }

        }
        private static void SetLogInformation(TraceEvent data)
        {
            Console.Write("Recevied Data.");

        }
    }
}
