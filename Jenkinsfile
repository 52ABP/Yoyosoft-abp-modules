pipeline {
  agent any
  stages {
    stage('Build') {
      when {
        branch 'master'
      }
      steps {
        sh '''dotnet build --configuration Release
dotnet pack    --no-build   --configuration Release --output nupkgs  

'''
        sh "echo ${env.NUGET_KEY}"
        sh "echo ${env.test}"
        sh "echo ${test}"
        sh 'echo nuget上传'
      }
    }
    stage('Releases') {
      when {
        branch 'master'
        expression {
          ciRelease action: 'check'
        }

      }
      steps {
        sh 'echo nuget上传'
        sh "echo ${env.NUGET_KEY}"
      }
    }
  }
  environment {
    NUGET_KEY = credentials('Yoyosoft-abp-modules-nuget-key')
    test = '123test'
  }
  triggers {
    githubPush()
  }
}