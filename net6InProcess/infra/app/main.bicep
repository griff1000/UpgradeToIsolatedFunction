@description('Unique identifier for this deployment')
param deployId string

module service 'Modules/functionapp.bicep' = {
    name: '${deployId}-functionappresources'
    params: {
        location: {
            name: 'North Europe'
        }
    }
}
