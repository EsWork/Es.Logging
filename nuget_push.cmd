set /p ver=<VERSION
set sourceUrl=-s https://www.nuget.org/api/v2/package

dotnet nuget push artifacts/Es.Logging.%ver%.nupkg %sourceUrl%
dotnet nuget push artifacts/Es.Logging.Console.%ver%.nupkg %sourceUrl%
dotnet nuget push artifacts/Es.Logging.NLog.%ver%.nupkg %sourceUrl%
dotnet nuget push artifacts/Es.Logging.Log4.%ver%.nupkg %sourceUrl%
dotnet nuget push artifacts/Es.Microsoft.Log.%ver%.nupkg %sourceUrl%
