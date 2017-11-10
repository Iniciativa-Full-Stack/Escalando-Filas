# Escalando-Filas

É possível escalar com filas? Criamos um cenário de coleta de dados armazenando diretamente no SQL Server, e depois, criamos uma solução com RabbitMQ e um Consumidor para processar a Fila.
Vale a pena testar.

## Pré-Requisitos para o POC

    Visual Studio 2013
    SQL Server 
    RabbitMQ Server

## Criar tabelas no SQL Server

    Na install tem a Tabela que é o destino dos dados após o processo da fila via consumidor [link](install/sql/TABLE_BEHAVIORDATA.sql).

## Configurar o RabbitMQ

    Neste caso usem o https://www.cloudamqp.com, já deixei configurado.
    Basta apontar para o RabbitMQ que a Aplicação ajusta automaticamente.

## Configuração

    Alterar os Web.Configs do Consumidor e da Aplicação Web

## Apresentação

    É apenas o fluxo do Meet-Up com os detalhes dos Cenários propostos [link](MEET_UP_QUEUE.pptx).

## Load Test

    Foi criado um projeto no aplicativo [SOAP UI](https://www.soapui.org/downloads/soapui.html), basta importar o projeto com o [arquivo](test/NorrisTrip-soapui-project.xml).