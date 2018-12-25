# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
#获取到当前文件夹路径



$slnPath = Join-Path $packFolder "../"
$srcPath = Join-Path $slnPath "src"

# List of projects
$projects = (
    "YoYo.Castle.Log4Net",    
    "YoYo.SenparcWX",    
    "YoYo.SenparcWX.MP",    
    "YoYo.SenparcWX.OPEN",    
    "YoYo.SenparcWX.TenPay",    
    "YoYo.SenparcWX.Work",    
    "YoYo.SenparcWX.WxOpen"   
)

# Rebuild solution
Set-Location $slnPath
& dotnet restore

# Copy all nuget packages to the pack folder
foreach ($project in $projects) {
    
    $projectFolder = Join-Path $srcPath $project

    # Create nuget pack
    Set-Location $projectFolder
    Remove-Item -Recurse (Join-Path $projectFolder "bin/Release")
    & dotnet msbuild /p:Configuration=Release /p:SourceLinkCreate=true
    & dotnet msbuild /t:pack /p:Configuration=Release /p:SourceLinkCreate=true

    # Copy nuget package
    $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $project + ".*.nupkg")
    Move-Item $projectPackPath $packFolder

}

# Go back to the pack folder
Set-Location $packFolder