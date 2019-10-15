pipeline {
  agent any
  stages {
    stage('Build') {
      when {
        branch 'master'
      }
      steps {
        sh 'echo " Start Build...."'
        sh "echo ${env.JOB_NAME}"
		sh "echo ${env.JOB_NAME}"
        sh "echo ${env.JOB_BASENAME}"
        sh "echo ${env.BUILDTAG}"
        sh "echo ${env.WORKSPACE}"
        sh "echo ${env.BUILDNUMBER}"
        sh "echo ${env.BUILDID}"
        sh "echo ${env.BUILDDISPLAYNAME}"
        sh "echo ${env.NODE_NAME}"
        sh "echo ${env.NODELABELS}"
        sh "echo ${env.JENKINSHOME}"
        sh "echo ${env.JENKINS_URL}"
        sh "echo ${env.BUILDURL}"
        sh "echo ${env.JOB_URL}"
        sh 'dotnet build'
        sh 'echo "Build Complete"'


    

 


      }
    }
       stage('Release') {
      when {
        branch 'master'
          expression {
          ciRelease action: 'check'  
        }
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