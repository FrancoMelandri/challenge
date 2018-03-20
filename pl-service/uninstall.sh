#!/bin/bash


sfctl application delete --application-id pl-service
sfctl application unprovision --application-type-name pl-serviceType --application-type-version 1.0.0
sfctl store delete --content-path pl-service