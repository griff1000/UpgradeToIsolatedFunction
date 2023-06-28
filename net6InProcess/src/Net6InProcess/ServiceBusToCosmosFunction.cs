namespace Net6InProcess
{
    using System;
    using System.Threading.Tasks;
    using FunctionCommon.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;

    public class ServiceBusToCosmosFunction
    {
        [FunctionName("ServiceBusToCosmosFunction")]
        public async Task Run([ServiceBusTrigger("people", Connection = "SB_CONNECTIONSTRING")] MyModel[] models,
            [CosmosDB(
                databaseName: "FunctionUpgrade",
                containerName: "People",
                Connection = "COSMOS_CONNECTIONSTRING",
                PartitionKey = "/name")] IAsyncCollector<MyModel> peopleOut,
            ILogger log)
        {
            try
            {
                foreach (var model in models)
                {
                    await peopleOut.AddAsync(model);
                }
            }
            catch (Exception e)
            {
                log.LogError(e, "Oops");
            }
        }
    }
}
