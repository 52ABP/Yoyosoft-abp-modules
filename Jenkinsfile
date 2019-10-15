#!/usr/bin/env groovy Jenkinsfile
library 'JenkinsSharedLibraries'
pipeline {
   agent {
        node {
            label 'slave-1'
        }
    }

    environment {
    NUGET_KEY = credentials('Yoyosoft-abp-modules-nuget-key')
   
  }
  triggers {
    githubPush() //触发方式为push
  }
  
  stages {
    stage('Build') {
      when {
        branch 'master'
      }
      steps {      
      sh "echo Start Build...."
      sh "dotnet build"        
      sh 'echo Build Complete'
      }
    }
    stage('Release') {
      when {
        branch 'master' // master分支执行
        expression {
          ciRelease action: 'check' // 指 commit中有Release就执行
        }
      }
      steps {
         withEnv(["nugetkey=${env.NUGET_KEY}"]) {
                    sh "chmod +x ./build/pack.sh; ./build/pack.sh"
      }
    }
  }

}
