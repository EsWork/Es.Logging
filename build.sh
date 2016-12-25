#!/bin/bash
set -e

dotnet restore src/Es.Logging
dotnet restore src/Es.Logging.Console
dotnet restore src/Es.Logging.Log4
dotnet restore src/Es.Logging.NLog
dotnet restore src/Es.Microsoft.Log

dotnet build -f netstandard1.3 -c Release src/Es.Logging
dotnet build -f netstandard1.3 -c Release src/Es.Logging.Console
dotnet build -f netstandard1.3 -c Release src/Es.Logging.NLog
dotnet build -f netstandard1.3 -c Release src/Es.Microsoft.Log

dotnet build -f net45 -c Release src/Es.Logging
dotnet build -f net45 -c Release src/Es.Logging.Console
dotnet build -f net45 -c Release src/Es.Logging.Log4
dotnet build -f net45 -c Release src/Es.Logging.NLog
