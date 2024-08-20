# Используем образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Unibase.Server

# Копируем только файл проекта для восстановления зависимостей
COPY ["Unibase.Server/Unibase.Server.csproj", "./"]
RUN dotnet restore "Unibase.Server.csproj"

# Копируем остальные файлы
COPY . .

# Строим проект
RUN dotnet build "Unibase.Server.csproj" -c Release -o /app/build

# Публикуем приложение
FROM build AS publish
RUN dotnet publish "Unibase.Server.csproj" -c Release -o /app/publish

# Создаем образ для React
FROM node:14 AS react-build
WORKDIR /app
COPY ["unibase.client/package.json", "unibase.client/package-lock.json", "./"]
RUN npm install
COPY unibase.client/ .  
RUN npm run build || { echo 'Build failed'; exit 1; }

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /Unibase
COPY --from=publish /app/publish ./runtimes
COPY --from=react-build /app ./wwwroot 