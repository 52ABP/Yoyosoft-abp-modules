pipeline {
  agent any
  stages {
    stage('Build') {
      when {
        branch 'master'
      }
      steps {
      sh 'echo "begin build..."'
      sh 'dotnet build --configuration Release' //编译项目
      sh 'echo "begin success..."'      	 
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
        sh 'echo "begin build..."
echo "Nuget 上传包"
echo "${env.NUGET_KEY}"
echo "build success"'
        sh "echo ${env.NUGET_KEY}"
      }
    }
  }
  environment {
    NUGET_KEY = credentials('Yoyosoft-abp-modules-nuget-key')
   
  }
  triggers {
    githubPush() //触发方式为push
  }
}