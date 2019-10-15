library 'JenkinsSharedLibraries'
pipeline {
  agent any
  stages {
    stage('Build') {
      when {
        branch 'master'
      }
      steps {
        sh 'echo " Start Build...."'       
        sh 'dotnet build'
        sh 'echo "Build Complete"'
      }
    }
      stage('Release') {
      when {
        branch "master"
        expression { ciRelease action: 'check' }
      }
      steps {
          withEnv(["nugetkey=${env.NUGET_KEY}"]) {
                    sh "chmod +x ./build/pack.sh; ./build/pack.sh"
      }
      }
    }
  }
  environment {
        NUGET_KEY     = credentials('Yoyosoft-abp-modules-nuget-key')
    }
    triggers {
      githubPush()
    }
}
