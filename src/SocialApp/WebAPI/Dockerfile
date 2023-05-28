#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SocialApp/WebAPI/WebAPI.csproj", "src/SocialApp/WebAPI/"]
COPY ["src/SocialApp/Persistence/Persistence.csproj", "src/SocialApp/Persistence/"]
COPY ["src/Core/Core.Security/Core.Security.csproj", "src/Core/Core.Security/"]
COPY ["src/Core/Core.FileStorage/Core.FileStorage.csproj", "src/Core/Core.FileStorage/"]
COPY ["src/Core/Core.Persistence/Core.Persistence.csproj", "src/Core/Core.Persistence/"]
COPY ["src/SocialApp/Application/Application.csproj", "src/SocialApp/Application/"]
COPY ["src/Core/Core.Application/Core.Application.csproj", "src/Core/Core.Application/"]
COPY ["src/Core/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "src/Core/Core.CrossCuttingConcerns/"]
COPY ["src/Core/Core.Mailing/Core.Mailing.csproj", "src/Core/Core.Mailing/"]
COPY ["src/SocialApp/Domain/Domain.csproj", "src/SocialApp/Domain/"]
RUN dotnet restore "src/SocialApp/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/src/SocialApp/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]