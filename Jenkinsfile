pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'echo " Start Build...."'
        sh 'dotnet build'
        sh 'echo "Build Complete"'
      }
    }
  }
  environment {
    nugetkey = '1'
  }
}