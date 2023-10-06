FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
#EXPOSE 5287

#ENV ASPNETCORE_URLS=http://+:5287

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TrainTimes/TrainTimes.csproj", "TrainTimes/"]
COPY ["TrainTimes/nuget.config", "TrainTimes/"]
COPY ["TrainTimes.sln", "TrainTimes/"]
RUN dotnet restore "TrainTimes/TrainTimes.csproj"
COPY . .
WORKDIR "/src/TrainTimes"
RUN dotnet build "TrainTimes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrainTimes.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrainTimes.dll"]
