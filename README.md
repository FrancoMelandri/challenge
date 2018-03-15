# My personal challenge

---
* Setup develop environment (https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-get-started-mac)

    1. Pull the docker image

        `docker pull microsoft/service-fabric-onebox`
    2. Start the service fabric container image

        `docker run -itd -p 19080:19080 --name sfonebox microsoft/service-fabric-onebox`
    3. Logon on the Docker container

        `docker exec -it sfonebox bash`

    4. Run the script to fecth required dependencies

        `./setup.sh`

        please use:  `apt-get install -y --allow-unauthenticated dotnet-runtime-2.0.0` inside the setup script.

        `./run.sh`

    5. At the end of this process if you tpye http://localhost:19080 in you r browse you should see Service Fabric explorer

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

        - select the name of the app
        - select the type of the service
        - select the name of the service