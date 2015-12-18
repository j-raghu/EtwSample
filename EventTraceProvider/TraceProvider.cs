
using Microsoft.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
//using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTraceProvider
{
   


    //[EventSource(Name = "Honeywell-ISP-Diagnosticsdsad")]
    public sealed class   TraceProvider:EventSource//,ITrace
    {
        public TraceProvider(string eventSourceName, EventSourceSettings config,string[] traits )
            : base(eventSourceName, config, traits)
        {

            //AttributeCollection attr = TypeDescriptor.GetAttributes(typeof(TraceProvider));
        }


        // [Event(1,  Level = EventLevel.Critical)]
         public void Failure(string message)
         {
            
             this.WriteEvent(1, message);
         }


        // [Event(2, Message = "Application:{0} -- {1}")]
         public void TraceDebug(string uniqueid,string message)
         {
             WriteEvent(2, uniqueid,message);
         }
        //  [Event(2, Message="Application:{0}",Level = EventLevel.Informational,Channel=EventChannel.Operational)]
        // public void TraceInfo(string message)
        //{
        //    WriteEvent(2, message);
        //}
        //  [Event(3, Message = "Application:{0}", Level = EventLevel.Warning)] 
        // public void TraceWarning( string Message)
        //{
        //    WriteEvent(3,  Message);
        //}
        //  [Event(4, Message = "Application:{0}", Level = EventLevel.Error)] 
        // public void TraceError( string Message)
        //{
        //    WriteEvent(4,  Message);
        //}
          //[Event(1, Message = "Application Failure: {0}-->{1}", Level = EventLevel.Critical)]
          //public void Failure(string message , string uniwueid)
          //{
          //    this.WriteEvent(1, message, uniwueid);
          //}

          //EventSourceSettings
         
          //sett.
         // static string s = ConfigurationManager.AppSettings["providerName"];
      //  s ="1w";


         public static TraceProvider Log = new TraceProvider("DiagnosticsSample", EventSourceSettings.EtwSelfDescribingEventFormat, null);

       //  public static TraceProvider Log = new TraceProvider();




          //public void TraceDebug(string UniqueID, string Message)
          //{
          //    throw new NotImplementedException();
          //}

          //public void TraceInfo(string UniqueID, string Message)
          //{
          //    throw new NotImplementedException();
          //}
    }
}
