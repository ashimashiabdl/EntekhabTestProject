FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5299

ENV ASPNETCORE_URLS=http://+:5299

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Hr.WebAPI/Hr.WebAPI.csproj", "Hr.WebAPI/"]
RUN dotnet restore "Hr.WebAPI\Hr.WebAPI.csproj"
COPY . .
WORKDIR "/src/Hr.WebAPI"
RUN dotnet build "Hr.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hr.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hr.WebAPI.dll"]

