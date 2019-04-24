FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Taskin/Taskin.csproj Taskin/
RUN dotnet restore Taskin/Taskin.csproj
COPY . .
WORKDIR /src/Taskin
RUN dotnet build Taskin.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Taskin.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Taskin.dll"]
