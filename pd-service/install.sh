#!/bin/bash

sfctl application upload --path pd-service --show-progress
sfctl application provision --application-type-build-path pd-service
sfctl application create --app-name fabric:/pd-service --app-type pd-serviceType --app-version 1.0.0
