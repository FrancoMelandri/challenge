#!/bin/bash
DIR=`dirname $0`
source $DIR/dotnet-include.sh

dotnet restore $DIR/../graphql-service/src/graphql-service/GraphQLService/GraphQLService.csproj -s https://api.nuget.org/v3/index.json
dotnet build $DIR/../graphql-service/src/graphql-service/GraphQLService/GraphQLService.csproj -v normal

CURDIR=`pwd`
cd `dirname $DIR/../graphql-service/src/graphql-service/GraphQLService/GraphQLService.csproj`
dotnet publish -o $CURDIR/../graphql-service/graphql-service/GraphQLServicePkg/Code
cd -
