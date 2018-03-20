namespace PlService
{
    using System;
    using System.Diagnostics.Tracing;
    using System.Fabric;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Services.Runtime;

    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ServiceEventListener listener = new ServiceEventListener();
                listener.EnableEvents(ServiceEventSource.Current, EventLevel.LogAlways, EventKeywords.All);

                ServiceEventSource.Current.Message("Registering Service : {0}", "PlService");

                ServiceRuntime.RegisterServiceAsync("PlServiceType",
                    context => new PlService (context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.Message("Registered Service : {0}", "PlService");

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(ex);
                throw ex;
            }
        }
    }
}
