#!/bin/bash
DIR=`dirname $0`
source $DIR/dotnet-include.sh

dotnet restore $DIR/../pd-service/src/pd-service/PdService/PdService.csproj -s https://api.nuget.org/v3/index.json
dotnet build $DIR/../pd-service/src/pd-service/PdService/PdService.csproj -v normal

CURDIR=`pwd`
cd `dirname $DIR/../pd-service/src/pd-service/PdService/PdService.csproj`
dotnet publish -o $CURDIR/../pd-service/pd-service/PdServicePkg/Code
cd -
