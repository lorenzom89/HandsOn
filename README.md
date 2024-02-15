
# Hands On! Horizon

Projeto criado para atender ao desafio tecnico o qual tinha como objetivo o desenvolvvimento de um sistema de passagens e controle de bagagens, usando C# e boas práticas de programação, juntamente a padrões de projeto


## Tech Stack

**Database:** PostgreSQL

**Server:** C#, .Net 8.0

**Client:** Blazor, Bootstrap






## Variáveis de Ambiente

Para rodar este projeto você precisará preencher as variaveis de ambiente em `Server/appsettings.json`. As varaveis que precisam ser preenchidas são:

- `DefaultConnection` com a string de conexão com o banco de dados. 

- `JwtSection` com a chave Jwt e os links para o servidor da API



## Instalar e Rodar em Ambiente Local

Clone o projeto e abra no Visual Studio

```bash
  git clone https://github.com/lorenzom89/HandsOnHorizon.git
```

Após abrir projeto, se o Visual Studio não instalar as dependencias automaticamente, rode o comando `dotnet restore` no terminal, assim ele vai instalar todas as dependencias do arquivo .csproj.
```bash
PM>  dotnet restore
```

Antes de rodar o projeto, será necessário rodar também o comando `Update-Database`no Console Gerenciador de Pacotes (Package Manager Console), onde ele irá criar todas as tabelas no banco de dados através do Entity Framework

```bash
PM>  Update-Database
```

Após estes passos, basta dar Build na solução, e iniciar os projetos **Server** e **Client**
## Features

- Login com autenticação por JWT Token
- Construido no modelo SPA (Single Page Application)
- Utilização do padrão **MVCS** com abordagem _Model-First_



## Feedback

Se você tiver algum feedback, pode entrar em contato comigo através do email lorenzomoreti@yahoo.com

