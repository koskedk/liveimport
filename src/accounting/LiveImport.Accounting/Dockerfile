FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/accounting/LiveImport.Accounting/LiveImport.Accounting.csproj", "LiveImport.Accounting/"]
RUN dotnet restore "src/accounting/LiveImport.Accounting/LiveImport.Accounting.csproj"
COPY . .
WORKDIR "/src/LiveImport.Accounting"
RUN dotnet build "LiveImport.Accounting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiveImport.Accounting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiveImport.Accounting.dll"]
