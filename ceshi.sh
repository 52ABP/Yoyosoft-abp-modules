#!/bin/bash
echo "你好，我的Shell练习。。。。哎。以后写脚本也要加注释啊。不然谁看得懂啊。"

# 将 pack.sh 设定为只有该文件拥有者可以执行 :
chmod +x ./build/pack.sh
# 执行脚本
./build/pack.sh

#  chmod +x demo.sh
# ./demo.sh 1 2 3

# 执行脚本 后面传递的参数
# ./test.sh 1 2 3

baseDate =currentDate

echo ${baseDate}

# Write-Host "Generating Build Number"
# $baseDate = [datetime]"01/01/2000"
# $currentDate = $(Get-Date)
# $interval = NEW-TIMESPAN –Start $baseDate –End $currentDate
# $days = $interval.Days-7200
# $minutes=$interval.Minutes
# $version="3.8.$days.$minutes"
# Write-Host "$version"
