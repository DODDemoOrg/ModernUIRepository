using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace ModernUIApp.Services
{
    public class ModernTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {

            telemetry.Context.Cloud.RoleName = "CRM Front-End";
        }
    }
}