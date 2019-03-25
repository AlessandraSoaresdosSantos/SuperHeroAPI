# SuperHeroAPI
Projeto WebApi SuperHeroAPI

Descrição técnica: 
Projeto WebApi, criado a partir do .Net Framework - versão 4.7.2, utilizando EntityFramework (versão 6.2.0) e migrations.
Este sistema foi devidamente destribuído nos seguintes projetos:
1) SuperHeroAPI.Commom
2) SuperHeroAPI.EntityFramework
3) SuperHeroAPI
4) SuperHeroAPI.Tests

Utilização do sistema:

1) No projeto SuperHeroAPI.EntityFramework, é necessário configurar a conexão de banco, através do arquivo web.config
Após isso, executar (update-database) para criação e carga no banco de dados  - este projeto utiliza o Banco de Dados SQL SERVER.

2) No projeto SuperHeroAPI, algumas atenções são necessárias para a execução do projeto. Para acessar os Controllers, é necessário a geração de Token (o projeto utilizou a referência "ClaimsIdentity"). Com esse acesso, codificar o Header com a permissão "Authorization", passando o valor do token gerado. Dessa forma, os dados referentes aos Controllers serão retornados.
Também foi implementado regras de acesso (Authorize) aos Controllers, nesse caso, foi implementado dois perfis de acesso ("Admin", "Standard").
Para todos os métodos POST, UDDATE e DELETE, são registrados os dados do solicitante da requisição, onde são gravados os seguintes dados: Entity, EntityId, Data, Action e Username_Id)

3) No projeto SuperHeroAPI.Tests, foi utilizado a referência MOQ. 
No projeto SuperHeroAPI.EntityFramework, foi configurado as Interfaces e Classes, contendo os dados moquados para a execução dos testes.
Na pasta SuperHeroAPI\TesteExecutado , é possível conferir o sucesso na execução destes testes.

4) No projeto SuperHeroAPI.Commom, está a regra de criptografia da senha do usuário.
Para tanto, foi utilizado a refência HashAlgorithm, com a formatação "X2".
Dessa forma, a senha do usuário (tabela Users), sempre será gravada de forma criptografada no banco de dados. 

Este projeto foi desenvolvido por Alessandra Soares
