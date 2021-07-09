#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ContaCorrente-Backend/ContaCorrente-Backend.csproj", "ContaCorrente-Backend/"]
RUN dotnet restore "ContaCorrente-Backend/ContaCorrente-Backend.csproj"
COPY . .
WORKDIR "/src/ContaCorrente-Backend"
RUN dotnet build "ContaCorrente-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContaCorrente-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContaCorrente-Backend.dll"]