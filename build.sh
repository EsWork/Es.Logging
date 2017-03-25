#!/usr/bin/env bash
set -e
basepath=$(cd `dirname $0`; pwd)
artifacts=${basepath}/artifacts

if [[ -d ${artifacts} ]]; then
   rm -rf ${artifacts}
fi

mkdir -p ${artifacts}

dotnet restore src/Es.Logging
dotnet restore src/Es.Logging.Console
dotnet restore src/Es.Logging.Log4
dotnet restore src/Es.Logging.NLog
dotnet restore src/Es.Microsoft.Log

dotnet build src/Es.Logging -f netstandard1.3 -c Release -o ${artifacts}/netstandard1.3
dotnet build src/Es.Logging.Console -f netstandard1.3 -c Release -o ${artifacts}/netstandard1.3
dotnet build src/Es.Logging.NLog -f netstandard1.3 -c Release -o ${artifacts}/netstandard1.3
dotnet build src/Es.Logging.Log4 -f netstandard1.3 -c Release -o ${artifacts}/netstandard1.3
dotnet build src/Es.Microsoft.Log -f netstandard1.3 -c Release -o ${artifacts}/netstandard1.3

dotnet build src/Es.Logging -f net45 -c Release -o ${artifacts}/net45
dotnet build src/Es.Logging.Console -f net45 -c Release -o ${artifacts}/net45
dotnet build src/Es.Logging.NLog -f net45 -c Release -o ${artifacts}/net45
dotnet build src/Es.Logging.Log4 -f net45 -c Release -o ${artifacts}/net45

dotnet pack src/Es.Logging -c release -o ${artifacts}
dotnet pack src/Es.Logging.Console -c release -o ${artifacts}
dotnet pack src/Es.Logging.Log4 -c release -o ${artifacts}
dotnet pack src/Es.Logging.NLog -c release -o ${artifacts}
dotnet pack src/Es.Microsoft.Log -c release -o ${artifacts}

