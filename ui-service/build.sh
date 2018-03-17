#!/bin/bash
DIR=`dirname $0`
source $DIR/dotnet-include.sh

dotnet restore $DIR/../ui-service/src/ui-service.csproj -s https://api.nuget.org/v3/index.json
dotnet build $DIR/../ui-service/src/ui-service/ui-service.csproj -v normal

CURDIR=`pwd`
cd `dirname $DIR/../ui-service/src/ui-service.csproj`
dotnet publish -o $CURDIR/../ui-service/ui-service/UiServicePkg/Code
cd -
