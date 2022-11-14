FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EFExercises/EFExercises.csproj", "EFExercises/"]
RUN dotnet restore "EFExercises/EFExercises.csproj"
COPY . .
WORKDIR "/src/EFExercises"
RUN dotnet build "EFExercises.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFExercises.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFExercises.dll"]
