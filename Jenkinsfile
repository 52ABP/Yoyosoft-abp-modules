#!/usr/bin/env groovy Jenkinsfile
library 'JenkinsSharedLibraries'
pipeline {
    agent any

    triggers {
      githubPush()
    }
	
	environment {
		// # 获取配置在Jenkins内部的nuget key文件
        NUGET_KEY     = credentials('Yoyosoft-abp-modules-nuget-key')
    }
	
	stages {
		stage('Build') {
			when{branch "master"}
			steps {
				sh 'dotnet build'
				sh "echo ${env.NUGET_KEY}"
			}
		}

		// 貌似每一触发。。。
		stage('Releases') {
			when {
				branch "master"
				expression { ciRelease action: 'check' }
			}
			steps {
				sh "echo nuget上传"
				sh "echo ${env.NUGET_KEY}"
			}
		}
    }
}
