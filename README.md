# Solução ERP

## Sonar

```sh
dotnet tool install --global dotnet-sonarscanner
```

```sh
dotnet sonarscanner begin /k:"SolucaoERP" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_f0966f0204f6d264e5762a1017755fd2740e7fc6"
```

```sh
dotnet build
```

```sh
dotnet sonarscanner end /d:sonar.token="sqp_f0966f0204f6d264e5762a1017755fd2740e7fc6"
```

```sh
sonar-scanner.bat -D"sonar.projectKey=SolucaoERP" -D"sonar.sources=." -D"sonar.host.url=http://localhost:9000" -D"sonar.token=sqp_f0966f0204f6d264e5762a1017755fd2740e7fc6"
```


## Referências

[1. Curso Alura Identity Framework](https://github.com/alura-cursos/alura-identity/tree/Aula-5)