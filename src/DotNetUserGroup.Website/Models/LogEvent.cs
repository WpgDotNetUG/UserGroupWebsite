using System;
using System.Diagnostics;
using System.Web.Management;

namespace DotNetUserGroup.Website.Models
{
    public class LogEvent : WebRequestErrorEvent
    {
        public LogEvent(string message)
            : base(null, null, 100001, new Exception(message))
        {
            Trace.TraceError(message);
        }
    }
}