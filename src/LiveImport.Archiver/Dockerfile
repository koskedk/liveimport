FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/LiveImport.Archiver/LiveImport.Archiver.csproj", "LiveImport.Archiver/"]
RUN dotnet restore "src/LiveImport.Archiver/LiveImport.Archiver.csproj"
COPY . .
WORKDIR "/src/LiveImport.Archiver"
RUN dotnet build "LiveImport.Archiver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiveImport.Archiver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiveImport.Archiver.dll"]
