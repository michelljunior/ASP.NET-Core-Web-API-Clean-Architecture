## ASP.NET Core Web API Clean Architecture


#### Como rodar a migration (LocalDB)
```
dotnet ef migrations add CriacaoDoBanco --project ApiTeste.Persistence

dotnet ef database update --project ApiTeste.Persistence
```

#### Credenciais para testar
```
CPF: 61647379237
Senha: teste
```

## Script para scaffolding (LocalDB)

```
dotnet ef dbcontext scaffold "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=bancoApiTeste;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities
```

