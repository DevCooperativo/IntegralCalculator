FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY ["./src/IntegralCalculator.Web/IntegralCalculator.Web.csproj", "./src/IntegralCalculator.Web/"]

COPY ["./src/IntegralCalculator.DTO/IntegralCalculator.DTO.csproj", "./src/IntegralCalculator.DTO/"]

COPY ["./src/IntegralCalculator.Interfaces/IntegralCalculator.Interfaces.csproj", "./src/IntegralCalculator.Interfaces/"]

COPY ["./src/IntegralCalculator.Services/IntegralCalculator.Services.csproj", "./src/IntegralCalculator.Services/"]

RUN dotnet restore "./src/IntegralCalculator.Web/IntegralCalculator.Web.csproj"

COPY . .

RUN dotnet publish ./src/IntegralCalculator.Web/IntegralCalculator.Web.csproj -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80 

CMD ["dotnet", "IntegralCalculator.Web.dll"]