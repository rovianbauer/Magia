# Magia
Projeto para agendamento de salas de reunião (WebAPI).

Foi desenvolvido utilizando .NET Core 3.1 com arquitetura DDD, Entity Framework Core, AutoMapper, Flunt Notifications, MS Test (Commands), MediatR, Swagger entre outras coisas... 

Para utilização você deve clonar o projeto na sua maquina, ajustar a connection string do banco no AppSettings.json e executar o comando "Update-Database" para o entity framework criar o seu banco de dados.

O projeto conta com o Swagger para documentação dos endpoints.

Endpoints disponíveis 


* [POST] /salas (Deve ser utilizado para cadastro de uma nova sala de reunião)
* Exemplo body
{
  "descricao": "Sala de reunião 1"
}

* [GET] /salas (Retorna a lista com todas as salas de reuniões)

* [POST] /agendamentos (Cadastrar uma nova reunião para uma sala, o parametro SalaId deve ser obtido atravez do endpoint [GET] /salas)
* Exemplo body
{
	"salaId" : "727cc132-204f-47fe-a6f6-e43adc0fbc8a",
  "titulo": "Reunião diretores",
  "dataHoraInicio": "2021-02-20T00:00:00",
  "dataHoraFim": "2021-02-21T22:00:00"
}








