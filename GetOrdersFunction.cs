using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrdersApi;

public class GetOrdersFunction
{
    private readonly ILogger<GetOrdersFunction> _logger;

    public GetOrdersFunction(ILogger<GetOrdersFunction> logger)
    {
        _logger = logger;
    }

    [Function("GetOrdersFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("GetOrders function triggered.");

        // Read query parameter
        string status = req.Query["status"].ToString();

        var orders = new[]
        {
            new { Id = 1, Product = "Laptop", Status = "Pending" },
            new { Id = 2, Product = "Phone", Status = "Completed" },
            new { Id = 3, Product = "Tablet", Status = "Processing" }
        };

        // Filter if status provided
        var result = string.IsNullOrEmpty(status)
            ? orders
            : orders.Where(o => o.Status == status).ToArray();

        return new OkObjectResult(result);
    }
}