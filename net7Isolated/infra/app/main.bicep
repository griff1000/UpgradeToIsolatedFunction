param deployId string = '12345'

module service 'Modules/functionapp.bicep' = {
    name: 'functionappresources-${deployId}'
    params: {
        location: {
            name: 'North Europe'
        }
    }
}