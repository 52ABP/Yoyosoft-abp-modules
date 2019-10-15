#!/bin/bash
set -e
export DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0

# 编译项目
echo "begin build..."

# 指定通过Release
dotnet build --configuration Release

# 项目编译成功
echo "build success"




# 项目Releases

echo "begin build..."
echo "Nuget 上传包"

echo ${env.NUGET_KEY}
echo "build success"




# 打包nuget 包，已经包含了 build，所以加上 --no-build 
# --version-suffix "ci-1234" 是增加后缀 ，如：Yoyo.Abp.Aliyun.Vod.1.0.0-ci-1234
#dotnet pack    --no-build   --configuration Release --output nupkgs  

your_name="qinjx"
echo $baseDate
echo ${your_name}