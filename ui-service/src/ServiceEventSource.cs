using System;
using System.Diagnostics.Tracing;
using System.Fabric;
using Microsoft.ServiceFabric.Services.Runtime;

namespace UiService
{
    public class ServiceEventSource : EventSource
    {
        private const int MessageEventId = 1;
        private const int ServiceTypeRegisteredEventId = 3;
        private const int ServiceHostInitializationFailedEventId = 4;
        private const int ServiceWebHostBuilderFailedEventId = 5;

        public static ServiceEventSource Current = new ServiceEventSource();

        [NonEvent]
        public void Message(string message, params object[] args)
        {
            if (this.IsEnabled())
            {
                string finalMessage = string.Format(message, args);
                this.Message(finalMessage);
            }
        }

        [Event(MessageEventId, Level = EventLevel.Informational, Message = "{0}")]
        public void Message(string message)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(MessageEventId, message);
            }
        }

        [Event(ServiceTypeRegisteredEventId, Level = EventLevel.Informational, Message = "Service host process {0} registered service type {1}")]
        public void ServiceTypeRegistered(int hostProcessId, string serviceType)
        {
            this.WriteEvent(ServiceTypeRegisteredEventId, hostProcessId, serviceType);
        }

        [NonEvent]
        public void ServiceHostInitializationFailed(Exception e)
        {
            this.ServiceHostInitializationFailed(e.ToString());
        }

        [Event(ServiceHostInitializationFailedEventId, Level = EventLevel.Error, Message = "Service host initialization failed: {0}")]
        private void ServiceHostInitializationFailed(string exception)
        {
            this.WriteEvent(ServiceHostInitializationFailedEventId, exception);
        }

        [NonEvent]
        public void ServiceWebHostBuilderFailed(Exception e)
        {
            this.ServiceWebHostBuilderFailed(e.ToString());
        }

        [Event(ServiceWebHostBuilderFailedEventId, Level = EventLevel.Error, Message = "Service Owin Web Host Builder Failed: {0}")]
        private void ServiceWebHostBuilderFailed(string exception)
        {
            this.WriteEvent(ServiceWebHostBuilderFailedEventId, exception);
        }
    }
}