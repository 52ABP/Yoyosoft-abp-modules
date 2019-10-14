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