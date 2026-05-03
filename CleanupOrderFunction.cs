using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrdersApi;

public class CleanupOrdersFunction
{
    private readonly ILogger<CleanupOrdersFunction> _logger;

    public CleanupOrdersFunction(ILogger<CleanupOrdersFunction> logger)
    {
        _logger = logger;
    }

    [Function("CleanupOrdersFunction")]
    public void Run([TimerTrigger("0 0 * * * *")] TimerInfo timer)
    {
        _logger.LogInformation($"Cleanup job ran at: {DateTime.UtcNow}");
        // Delete old orders, archive data, send reports etc.
    }
}