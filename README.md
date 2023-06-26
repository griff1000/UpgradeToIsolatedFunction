# Converting in-process to isolated functions
# Caveat
This solution is not intended to demonstrate production-standard code.  It is a stripped-back solution just intended to demonstrate the major differences between a .Net 6 in-process function and a .Net 7 isolated function.

# Running and testing the function(s)

See the Docs folder for a Postman collection and two environment files (one for in process, one for isolated process).  NB: You *MAY* have to update the values in those environments to match what you get when you run the function on your machine.
## Additional reading
- [.NET on Azure Functions Roadmap Update September 2022](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/net-on-azure-functions-roadmap-update/ba-p/3619066)
- [Azure Functions - May 2023 update for Microsoft Build](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/azure-functions-may-update-for-microsoft-build/ba-p/3827388)
