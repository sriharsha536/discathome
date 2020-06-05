using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.ApplicationInsights.Channel;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters;

namespace DVDRentalAPI.Helpers.Extensions
{
    public class AppInsightsLogHelper
    {
        public AppInsightsLogHelper()
        {
        }
    }

    public class OperationIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var activity = Activity.Current;

            if (activity is null) return;

            logEvent.AddPropertyIfAbsent(new LogEventProperty("Operation Id", new ScalarValue(activity.Id)));
            logEvent.AddPropertyIfAbsent(new LogEventProperty("Parent Id", new ScalarValue(activity.ParentId)));
        }
    }

    public class OperationTelemetryConverter : TraceTelemetryConverter
    {
        const string OperationId = "Operation Id";
        const string ParentId = "Parent Id";

        public override IEnumerable<ITelemetry> Convert(LogEvent logEvent, IFormatProvider formatProvider)
        {
            foreach (var telemetry in base.Convert(logEvent, formatProvider))
            {
                if (TryGetScalarProperty(logEvent, OperationId, out var operationId))
                    telemetry.Context.Operation.Id = operationId.ToString();

                if (TryGetScalarProperty(logEvent, ParentId, out var parentId))
                    telemetry.Context.Operation.ParentId = parentId.ToString();

                yield return telemetry;
            }
        }

        private bool TryGetScalarProperty(LogEvent logEvent, string propertyName, out object value)
        {
            var hasScalarValue =
                logEvent.Properties.TryGetValue(propertyName, out var someValue) &&
                (someValue is ScalarValue);

            value = hasScalarValue ? ((ScalarValue)someValue).Value : default;

            return hasScalarValue;
        }
    }
}
