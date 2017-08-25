set artifacts=%~dp0artifacts

if exist %artifacts%  rd /q /s %artifacts%

call dotnet restore src/Es.Logging
call dotnet restore src/Es.Logging.Console
call dotnet restore src/Es.Logging.Log4
call dotnet restore src/Es.Logging.NLog
call dotnet restore src/Es.Microsoft.Log

call dotnet build src/Es.Logging -f netstandard1.3 -c Release -o %artifacts%\netstandard1.3
call dotnet build src/Es.Logging -f netstandard2.0 -c Release -o %artifacts%\netstandard2.0
call dotnet build src/Es.Logging.Console -f netstandard1.3 -c Release -o %artifacts%\netstandard1.3
call dotnet build src/Es.Logging.Console -f netstandard2.0 -c Release -o %artifacts%\netstandard2.0
call dotnet build src/Es.Logging.NLog -f netstandard1.3 -c Release -o %artifacts%\netstandard1.3
call dotnet build src/Es.Logging.NLog -f netstandard2.0 -c Release -o %artifacts%\netstandard2.0
call dotnet build src/Es.Logging.Log4 -f netstandard1.3 -c Release -o %artifacts%\netstandard1.3
call dotnet build src/Es.Logging.Log4 -f netstandard2.0 -c Release -o %artifacts%\netstandard2.0
call dotnet build src/Es.Logging.Serilog -f netstandard1.3 -c Release -o %artifacts%\netstandard1.3
call dotnet build src/Es.Logging.Serilog -f netstandard2.0 -c Release -o %artifacts%\netstandard2.0
call dotnet build src/Es.Microsoft.Log -f netstandard1.3 -c Release -o %artifacts%\netstandard1.3
call dotnet build src/Es.Microsoft.Log -f netstandard2.0 -c Release -o %artifacts%\netstandard2.0

call dotnet build src/Es.Logging -f net45 -c Release -o %artifacts%\net45
call dotnet build src/Es.Logging.Console -f net45 -c Release -o %artifacts%\net45
call dotnet build src/Es.Logging.NLog -f net45 -c Release -o %artifacts%\net45
call dotnet build src/Es.Logging.Log4 -f net45 -c Release -o %artifacts%\net45

call dotnet pack src/Es.Logging -c release -o %artifacts%
call dotnet pack src/Es.Logging.Console -c release -o %artifacts%
call dotnet pack src/Es.Logging.Log4 -c release -o %artifacts%
call dotnet pack src/Es.Logging.NLog -c release -o %artifacts%
call dotnet pack src/Es.Logging.Serilog -c release -o %artifacts%
call dotnet pack src/Es.Microsoft.Log -c release -o %artifacts%
