# My personal challenge

The aim of this POC (my personal challenge) is to create an application using Service Fabric in a macOS environment.

The application is composed of three services:

* ui-service (stateless) that host an ASP.NET MVC dotnet core web site.
* pl-service (stateless) that host a WCF service and expose a catalog of products.
* pd-service (stateless) that host a WCF service and expose the product details.
* graphql-service (stateless) that host a graphQL entry point or the services.

Let's start.


---
* Setup develop environment

    1. Pull the docker image

        `docker pull microsoft/service-fabric-onebox`

    2. Start the service fabric container image

        `docker run -itd -p 19080-19100:19080-19100 --name sfonebox microsoft/service-fabric-onebox`
        
    3. Logon on the Docker container

        `docker exec -it sfonebox bash`

    4. Run the script to fecth required dependencies

        `./setup.sh`

        please use:  `apt-get install -y --allow-unauthenticated dotnet-runtime-2.0.0` inside the setup script.

        `./run.sh`

    5. At the end of this process if you tpye http://localhost:19080 in your browser you should see Service Fabric explorer

---
 * Setup Service Fabric CLI

    1. Use brew to install the Service Fabric cli using the commands:

        `brew install python3`

        `[sudo] pip3 install sfctl`

    2. After sfctl is installed you have to select the cluster

        `sfctl cluster select --endpoint http://localhost:19080`


---
* Create the first **.NET Core** application

    1. Install Yeoman to generate the template of the application

        `npm install -g yo`

    2. Install the selected generator

        `npm install -g generator-azuresfcsharp`

    3. Create the applicaiton

        `yo azuresfcsharp`

        - select the name of the app (ui-service)
        - select the type of the service (stateless service)
        - select the name of the service (UiService)

    4. Updaload the application using the cli commnand

        `sfctl application upload --path ui-service --show-progress`

    5. Provisioning the service using the cli command

        `sfctl application provision --application-type-build-path ui-service`

    5. Create the instance of the service using the cli command

        `sfctl application create --app-name fabric:/ui-service --app-type ui-serviceType --app-version 1.0.0`
    
    6. You can also use the bash scripts to:

        `./build.sh`

        build the service

        `./install.sh`

        deploy the service in the Service Fabric Cluster

        `./unistall.sh`

        to remove the service from cluster