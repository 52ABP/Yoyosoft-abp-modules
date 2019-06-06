# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
#获取项目路径信息
 
$anem= Dir -name
   
Write-Host "$anem "
Write-Host "$packFolder "




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

# Copy all nuget packages to the pack folder
foreach ($project in $projects) {
    
    $projectFolder = Join-Path $srcPath $project

  

    # Create nuget pack
   # Set-Location $projectFolder
  
  
 
  

 # $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $project + ".*.nupkg")


}
 