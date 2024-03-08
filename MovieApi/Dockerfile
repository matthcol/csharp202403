FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG PASSWORD_ENV_SEEDED
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p ${PASSWORD_ENV_SEEDED}

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /App
COPY ./release .
#COPY ./dummy .
COPY --chmod=0755 --from=build /https/* /https/

ENTRYPOINT ["dotnet", "MovieApi.dll"]