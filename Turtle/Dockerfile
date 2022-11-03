FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Turtle/Turtle.csproj", "Turtle/"]
RUN dotnet restore "Turtle/Turtle.csproj"
COPY . .
WORKDIR "/src/Turtle"
RUN dotnet build "Turtle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Turtle.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Turtle.dll"]
