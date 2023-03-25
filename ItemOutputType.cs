using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Company.Function
{
    public class ItemOutputType
    {
        [CosmosDBOutput("%DatabaseName%", "%ContainerName%", Connection = "CosmosConnection")]
        public TodoItem TodoItem { get; set; }
        public HttpResponseData Response { get; set; }
    }

    public class TodoItem
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}