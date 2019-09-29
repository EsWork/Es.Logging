set artifacts=%~dp0artifacts

if exist %artifacts%  rd /q /s %artifacts%

dotnet restore src/Es.Logging
dotnet restore src/Es.Logging.Console
dotnet restore src/Es.Logging.Log4
dotnet restore src/Es.Logging.NLog
dotnet restore src/Es.Microsoft.Log

dotnet pack  -c release  src/Es.Logging -o %artifacts%
dotnet pack  -c release  src/Es.Logging.Console -o %artifacts%
dotnet pack  -c release  src/Es.Logging.Log4 -o %artifacts%
dotnet pack  -c release  src/Es.Logging.NLog -o %artifacts%
dotnet pack  -c release  src/Es.Logging.Serilog -o %artifacts%
dotnet pack  -c release  src/Es.Microsoft.Log -o %artifacts%

pause