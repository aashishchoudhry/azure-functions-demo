using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrdersApi;

public class ProcessOrderFunction
{
    private readonly ILogger<ProcessOrderFunction> _logger;

    public ProcessOrderFunction(ILogger<ProcessOrderFunction> logger)
    {
        _logger = logger;
    }

    [Function("ProcessOrderFunction")]
    public async Task Run(
        [ServiceBusTrigger("orders-queue", 
            Connection = "ServiceBusConnection")] 
        string message)
    {
        _logger.LogInformation($"Processing order message: {message}");
        
        // Simulate processing
        await Task.Delay(100);
        
        _logger.LogInformation($"Order processed successfully.");
    }
}