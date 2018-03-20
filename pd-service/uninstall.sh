#!/bin/bash


sfctl application delete --application-id pd-service
sfctl application unprovision --application-type-name pd-serviceType --application-type-version 1.0.0
sfctl store delete --content-path pd-service