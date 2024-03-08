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

NB: if you switch project from mssql to pg (and vice versa), remove all migrations

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
https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-8-0

### MS SQL Server
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Passw0rd!" -e "MSSQL_PID=Developer" -p 1433:1433  --name dbmovie -d mcr.microsoft.com/mssql/server:2022-latest
docker exec -it dbmovie bash
docker exec -it dbmovie bash -c 'ls -l /opt'
```

### PostgreSQL
```
docker run --name dbmovie-pg -e POSTGRES_PASSWORD=password -e POSTGRES_DB=dbmovie -p 5432:5432 -d postgres:16
docker exec -it dbmovie-pg bash
	psql -U postgres -d dbmovie
		\d
		 select * from "Movies";
docker exec -it dbmovie-pg psql -U postgres -d dbmovie -c 'select * from "\"Movies\""'
```

### Composition
files: docker-compose.yml + Dockerfile + .env
```
Script-DbContext -Output MovieApi\_sql\pg\movie-ddl.sql
docker compose up -d
docker compose exec -it db bash
docker compose exec -it db psql -U postgres -d dbmovie -c 'select * from "\"Movies\""'
docker compose exec -it db psql -U postgres -d dbmovie  -f /usr/src/view.sql
```

### Clean Docker Cache
docker system prune -a 