using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services;

namespace UiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                ServiceEventSource.Current.Message("Registering Service : {0}", "ui-service");

                ServiceRuntime.RegisterServiceAsync(
                        "UiserviceType",
                        context => new UiWebService(context)).GetAwaiter().GetResult();        

                ServiceEventSource.Current.Message("Service registered : {0}", "ui-service");
                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(UiWebService).Name);
            
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e);
                throw;
            }
        }
    }
}
