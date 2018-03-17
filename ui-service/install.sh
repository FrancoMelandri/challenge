#!/bin/bash

sfctl application upload --path ui-service --show-progress
sfctl application provision --application-type-build-path ui-service
sfctl application create --app-name fabric:/ui-service --app-type ui-serviceType --app-version 1.0.0
