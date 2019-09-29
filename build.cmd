set artifacts=%~dp0artifacts

if exist %artifacts%  rd /q /s %artifacts%

call dotnet restore src/Es.Logging
call dotnet restore src/Es.Logging.Console
call dotnet restore src/Es.Logging.Log4
call dotnet restore src/Es.Logging.NLog
call dotnet restore src/Es.Microsoft.Log

call dotnet pack src/Es.Logging -c release -o %artifacts%
call dotnet pack src/Es.Logging.Console -c release -o %artifacts%
call dotnet pack src/Es.Logging.Log4 -c release -o %artifacts%
call dotnet pack src/Es.Logging.NLog -c release -o %artifacts%
call dotnet pack src/Es.Logging.Serilog -c release -o %artifacts%
call dotnet pack src/Es.Microsoft.Log -c release -o %artifacts%

pause