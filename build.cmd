call dotnet restore src/Es.Logging
call dotnet restore src/Es.Logging.Console
call dotnet restore src/Es.Logging.Log4
call dotnet restore src/Es.Logging.NLog


call dotnet pack --configuration release src/Es.Logging  -o artifacts
call dotnet pack --configuration release src/Es.Logging.Console  -o artifacts
call dotnet pack --configuration release src/Es.Logging.Log4  -o artifacts
call dotnet pack --configuration release src/Es.Logging.NLog  -o artifacts