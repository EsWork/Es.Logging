properties {
  $tfver ="v4.5";
  $config = "Release"
  $base_version = "0.0.3" 
  $base_dir = Split-Path $psake.build_script_file 

  $src_dir = "$base_dir"
  $tools_dir = "$base_dir\tools"
  $artifacts_dir = "$base_dir\artifacts"
  $bin_dir = "$artifacts_dir\bin\"
  $prjo_files = @("$base_dir\Src\Es.Logging\Es.Logging.csproj",`
                "$base_dir\Src\Es.Logging.Console\Es.Logging.Console.csproj",`
                "$base_dir\Src\Es.Logging.Log4\Es.Logging.Log4.csproj",`
                "$base_dir\Src\Es.Logging.NLog\Es.Logging.NLog.csproj")

  $nuspec_file = "$base_dir\fasthttprequest.nuspec"

  $sn_file = "$base_dir\src\Es.Logging.sln"
  $nuget_tool = "$tools_dir\nuget\nuget.exe"
  $zip_tool = "$tools_dir\7Zip\7za.exe"
}

function RemoveDirectory($path) {
  if(Test-Path $path) {
    rd -rec -force $path | out-null
  }
}

Framework('4.0')

Task default -depends Compile

Task Compile -depends Clean { 

 Exec { &$nuget_tool restore $sn_file}

  mkdir -path $bin_dir | out-null
  Foreach($file in $prjo_files){
     Write-Host "Building $file for .NET $tfver" -ForegroundColor Green
     Exec { msbuild "$file" /t:Rebuild /p:Configuration=$config /p:TargetFrameworkVersion=$tfver /v:quiet /p:OutDir=$bin_dir /p:Platform=AnyCPU } 
  }

  $zip_dir = "$artifacts_dir\ziptemp"
    
  RemoveDirectory $zip_dir

  mkdir -path $zip_dir | out-null

  cp "$bin_dir\*.dll" "$zip_dir"
  cp "$bin_dir\*.xml" "$zip_dir"
  $short_version = $base_version
  if($base_version.EndsWith(".0")) {
    $short_version = $base_version.SubString(0, $base_version.Length - 2)
  }

  Exec { &$zip_tool a "$artifacts_dir\Es.Logging-$short_version.zip" "$zip_dir\*" }

  rd $zip_dir -rec -force | out-null
}

Task Clean { 
    RemoveDirectory $artifacts_dir
}

