# Controle de contatos

## Visão geral

Este projeto é um sistema de gerenciamento de contatos desenvolvido utilizando ASP.NET Core MVC. O sistema permite que os usuários autenticados realizem operações CRUD (Criar, Ler, Atualizar e Deletar) em uma lista de contatos. Além disso, o sistema inclui funcionalidades de autenticação e autorização para garantir que apenas usuários autorizados possam acessar e manipular os dados.

## Funcionalidades Principais

### 1. Autenticação de Usuários

- Registro de novos usuários.
- Login de usuários existentes.
- Logout seguro.
- Recuperação de senha.

### 2. CRUD de Contatos

- Criação: Formulário para adicionar novos contatos com campos como nome, telefone, email, endereço, etc.
- Leitura: Visualização de uma lista de contatos, com a possibilidade de pesquisa e paginação.
- Atualização: Edição dos detalhes de contatos existentes.
- Deleção: Remoção de contatos da lista.

## Estrutura do projeto

### 1. Camada de Apresentação (Views)

- Utilização do Razor para a renderização de páginas dinâmicas.
- Layouts e Views organizadas para cada funcionalidade (ex.: Login, Registro, Lista de Contatos, etc.).

### 2. Repositórios (Repositories)

- Implementação de padrões de repositório para acesso aos dados.
- Utilização do Entity Framework Core para operações de banco de dados.

### 3. Banco de Dados

- Utilização do MySql para armazenamento de dados.
- Migrações do Entity Framework Core para gerenciar a estrutura do banco de dados.

## Considerações Finais

Este projeto oferece uma solução completa para o gerenciamento de contatos, com foco na segurança e na organização dos dados. Através do uso do ASP.NET Core MVC, o sistema é robusto e escalável, permitindo futuras expansões e melhorias conforme necessário.
