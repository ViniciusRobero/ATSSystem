#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/ATSSystem.Api/ATSSystem.Api.csproj", "src/Apps/ATSSystem.Api/"]
COPY ["src/Common/ATSSystem.Infrastructure/ATSSystem.Infrastructure.csproj", "src/Common/ATSSystem.Api.Infrastructure/"]
COPY ["src/Common/ATSSystem.Application/ATSSystem.Application.csproj", "src/Common/ATSSystem.Api.Application/"]
COPY ["src/Common/ATSSystem.Domain/ATSSystem.Domain.csproj", "src/Common/ATSSystem.Api.Domain/"]
RUN dotnet restore "src/Apps/ATSSystem.Api/ATSSystem.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/ATSSystem.Api"
RUN dotnet build "ATSSystem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATSSystem.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATSSystem.Api.dll"]