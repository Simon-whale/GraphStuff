# Graph QL Learning

This repo is for me to learn / implement GraphQL in an API.

I have used the Altair nuget package to allow me to be able to execute the calls to the server.  For more reading https://www.nuget.org/packages/GraphQL.Server.Ui.Altair

To allow for the mutations to work I created a database using SQL Server which installed using docker, you can install this via a docker run command just remember to change the password to something else

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
````
