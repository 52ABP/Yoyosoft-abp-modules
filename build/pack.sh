#!/bin/bash
set -e
# set命令的-e参数，linux自带的说明如下：
# "Exit immediately if a simple command exits with a non-zero status."
#也就是说，在"set -e"之后出现的代码，一旦出现了返回值非零，整个脚本就会立即退出。有的人喜欢使用这个参数，是出于保证代码安全性的考虑。但有的时候，这种美好的初衷，也会导致严重的问题。

echo "我这里是PACK，用于打包nuget包然后进行发布的地方。"

dateNow=$(date -d 'now')
echo "系统当前时间:"${dateNow}"" # 系统当前时间

start_time="2015-03-16"
time1=$(($(date +%s -d "now") - $(date +%s -d "${start_time}")))
days=$((${time1} / (3600 * 24) - 1600)) #间隔的天数
hours=$(date +%H -d "now")
minutes=$(date +%m -d "now")
version="3.8.$days.$hours$minutes"

echo "即将生成的版本号内容:"${version}

# 生成一个文件夹如： publish/nupkgs/20191015
publishdir=publish/nupkgs/$(date +%Y%m%d)

mkdir $publishdir -p # 生成文件夹的执行命令

# 转换相对路径为绝对路径

publishdir=$(
    cd ${publishdir}
    pwd
)
echo "开始构建项目，生成Nuget包的内容"
dotnet pack --no-build --configuration Release --output ${publishdir} -p:Version=${version}
echo "开始发布到nuget.org"

dotnet nuget push *.nupkg -k ${nugetkey} -s https://api.nuget.org/v3/index.json

echo "项目构建完毕"
# 清理
echo "开始清理旧版本的Nuget包"

if [[ $publishdir != "/" ]]; then
    rm -rf ${publishdir}
fi
