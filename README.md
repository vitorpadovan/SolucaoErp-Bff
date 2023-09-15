# Solução ERP

## DataBase

```sql

// Use DBML to define your database structure
// Docs: https://dbml.dbdiagram.io/docs

Table Empresa{
  codEmpresa integer [primary key]
  nomeEmpresa varchar
}

Table Setor{
  codSetor integer [primary key]
  nomeSetor varchar
}

Table EmpresaSetor{
  codEmpresa integer [primary key]
  codSetor integer [primary key]
}

Ref: EmpresaSetor.codEmpresa > Empresa.codEmpresa
Ref: EmpresaSetor.codSetor > Setor.codSetor

Table Parceiro{
  codParceiro integer [primary key]
  nomeParceiro varchar
  pdv boolean
  am boolean
}

Table Endereco{
  codEndereco integer [primary key]
  cep integer
}

Table Produto{
  codProduto integer [primary key]
  nomeProduto varchar
}

Table NotaCab{
  codNota integer [primary key]
  codParceiro integer
  valor decimal
}

Table NotaIte{
  codNotaIte integer [primary key]
  codNota integer
  codProduto integer
}

Ref: NotaCab.codParceiro > Parceiro.codParceiro
Ref: NotaIte.codNota > NotaCab.codNota
Ref: NotaIte.codProduto > Produto.codProduto
```

### Referências

[dbDiagram.IO](https://dbdiagram.io/)

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