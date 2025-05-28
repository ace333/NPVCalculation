FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY NPVCalculation.Application/. ./NPVCalculation.Application
COPY NPVCalculation.Domain/. ./NPVCalculation.Domain
COPY NPVCalculation.Infrastructure/. ./NPVCalculation.Infrastructure
COPY NPVCalculation.Api/. ./NPVCalculation.Api
COPY Shared.ApiInfrastructure/. ./Shared.ApiInfrastructure
COPY Shared.Domain/. ./Shared.Domain

RUN dotnet publish NPVCalculation.Api/NPVCalculation.Api.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "NPVCalculation.Api.dll"]