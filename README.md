# CRUD Dapper com .NET 8

Este projeto implementa um CRUD utilizando o Dapper para acesso ao banco de dados e .NET 8. É um exemplo prático de como criar uma aplicação simples que realiza operações de criação, leitura, atualização e remoção de usuários.

## Tecnologias Utilizadas

- **.NET 8**
- **Dapper**
- **AutoMapper**
- **SQL Server**

## Estrutura do Projeto

### Diretórios Principais
- **Controllers:** Contém os endpoints da API.
- **Services:** Implementações de serviços que lidam com a lógica de negócio.
- **Models:** Define as classes que representam as entidades do banco de dados.
- **Dto:** Define os objetos de transferência de dados (DTOs).
- **Profiles:** Configurações do AutoMapper para mapear entidades e DTOs.

### Principais Classes

#### **Models/User.cs**
Representa o modelo de usuário no banco de dados:

```csharp
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Profession { get; set; }
    public double Salary { get; set; }
    public string CPF { get; set; }
    public bool Situation { get; set; }
    public string Passw { get; set; }
}
```

#### **Dto/UserEditDto.cs**
Utilizado para transferir dados na edição de usuários:

```csharp
public class UserEditDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Profession { get; set; }
    public double Salary { get; set; }
    public string CPF { get; set; }
    public string Passw { get; set; }
}
```

#### **Profiles/ProfileAutoMapper.cs**
Configura o mapeamento entre entidades e DTOs:

```csharp
public class ProfileAutoMapper : Profile
{
    public ProfileAutoMapper()
    {
        CreateMap<User, ListUserDto>();
        CreateMap<User, IncludeUserDto>();
        CreateMap<User, UserEditDto>();
    }
}
```

### Endpoints Disponíveis

#### **GET /api/User**
Retorna a lista de todos os usuários.

#### **GET /api/User/GetUserById/{Id}**
Retorna um usuário específico pelo ID.

#### **POST /api/User**
Adiciona um novo usuário.

- **Exemplo de Corpo da Requisição:**

```json
{
  "FullName": "João Silva",
  "Email": "joao@email.com",
  "Profession": "Desenvolvedor",
  "Salary": 5000.0,
  "CPF": "12345678900",
  "Passw": "senha123",
  "Situation": true
}
```

#### **PUT /api/User/UpdateUser**
Atualiza um usuário existente.

- **Exemplo de Corpo da Requisição:**

```json
{
  "Id": 1,
  "FullName": "João Silva",
  "Email": "joao@email.com",
  "Profession": "Arquiteto de Software",
  "Salary": 7000.0,
  "CPF": "12345678900",
  "Passw": "novaSenha123"
}
```

#### **DELETE /api/User/DeleteUser{Id}**
Remove um usuário pelo ID.

### Configuração

1. **Banco de Dados:**
   - Crie um banco de dados SQL Server.
   - Adicione uma tabela chamada `Users` com as seguintes colunas:

```sql
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Profession NVARCHAR(100),
    Salary FLOAT,
    CPF NVARCHAR(11),
    Situation BIT,
    Passw NVARCHAR(50)
);
```

2. **Configuração do Appsettings:**
   Atualize a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
  }
}
```

3. **Rodar a Aplicação:**
   - Compile e rode o projeto.
   - Use uma ferramenta como o Postman ou Swagger para testar os endpoints.

### Dependências
Certifique-se de instalar as dependências abaixo no projeto:

- **Dapper:**
  ```bash
  dotnet add package Dapper
  ```

- **AutoMapper:**
  ```bash
  dotnet add package AutoMapper
  ```

- **AutoMapper.Extensions.Microsoft.DependencyInjection:**
  ```bash
  dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
  ```

### Melhorias Futuras

- Adicionar autenticação e autorização nos endpoints.
- Implementar testes unitários para os serviços e controladores.
- Incluir paginação na listagem de usuários.
- Validar os dados de entrada com FluentValidation.

---

Este README está pronto para ser colado no repositório do projeto. Basta copiá-lo e ajustar detalhes específicos, se necessário!

