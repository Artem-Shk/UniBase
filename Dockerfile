FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Unibase/

COPY ["Unibase.Server/Unibase.Server.csproj", "./Unibase.Server/"]
RUN dotnet restore "Unibase.Server/Unibase.Server.csproj"
COPY . .
RUN dotnet build "Unibase.Server/Unibase.Server.csproj" -c Release -o /app/build/

FROM build AS publish
WORKDIR /Unibase/
RUN dotnet publish "Unibase.Server.csproj" -c Release -o /app/publish

FROM node:14 AS react-build
WORKDIR /Unibase
COPY ["unibase.client/package.json", "unibase.client/package-lock.json", "./"]
RUN npm install
COPY unibase.client/ .  
RUN npm run build || { echo 'Build failed'; exit 1; }

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /Unibase
COPY --from=publish /app/publish ./
COPY --from=react-build /app/build ./wwwroot
ENTRYPOINT ["dotnet", "Unibase.Server.dll"]