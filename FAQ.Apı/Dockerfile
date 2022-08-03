#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FAQ.Apı/FAQ.Apı.csproj", "FAQ.Apı/"]
COPY ["FAQ.Business/FAQ.Business.csproj", "FAQ.Business/"]
COPY ["FAQ.Core/FAQ.Core.csproj", "FAQ.Core/"]
COPY ["FAQ.Entities/FAQ.Entities.csproj", "FAQ.Entities/"]
RUN dotnet restore "FAQ.Apı/FAQ.Apı.csproj"
COPY . .
WORKDIR "/src/FAQ.Apı"
RUN dotnet build "FAQ.Apı.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FAQ.Apı.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FAQ.Apı.dll"]