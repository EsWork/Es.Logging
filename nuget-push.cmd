set ng="%~dp0Tools\NuGet\NuGet.exe"
%ng% push %~dp0artifacts\Es.Logging.0.0.2.nupkg
%ng% push %~dp0artifacts\Es.Logging.Console.0.0.2.nupkg
%ng% push %~dp0artifacts\Es.Logging.Log4.0.0.2.nupkg
%ng% push %~dp0artifacts\Es.Logging.NLog.0.0.2.nupkg