FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY WebApplication1/WebApplication1.csproj WebApplication1/
RUN dotnet restore WebApplication1/WebApplication1.csproj
COPY . .
WORKDIR /src/WebApplication1
RUN dotnet build WebApplication1.csproj -c Release -o /app
RUN dotnet publish WebApplication1.csproj -c Release -o /app

FROM boxfuse/flyway AS migration
WORKDIR /src
COPY --from=build /src .
RUN flyway migrate -url=jdbc:sqlite:/src/sqlitetest.db -locations=filesystem:WebApplication1/Migrations

FROM base AS final
WORKDIR /app
COPY --from=build /app .
COPY --from=migration /src/sqlitetest.db .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
