namespace Net7Isolated.AdditionalCode
{
    using System.Collections.Generic;
    using FunctionCommon.Models;
    using Microsoft.Azure.Functions.Worker;

    public class BindingContainer
    {
        [CosmosDBOutput("FunctionUpgrade", "People", Connection = "COSMOS_CONNECTIONSTRING", PartitionKey = "/name")]
        public List<MyModel> MyModels { get; set; } = new ();
    }
}
