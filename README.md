# .Net-NextJs-CinemaManager

## Requisitos
* Ter o docker instalado [LINK](https://www.docker.com/get-started).
* Ter o dotnet instalado [LINK](https://dotnet.microsoft.com/en-us/download).
* Verificar se as portas, 3000, 5432, 7156 estão disponíveis.

## Tecnologias utilizadas
* Back End
  * Entity Framework
  * Dotnet
  * Postrgres como banco de dados
  
* Front End
  * Next JS
  * Chakra UI
  * React Icons
  * Axios

## Passos para rodar o projeto
* Clonar repositório `git clone https://github.com/Wilhelm-Zimmermann/.Net-NextJs-CinemaManager.git`
* Abrir um terminal
  * Abrir a pasta `backend` digitar o comando `docker-compose up` para criar o banco de dados.
  * Digitar o comando `dotnet run`.
  * O Backend roda na porta 7156.
  
* Abra outro terminal.
  * Vá para a pasta frontend, digite o comando `yarn` para instalar todas as dependências.
  * Digitar o comando `yarn dev` para rodar o front end.
  * O Front end roda na porta 3000.
