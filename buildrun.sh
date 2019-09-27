#!/bin/bash
#export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_ENVIRONMENT=Development
dotnet build
dotnet run --no-build --project ./Api/Volunteer.Api/Volunteer.Api.csproj