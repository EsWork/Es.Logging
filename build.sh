#!/bin/bash
set -e

sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update -y
sudo apt-get install dotnet-dev-1.0.0-preview2.1-003177 -y

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
