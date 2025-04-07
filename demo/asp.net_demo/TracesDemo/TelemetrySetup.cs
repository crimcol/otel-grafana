using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace TracesDemo;

public static class TelemetrySetup
{
    public static T AddAppTelemetry<T>(this T builder) where T: IHostApplicationBuilder
    {
        builder.Services
            .AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(
                serviceName: builder.Environment.ApplicationName,
                serviceVersion: System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version?.ToString(3), // SemVer
                serviceInstanceId: DateTime.UtcNow.ToString("yyyy_MMdd_HHmm_ss")
                )
            )
            .WithLogging()
            .WithTracing(traces => traces
                .AddSource("*") // Replace with your application name
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .SetSampler(new AlwaysOnSampler())
            )
            .WithMetrics(metrics => metrics
                // Metrics provider from OpenTelemetry    
                .AddMeter("*")
                .AddAspNetCoreInstrumentation()
                .AddRuntimeInstrumentation()
                .AddProcessInstrumentation()
                .AddHttpClientInstrumentation()
                .AddPrometheusExporter())
            .UseOtlpExporter();

        return builder;
    }
}
