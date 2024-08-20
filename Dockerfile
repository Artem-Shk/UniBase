# Используем образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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
WORKDIR /Unibase.client
COPY ["Unibase.client/package.json", "Unibase.client/package-lock.json", "./"]
RUN npm install
COPY Unibase.client/ .  
RUN npm run build

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /Unibase
COPY --from=publish /app/publish .
COPY --from=react-build /app/build ./wwwroot

# Запуск приложения
ENTRYPOINT ["dotnet", "Unibase.Server.dll"]