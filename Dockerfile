# 1. Utiliser l'image du SDK .NET pour compiler
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# 2. Copier le fichier solution et les projets pour restaurer les dépendances
COPY MonProjet.sln ./
COPY formation-cicd/formation-cicd.csproj ./formation-cicd/
COPY MyProject.Tests/MyProject.Tests.csproj ./MyProject.Tests/
RUN dotnet restore

# 3. Copier tout le reste et compiler
COPY . ./
RUN dotnet publish formation-cicd/formation-cicd.csproj -c Release -o out

# 4. Créer l'image finale (plus légère) avec seulement le nécessaire pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# On dit à .NET d'écouter sur le port 8080 (standard pour Docker/Cloud)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "formation-cicd.dll"]