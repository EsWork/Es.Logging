if exist %~dp0artifacts  rd /q /s %~dp0artifacts

call dotnet restore src/Es.Logging
call dotnet restore src/Es.Logging.Console
call dotnet restore src/Es.Logging.Log4
call dotnet restore src/Es.Logging.NLog

call dotnet build -f netstandard1.6 -c Release src/Es.Logging -b artifacts
call dotnet build -f netstandard1.6 -c Release src/Es.Logging.Console -b artifacts
call dotnet build -f netstandard1.6 -c Release src/Es.Logging.Log4 -b artifacts
call dotnet build -f netstandard1.6 -c Release src/Es.Logging.NLog -b artifacts

call dotnet build -f net45 -c Release src/Es.Logging -b artifacts
call dotnet build -f net45 -c Release src/Es.Logging.Console -b artifacts
call dotnet build -f net45 -c Release src/Es.Logging.Log4 -b artifacts
call dotnet build -f net45 -c Release src/Es.Logging.NLog -b artifacts

call dotnet pack --configuration release src/Es.Logging  -o artifacts
call dotnet pack --configuration release src/Es.Logging.Console  -o artifacts
call dotnet pack --configuration release src/Es.Logging.Log4  -o artifacts
call dotnet pack --configuration release src/Es.Logging.NLog  -o artifacts