#!/bin/bash
set -e

dotnet restore src/LoggingTest
dotnet build src/LoggingTest -f netcoreapp1.1
dotnet test src/LoggingTest/LoggingTest.csproj -f netcoreapp1.1
