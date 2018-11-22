# projecten3-1819-backend-groep-11-ideaalduaal
projecten3-1819-backend-groep-11-ideaalduaal created by GitHub Classroom

#### Sidenotes
* Connect to Ubuntu VM: ssh student@projecten3studserver11.westeurope.cloudapp.azure.com
* Bij wijzigingen : bash ~/publish.sh, script doet een git pull, publish dotnet app en restart daemon talentcoach.service

##### Ubuntu VM opstarten met azure cli
```az resource invoke-action --action start --ids "/subscriptions/89639668-734e-4437-bd58-91a44a206676/resourceGroups/rg_dfit_testlab_04/providers/Microsoft.DevTestLab/labs/TL_FBO_TESTLAB_04/virtualMachines/Projecten3StudServer11"```

#### Endpoints
All endpoints do have the following http requests: 
  
##### Url
* https://localhost:44392/api/competenties
* https://localhost:44392/api/activiteiten
* https://localhost:44392/api/richtingen
* https://localhost:44392/api/leerlingen
* https://localhost:44392/api/werkaanbiedingen
* https://localhost:44392/api/werkgevers
* https://localhost:44392/api/werkspreuken


