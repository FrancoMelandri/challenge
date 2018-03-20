#!/bin/bash

sfctl application upload --path pl-service --show-progress
sfctl application provision --application-type-build-path pl-service
sfctl application create --app-name fabric:/pl-service --app-type pl-serviceType --app-version 1.0.0
