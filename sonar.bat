dotnet sonarscanner begin /k:"asdasd" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_ba89ffadb8dc8c735027d9607c808b18905a5301"
dotnet build SolucaoErp.sln
dotnet sonarscanner end /d:sonar.token="sqp_ba89ffadb8dc8c735027d9607c808b18905a5301"