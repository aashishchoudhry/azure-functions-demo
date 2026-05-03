using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrdersApi;

public class ProcessInvoiceFunction
{
    private readonly ILogger<ProcessInvoiceFunction> _logger;

    public ProcessInvoiceFunction(ILogger<ProcessInvoiceFunction> logger)
    {
        _logger = logger;
    }

    [Function("ProcessInvoiceFunction")]
    public void Run(
        [BlobTrigger("invoices/{name}", 
            Connection = "AzureWebJobsStorage")] 
        Stream blobStream, string name)
    {
        _logger.LogInformation($"Processing blob: {name}, Size: {blobStream.Length} bytes");
        
        // Process the file — parse invoice, extract data etc.
    }
}