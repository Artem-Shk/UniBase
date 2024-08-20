FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Unibase/

# Копируем проект и восстанавливаем зависимости
COPY ["Unibase.Server/Unibase.Server.csproj", "Unibase.Server/"]
RUN dotnet restore "Unibase.Server/Unibase.Server.csproj"

# Копируем остальные файлы и собираем проект
COPY . .
RUN dotnet build "Unibase.Server/Unibase.Server.csproj" -c Release -o /app/build/

FROM build AS publish
WORKDIR /Unibase/
RUN dotnet publish "Unibase.Server/Unibase.Server.csproj" -c Release -o /app/publish

FROM node:14 AS react-build
WORKDIR /Unibase
# Копируем package.json и package-lock.json
COPY ["unibase.client/package.json", "unibase.client/package-lock.json", "./unibase.client/"]
RUN npm install

# Копируем остальные файлы клиентского приложения и собираем его
COPY unibase.client/ ./unibase.client/
WORKDIR /Unibase/unibase.client
RUN npm run build || { echo 'Build failed'; exit 1; }

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /Unibase
# Копируем опубликованные файлы сервера
COPY --from=publish /app/publish ./
# Копируем собранные файлы React в wwwroot
COPY --from=react-build /Unibase/unibase.client/build ./wwwroot
ENTRYPOINT ["dotnet", "Unibase.Server.dll"]
