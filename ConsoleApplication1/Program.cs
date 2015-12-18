using EventTraceProvider;
using Microsoft.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace POC.Demo
{
    public class Data
    {

        public string message;
    }
    public class test
    {
        public static void test1(string id)
        {
            Type myType = typeof(Program);

            TraceProvider.Log.Failure("Pallavi");
            TraceProvider.Log.TraceDebug(id, "I am Done");
            
        }
    }
    class Program
    {
        
        static void Main()
        {
            string id = "123321323123";
            test.test1(id);
            
          
            
        }
        
    }

   
}
