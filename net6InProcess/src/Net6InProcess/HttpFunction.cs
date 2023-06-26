namespace Net6InProcess
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using System.Net;
    using FunctionCommon.Models;
    using FunctionCommon.Services;

    public class HttpFunction
    {
        private readonly IMyService _myService;

        public HttpFunction(IMyService myService)
        {
            _myService = myService;
        }

        [FunctionName("PostFunction")]
        #region swagger
        [OpenApiOperation(operationId: "Post", tags: new[] { "name" })]
        [OpenApiRequestBody("application/json", typeof(MyModel), Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        #endregion
        public IActionResult Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] MyModel model, ILogger log)
        {
            var responseMessage = $"{_myService.SayHello(model.Name)}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GetFunction")]
        #region swagger
        [OpenApiOperation(operationId: "Get", tags: new[] { "name" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        #endregion
        public IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetFunction/{name:alpha}")] HttpRequest req, string name, ILogger logger)
        {
            //var name = req.Query["name"].ToString();

            var responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the request body for a personalized response."
                : $"{_myService.SayHello(name)}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
