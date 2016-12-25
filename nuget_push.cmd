set /p ver=<VERSION
set sourceUrl=-Source https://www.nuget.org/api/v2/package

nuget push artifacts/Es.Logging.%ver%.nupkg %sourceUrl%
nuget push artifacts/Es.Logging.Console.%ver%.nupkg %sourceUrl%
nuget push artifacts/Es.Logging.NLog.%ver%.nupkg %sourceUrl%
nuget push artifacts/Es.Logging.Log4.%ver%.nupkg %sourceUrl%
nuget push artifacts/Es.Microsoft.Logging.%ver%.nupkg %sourceUrl%