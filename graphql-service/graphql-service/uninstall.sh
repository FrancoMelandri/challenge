#!/bin/bash


sfctl application delete --application-id graphql-service
sfctl application unprovision --application-type-name graphql-serviceType --application-type-version 1.0.0
sfctl store delete --content-path graphql-service