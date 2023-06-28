# Converting in-process to isolated functions
# Caveat
This solution is <u>**NOT**</u> intended to demonstrate production-standard code.  It is a stripped-back solution just intended to demonstrate the major differences between a .Net 6 in-process function and a .Net 7 isolated function.

# Running and testing the function(s)
If you want to test the service bus and cosmos bindings function then you will need your own Service Bus and Cosmos instances to read from/write to.  See the `ServiceBusToCosmosFunction.cs` class for the names of the queues, databases, containers and partition keys expected.

If you don't want to go to the bother of having a service bus and cosmos instance, then just comment out the `ServiceBusToCosmosFunction.cs` code.

Add a local.settings.json file making sure the `Copy to Output Directory` attribute is set to `Copy Always` or `Copy if Newer`.  The content should look like this:
```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "SB_CONNECTIONSTRING": "<service bus connection string>",
        "COSMOS_CONNECTIONSTRING": "<cosmos connection string>"
    }
}
```
If you are going to deploy to Azure, you will need to add the same two connection string values above into the relevant config settings in the `infra/app/modules/functionapp.bicep` file


See the Docs folder for a Postman collection and two environment files (one for in process, one for isolated process).  NB: You *MAY* have to update the values in those environments to match what you get when you run the function on your machine.
## Additional reading
- [Isolated Functions Overview - benefits and walkthrough](https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide)
- [.NET on Azure Functions Roadmap Update September 2022](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/net-on-azure-functions-roadmap-update/ba-p/3619066)
- [Azure Functions - May 2023 update for Microsoft Build](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/azure-functions-may-update-for-microsoft-build/ba-p/3827388)
- [Nuget package to allow FunctionContext to be injectable](https://www.nuget.org/packages/Functions.Worker.ContextAccessor/)
