FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY DotnetK8sApi.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish DotnetK8sApi.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish ./
RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app

USER appuser
ENTRYPOINT ["dotnet", "DotnetK8sApi.dll"]
