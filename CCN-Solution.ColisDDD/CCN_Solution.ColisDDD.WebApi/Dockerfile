#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.WebApi/CCN_Solution.ColisDDD.WebApi.csproj", "CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.WebApi/"]
COPY ["CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Application/CCN_Solution.ColisDDD.Application.csproj", "CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Application/"]
COPY ["CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Domain/CCN_Solution.ColisDDD.Domain.csproj", "CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Domain/"]
COPY ["CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Infrastructure.Shared/CCN_Solution.ColisDDD.Infrastructure.Shared.csproj", "CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Infrastructure.Shared/"]
COPY ["CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Infrastructure.Persistence/CCN_Solution.ColisDDD.Infrastructure.Persistence.csproj", "CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.Infrastructure.Persistence/"]
RUN dotnet restore "CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.WebApi/CCN_Solution.ColisDDD.WebApi.csproj"
COPY . .
WORKDIR "/src/CCN-Solution.ColisDDD/CCN_Solution.ColisDDD.WebApi"
RUN dotnet build "CCN_Solution.ColisDDD.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CCN_Solution.ColisDDD.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CCN_Solution.ColisDDD.WebApi.dll"]