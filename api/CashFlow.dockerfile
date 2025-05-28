FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY CashFlow.Application/. ./CashFlow.Application
COPY CashFlow.Domain/. ./CashFlow.Domain
COPY CashFlow.Infrastructure/. ./CashFlow.Infrastructure
COPY CashFlow.Api/. ./CashFlow.Api
COPY Shared.ApiInfrastructure/. ./Shared.ApiInfrastructure
COPY Shared.Domain/. ./Shared.Domain

RUN dotnet publish CashFlow.Api/CashFlow.Api.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]