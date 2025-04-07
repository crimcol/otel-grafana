using System.Diagnostics;

namespace TracesDemo.Endpoints;

public class ExternalDataLoggerTag { }

public static class ExternalDataEndpoint
{
    private readonly static ActivitySource _activitySource = new (nameof(ExternalDataEndpoint));
    public static void MapExternalData(this WebApplication app)
    {
        app.MapGet("/externaldata", async (ILogger<ExternalDataLoggerTag> logger, HttpClient httpClient) =>
        {
            using (_ = _activitySource.StartActivity("Parallel requests"))
            {
                await Task.WhenAll(
                    httpClient.GetStringAsync("https://httpstat.us/200?sleep=1000"),
                    httpClient.GetStringAsync("https://httpstat.us/200?sleep=500"));
            }

            try
            {
                using (_ = _activitySource.StartActivity("Request with error"))
                {

                    await httpClient.GetStringAsync("https://httpstat.us/500?sleep=100");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while making request");
            }

            var uuid = await httpClient.GetStringAsync("https://httpbin.org/uuid");

            return Results.Ok(new
            {
                message = "Http Parallel demo",
                uuid
            });
        })
        .WithName("GetExternalData");
    }
}
