namespace GraphQLService
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Diagnostics.Tracing;
    using System.Globalization;
    using System.Text;

    internal class ServiceEventListener : EventListener
    {
        private const string filepath = "/tmp/";
        private string fileName =  "graphql-service" + "_" +  "GraphQLService" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".log";

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            string message = "";

            if (eventData.Message != null)
            {
                message = string.Format(CultureInfo.InvariantCulture, eventData.Message, eventData.Payload.ToArray());
            }

            using (StreamWriter writer = new StreamWriter( new FileStream(filepath + fileName, FileMode.Append)))
            {
                writer.WriteLine(Write(eventData.Task.ToString(),
                eventData.EventName,
                eventData.EventId.ToString(),
                eventData.Level, message));
            }
        }

        private static string Write(string taskName, string eventName, string id, EventLevel level, string message)
        {
            StringBuilder output = new StringBuilder();

            DateTime now = DateTime.UtcNow;
            output.Append(now.ToString("yyyy/MM/dd-HH:mm:ss.fff", CultureInfo.InvariantCulture));
            output.Append(',');
            output.Append(level);
            output.Append(',');
            output.Append(taskName);

            if (!string.IsNullOrEmpty(eventName))
            {
                output.Append('.');
                output.Append(eventName);
            }

            if (!string.IsNullOrEmpty(id))
            {
                output.Append('@');
                output.Append(id);
            }

            if (!string.IsNullOrEmpty(message))
            {
                output.Append(',');
                output.Append(message);
            }

            return output.ToString();
        }
    }
}