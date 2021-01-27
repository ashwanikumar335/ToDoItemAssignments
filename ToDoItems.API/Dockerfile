#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToDoItems.API/ToDoItems.API.csproj", "ToDoItems.API/"]
COPY ["Todo.Core/Todo.Core.csproj", "Todo.Core/"]
COPY ["ToDoItem.Data/ToDoItem.Data.csproj", "ToDoItem.Data/"]
RUN dotnet restore "ToDoItems.API/ToDoItems.API.csproj"
COPY . .
WORKDIR "/src/ToDoItems.API"
RUN dotnet build "ToDoItems.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoItems.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoItems.API.dll"]