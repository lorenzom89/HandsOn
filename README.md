
# Hands On! Horizon

Projeto criado para atender ao desafio tecnico o qual tinha como objetivo o desenvolvvimento de um sistema de passagens e controle de bagagens, usando C# e boas pr�ticas de programa��o, juntamente a padr�es de projeto


## Tech Stack

**Database:** PostgreSQL

**Server:** C#, .Net 8.0

**Client:** Blazor, Bootstrap






## Vari�veis de Ambiente

Para rodar este projeto voc� precisar� preencher as variaveis de ambiente em `Server/appsettings.json`. As varaveis que precisam ser preenchidas s�o:

- `DefaultConnection` com a string de conex�o com o banco de dados. 

- `JwtSection` com a chave Jwt e os links para o servidor da API



## Instalar e Rodar em Ambiente Local

Clone o projeto e abra no Visual Studio

```bash
  git clone https://github.com/lorenzom89/HandsOnHorizon.git
```

Ap�s abrir projeto, se o Visual Studio n�o instalar as dependencias automaticamente, rode o comando `dotnet restore` no terminal, assim ele vai instalar todas as dependencias do arquivo .csproj.
```bash
PM>  dotnet restore
```

Antes de rodar o projeto, ser� necess�rio rodar tamb�m o comando `Update-Database`no Console Gerenciador de Pacotes (Package Manager Console), onde ele ir� criar todas as tabelas no banco de dados atrav�s do Entity Framework

```bash
PM>  Update-Database
```

Ap�s estes passos, basta dar Build na solu��o, e iniciar os projetos **Server** e **Client**
## Features

- Login com autentica��o por JWT Token
- Construido no modelo SPA (Single Page Application)
- Utiliza��o do padr�o **MVCS** com abordagem _Model-First_



## Feedback

Se voc� tiver algum feedback, pode entrar em contato comigo atrav�s do email lorenzomoreti@yahoo.com

