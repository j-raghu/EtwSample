using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.Diagnostics
{
    public interface IEventTextFormatter
    {
        //void WriteEvent(EventEntry eventEntry, TextWriter writer);
    }
    class CustomFormatter : IEventTextFormatter
    {
    }
}
