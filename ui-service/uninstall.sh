#!/bin/bash


sfctl application delete --application-id ui-service --force-remove 1
sfctl application unprovision --application-type-name ui-serviceType --application-type-version 1.0.0
sfctl store delete --content-path ui-service