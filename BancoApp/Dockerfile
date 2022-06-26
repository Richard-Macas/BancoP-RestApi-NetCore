FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /BancoP

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BancoP.API/*.csproj ./BancoP.API/

COPY . . 
WORKDIR "/BancoP/BancoP.API"
RUN dotnet build "BancoP.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BancoP.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BancoP.API.dll"]