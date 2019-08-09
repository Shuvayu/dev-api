FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DEV/DEV.API.csproj", "DEV/"]
RUN dotnet restore "DEV/DEV.API.csproj"
COPY . .
WORKDIR "/src/DEV"
RUN dotnet build "DEV.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DEV.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DEV.API.dll"]