namespace Net7Isolated
{
    using AdditionalCode;
    using FunctionCommon.Models;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    public class ServiceBusToCosmosFunction
    {
        [Function("ServiceBusToCosmosFunction")]
        public BindingContainer Run([ServiceBusTrigger("people", Connection = "SB_CONNECTIONSTRING", IsBatched = true)] IEnumerable<MyModel> models,
            FunctionContext context)
        {
            var myOutput = new BindingContainer();
            try
            {
                foreach (var model in models)
                {
                    myOutput.MyModels.Add(model);
                }
            }
            catch (Exception e)
            {
                var log = context.GetLogger("ServiceBusToCosmosFunction");
                log.LogError(e, "Oops");
            }
            return myOutput;
        }
    }
}
