#!/bin/bash
DIR=`dirname $0`
source $DIR/dotnet-include.sh

dotnet restore $DIR/../pl-service/src/pl-service/PlService/PlService.csproj -s https://api.nuget.org/v3/index.json
dotnet build $DIR/../pl-service/src/pl-service/PlService/PlService.csproj -v normal

CURDIR=`pwd`
cd `dirname $DIR/../pl-service/src/pl-service/PlService/PlService.csproj`
dotnet publish -o $CURDIR/../pl-service/pl-service/PlServicePkg/Code
cd -
