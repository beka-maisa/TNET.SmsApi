# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official ASP.NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmsApi/SmsApi.csproj", "SmsApi/"]
RUN dotnet restore "SmsApi/SmsApi.csproj"
COPY . .
WORKDIR "/src/SmsApi"
RUN dotnet build "SmsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmsApi.dll"]