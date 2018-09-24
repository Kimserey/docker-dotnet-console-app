FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY DockerConsoleApp/DockerConsoleApp.csproj DockerConsoleApp/
RUN dotnet restore DockerConsoleApp/DockerConsoleApp.csproj
COPY . .

FROM build AS publish
WORKDIR /src/DockerConsoleApp
RUN dotnet publish DockerConsoleApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerConsoleApp.dll"]