FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/mybill/LiveImport.MyBill/LiveImport.MyBill.csproj", "LiveImport.MyBill/"]
RUN dotnet restore "src/mybill/LiveImport.MyBill/LiveImport.MyBill.csproj"
COPY . .
WORKDIR "/src/LiveImport.MyBill"
RUN dotnet build "LiveImport.MyBill.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiveImport.MyBill.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiveImport.MyBill.dll"]
