#!/bin/bash

start_time="2015-03-16"
time1=$(($(date +%s -d "now") - $(date +%s -d "${start_time}")))
# echo $time1                                       #间隔的秒
echo "间隔的天数"
days=$((${time1} / (3600 * 24) - 1600))           #间隔的天数
echo $(((${time1} / (3600 * 24) + 1) / 365))      #间隔的年数
echo $(((${time1} / (3600 * 24) + 1) / 365 * 12)) #间隔的月数

echo "++++++++++++++++++++++++++++++++++++++++"

dateNow=$(date -d 'now')
echo "系统当前时间:"${dateNow}"" # 系统当前时间

minutes=$(date +%H -d "now")

echo $minutes

echo "++++++++++++++++++++++++++++++++++++++++"

version="3.8.$days.$minutes"

starttime=$(date +'%Y-%m-%d %H:%M:%S')

echo ${version}

nowtime=$(date +%Y%m%d)
echo $nowtime

echo $start2015

echo $((nowtime - start2015))

#执行程序
# endtime=$(date +'%Y-%m-%d %H:%M:%S')
# echo ${endtime}

# start_seconds=$(date --date="$starttime" +%s)

# echo ${start_seconds}

# end_seconds=$(date --date="$endtime" +%s)
# echo ${end_seconds}

# echo "本次运行时间： "$((end_seconds - start_seconds))"s"

# echo ${baseDate}

# Write-Host "Generating Build Number"
# $baseDate = [datetime]"01/01/2000"
# $currentDate = $(Get-Date)
# $interval = NEW-TIMESPAN –Start $baseDate –End $currentDate
# $days = $interval.Days-7200
# $minutes=$interval.Minutes
# $version="3.8.$days.$minutes"
# Write-Host "$version"
