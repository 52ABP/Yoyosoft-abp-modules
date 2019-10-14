# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
#获取项目路径信息


Write-Host "$packFolder"

Write-Host "Generating Build Number"
$baseDate = [datetime]"01/01/2000"
$currentDate = $(Get-Date)
$interval = NEW-TIMESPAN –Start $baseDate –End $currentDate
$days = $interval.Days-7200
$minutes=$interval.Minutes
$version="3.8.$days.$minutes"
Write-Host "$version"


$slnPath = Join-Path $packFolder "../"
$srcPath = Join-Path $slnPath "src"

Write-Host "$slnPath"

Write-Host "$srcPath"

# List of projects
$projects = (
    "Yoyo.Abp.Alipay",    
    "Yoyo.Abp.Aliyun.Vod",    
    "Yoyo.Abp.Wechat",    
    "Yoyo.Abp.Wechat.MP",    
    "Yoyo.Abp.Wechat.Open",    
    "Yoyo.Abp.Wechat.TenPay",    
    "Yoyo.Abp.Wechat.Work",
    "Yoyo.Abp.Wechat.WxOpen"   
)

# Rebuild solution
Set-Location $slnPath
& dotnet restore
& dotnet build


# Copy all nuget packages to the pack folder
foreach ($project in $projects) {
    
    $projectFolder = Join-Path $srcPath $project

    # Create nuget pack
    Set-Location $projectFolder
    Remove-Item -Recurse (Join-Path $projectFolder "bin/Release")
    & dotnet msbuild /p:Configuration=Release /p:SourceLinkCreate=true    
    & dotnet msbuild /t:pack /p:Configuration=Release /p:SourceLinkCreate=true /P:Version=$version

    # Copy nuget package
    $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $project + ".*.nupkg")
    Move-Item $projectPackPath $packFolder

}

# Go back to the pack folder
Set-Location $packFolder