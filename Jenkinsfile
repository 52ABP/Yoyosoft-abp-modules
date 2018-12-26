#!/usr/bin/env groovy Jenkinsfile
library 'JenkinsSharedLibraries'
pipeline {
    agent any

    triggers {
      githubPush()
    }
	
	stages {
		stage('Build') {
			when{branch "master"}
			steps {
				sh 'dotnet build'
			}
		}
		stage('Release') {
			when {
				branch "master"
				expression { ciRelease action: 'check' }
			}
			steps {
				sh "echo nuget上传"
			}
		}
    }
}
