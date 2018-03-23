#!/bin/bash

sfctl application upload --path graphql-service --show-progress
sfctl application provision --application-type-build-path graphql-service
sfctl application create --app-name fabric:/graphql-service --app-type graphql-serviceType --app-version 1.0.0
