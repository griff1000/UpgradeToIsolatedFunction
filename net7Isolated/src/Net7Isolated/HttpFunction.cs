namespace Net7Isolated
{
    using FunctionCommon.Models;
    using FunctionCommon.Services;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
    using Microsoft.OpenApi.Models;
    using System.Net;
    using System.Text.Json;

    public class HttpFunction
    {
        private readonly IMyService _myService;

        public HttpFunction(IMyService myService)
        {
            _myService = myService;
        }

        [Function("PostFunction")]
        [OpenApiOperation(operationId: "Post", tags: new[] { "name" })]
        [OpenApiRequestBody("application/json", typeof(MyModel), Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<HttpResponseData> Post([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var model = await JsonSerializer.DeserializeAsync<MyModel>(req.Body);

            var responseMessage = $"{_myService.SayHello(model!.Name)}. This HTTP triggered function executed successfully.";

            await response.WriteStringAsync(responseMessage);

            return response;
        }

        [Function("GetFunction")]
        [OpenApiOperation(operationId: "Get", tags: new[] { "name" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public HttpResponseData Get([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetFunction/{name:alpha}")] HttpRequestData req, string name)
        {
            //var name = req.Query["name"];
            //var logger = req.FunctionContext.GetLogger("GetFunction");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the request body for a personalized response."
                : $"{_myService.SayHello(name)}. This HTTP triggered function executed successfully.";

            response.WriteString(responseMessage);

            return response;
        }
    }
}
