param location object

var appName = 'azfun-iansfuncapp'
var appPlanName = 'azpl-iansfuncapp'
var storageName = 'stiansfuncapp'

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-04-01' = {
  name: storageName
  location: location.name
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
  }
  properties: {
    supportsHttpsTrafficOnly: true
    minimumTlsVersion: 'TLS1_2'
    allowBlobPublicAccess: false
  }
}

resource appPlan 'Microsoft.Web/serverfarms@2021-01-15' = {
  name: appPlanName
  location: location.name
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
    size: 'Y1'
    family: 'Y'
    capacity: 0
  }
}

resource functionMain 'Microsoft.Web/sites@2021-01-15' = {
  name: appName
  location: location.name
  kind: 'functionapp'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appPlan.id
    httpsOnly: true
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageName};AccountKey=${listKeys(storageAccount.id, '2021-01-01').keys[0].value}'
        }  
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~4'
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'dotnet-isolated'
        }
        {
          name: 'WEBSITE_RUN_FROM_PACKAGE'
          value: '1'
        }
      ]
      ftpsState: 'Disabled'
      http20Enabled: true
      minTlsVersion: '1.2'
      netFrameworkVersion: 'v7.0'
      use32BitWorkerProcess: true
      phpVersion: ''
      alwaysOn: false
      defaultDocuments: []
      httpLoggingEnabled: true
      logsDirectorySizeLimit: 35
    }
  }
}

output appName string = functionMain.name
output appId string = functionMain.id
output appHostName string = functionMain.properties.defaultHostName