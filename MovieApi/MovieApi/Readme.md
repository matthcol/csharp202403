# API Movie
## TODO List
Add in the API following features:
- update movie
- delete movie (by id)
- search by title part (case insensitive)
- search by year, year range
- serch by title, year
Error handling:
- transform id not found with HTTP response with status 404
Logging:
- add a logger (DI) and log actions in the controller

## DB Migrations
Open CLI:  Nugget Package Console commands

### List DbContexts of the project
```
Get-DbContext
```
### Generate SQL DDL Script for the whole database
```
Script-DbContext -Output movie-ddl.sql
Script-DbContext -Context MovieDbContext -Output movie-ddl.sql
Script-DbContext -Context MovieApi.Repository.MovieDbContext  -Output movie-ddl.sql 
```
### Manage Migrations

#### Create/apply Migration
```
Add-Migration InitialCreate
Update-Database # (apply last migration)
Update-Database NameMigration # (go forward or backward to migration NameMigration)
```

#### Create Script for one or several migrations
```
Script-Migration -From Mig1 -To Mig2 -Output script.sql (0 is a special migration before initial creation)
```

## Docker
### MS SQL Server
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Passw0rd!" -e "MSSQL_PID=Developer" -p 1433:1433  --name dbmovie -d mcr.microsoft.com/mssql/server:2022-latest
```