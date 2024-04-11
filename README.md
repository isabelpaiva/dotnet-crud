 # Simple .NET Crud 🔧
Este repositório contém um projeto de uma API construída usando .NET.

## Tabela de Conteúdos

- [Instalação](#instalação)
- [Configuração](#configuração)
- [API Endpoints](#api-endpoints)

## Instalação

1. Clone o repositório:

```bash
$ git clone git@github.com:isabelpaiva/dotnet-crud.git
```

## Configuração

1.  Na raiz do diretório do projeto, execute o seguinte comando para compilar e iniciar o aplicativo:

    ```bash
    dotnet run
    ```

2. 🗃️ O banco de dados SQLite já está configurado neste projeto.
    
3. A API estará acessível em [http://localhost:5108/swagger/index.html](http://localhost:5108/swagger/index.html)


## API Endpoints
A API fornece os seguintes endpoints:

```markdown
POST -   Cadastra um estudante.
 
GET  -   Lista um estudante.

PUT  -   Atualiza um estudante.

DELETE - Apaga um estudante.
```

## Configuração do Banco de Dados

Este projeto utiliza o Entity Framework Core para gerenciar o banco de dados e as migrações. Certifique-se de ter o SDK do Entity Framework Core instalado. Se não estiver instalado, você pode instalar seguindo os passos deste link:


[Documentação](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install)
