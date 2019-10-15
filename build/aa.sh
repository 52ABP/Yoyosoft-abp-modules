#!/bin/bash

dateNow=$(date -d 'now')
echo "系统当前时间:"${dateNow}"" # 系统当前时间
echo "开始构建项目，生成Nuget包的内容"

start_time="2015-03-16"
time1=$(($(date +%s -d "now") - $(date +%s -d "${start_time}")))
days=$((${time1} / (3600 * 24) - 1600)) #间隔的天数
hours=$(date +%H -d "now")
minutes=$(date +%m -d "now")

version="3.8.$days.$hours$minutes"
echo "即将生成的版本号内容:"${version}

# echo "env.JOBNAME===>""${env.JOB_NAME}"
# echo "env.J0B_BASENAME>""${env.JOB_BASENAME}"
# echo "env.BUILDTAG===>""${env.BUILDTAG}"
# echo "env.WORKSPACE==>""${env.WORKSPACE}"
# echo "env.BUILDNUMBER=>""${env.BUILDNUMBER}"
# echo "env.BUILDID==>""${env.BUILDID}"
# echo "env.BUILDDISPLAYNAME==>""${env.BUILDDISPLAYNAME}"
# echo "env.NODENAME二:=>""${env.NODE_NAME}"
# echo "env.NODE_LABELS===>${env.NODELABELS}"
# echo "env.JENKINSHOME>""${env.JENKINSHOME}"
# echo "env.JENKINSURL===>""${env.JENKINS_URL}"
# echo "env.BUILDURL=>""${env.BUILDURL}"
# echo "env.JOB_URL>""${env.JOB_URL}"

#  sh "echo ${env.JOB_NAME}"
# 		sh "echo ${env.JOB_NAME}"
#         sh "echo ${env.JOB_BASENAME}"
#         sh "echo ${env.BUILDTAG}"
#         sh "echo ${env.WORKSPACE}"
#         sh "echo ${env.BUILDNUMBER}"
#         sh "echo ${env.BUILDID}"
#         sh "echo ${env.BUILDDISPLAYNAME}"
#         sh "echo ${env.NODE_NAME}"
#         sh "echo ${env.NODELABELS}"
#         sh "echo ${env.JENKINSHOME}"
#         sh "echo ${env.JENKINS_URL}"
#         sh "echo ${env.BUILDURL}"
#         sh "echo ${env.JOB_URL}"
