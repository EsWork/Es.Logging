set artifacts=%~dp0artifacts

if exist %artifacts%  rd /q /s %artifacts%

set /p ver=<VERSION

dotnet restore src/Es.Logging
dotnet restore src/Es.Logging.Console
dotnet restore src/Es.Logging.Log4
dotnet restore src/Es.Logging.NLog
dotnet restore src/Es.Microsoft.Log

dotnet pack  -c release -p:Ver=%ver% src/Es.Logging -o %artifacts%
dotnet pack  -c release -p:Ver=%ver% src/Es.Logging.Console -o %artifacts%
dotnet pack  -c release -p:Ver=%ver% src/Es.Logging.Log4 -o %artifacts%
dotnet pack  -c release -p:Ver=%ver% src/Es.Logging.NLog -o %artifacts%
dotnet pack  -c release -p:Ver=%ver% src/Es.Logging.Serilog -o %artifacts%
dotnet pack  -c release -p:Ver=%ver% src/Es.Microsoft.Log -o %artifacts%

pause