# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
#获取项目的路径信息


$slnPath = Join-Path $packFolder "../"
$srcPath = Join-Path $slnPath "src"


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
 

# Go back to the pack folder
Set-Location $packFolder


Write-Host "$packFolder"
Write-Host "$slnPath"
Write-Host "$srcPath"