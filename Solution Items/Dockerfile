#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmsApi/SmsApi.csproj", "SmsApi/"]
RUN dotnet restore "./SmsApi/SmsApi.csproj"
COPY . .
WORKDIR "/src/SmsApi"
RUN dotnet build "./Sms