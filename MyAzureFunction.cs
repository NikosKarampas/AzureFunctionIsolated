using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class MyAzureFunction
    {
        private readonly ILogger _logger;

        public MyAzureFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyAzureFunction>();
        }

        [Function("MyAzureFunction")]
        public ItemOutputType Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req, string name)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString($"Item created: {name}");

            return new ItemOutputType() 
            {
                TodoItem = new TodoItem 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = name 
                },
                Response = response
            };
        }
    }
}
