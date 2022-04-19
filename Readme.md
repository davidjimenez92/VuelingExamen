# Vueling Exam

## Statement
As a imperial programmer your receive the order of implement a new web service that allows to register any rebeld identification. 
The empire has conquered all universe, but it still remains some group of hidden rebelds. Dark forces, soldiers for the empire, distributed over all know galaxies and solar systems forces empire's citizens to be identified. They need you to develop a distributed service that would be able to be called from any location over the universe. 
As interoperability is a must, you decide to use an old fashioned and very extended technology called wcf web services. 
The web service has to expose a method that accept a list of strings 
with the name of the rebeld and name of the planet, and response true if its register goes fine. The regiter has to be done to file with a datetime 
with the string "rebeld (name) on (planet) at (datetime)". 

Separate responsabilities in separate layers: distributed services, application, repositories and domain. Implement error logging and manage 
exceptions in every layer. Implement unit test for any layer, too. Take care of proper naming convections and SOLID principles. 

You can use any Dependency Injection, Unit Testing, Mocking frameworks or any other that you consider necessary. 
## Implementation
1. [VuelingWebServices](https://github.com/davidjimenez92/VuelingExamen/tree/master/VuelingExamen.Distributed.WebServices) is a wcf service from which the solution is executed. In this layer we load the autofac modules defined in lower layers and perform the dependency injection.
2. [Services](https://github.com/davidjimenez92/VuelingExamen/tree/master/VuelingExamen.Application.Services) a library in which an autofac module is created to inject the lower layer so that the upper layer has access to it. In the contracts folder we include interface segregation by splitting the interface [IVuelingService](https://github.com/davidjimenez92/VuelingExamen/blob/master/VuelingExamen.Application.Services/Contracts/IVuelingService.cs) into other interfaces([IAdd](https://github.com/davidjimenez92/VuelingExamen/blob/master/VuelingExamen.Application.Services/Contracts/IAdd.cs))<br>
The function of this layer is to perform all operations related to business rules and send them to the lower layer.
3. [Entities](https://github.com/davidjimenez92/VuelingExamen/tree/master/VuelingExamen.Domain.Entities)  This layer contains the entities of our application.
4. [Repositories](https://github.com/davidjimenez92/VuelingExamen/tree/master/VuelingExamen.Infrastructure.repositories) operations related to data persistence shall be performed in this layer. In this case, in order to implement new file types, we create the repository from the factory pattern to which a file type is passed, for the moment only the txt file will be available.
5. [CrossCutting](https://github.com/davidjimenez92/VuelingExamen/tree/master/VuelingExamen.CrossCutting.ProjectConfiguration) this layer is created to strongly type the configuration variables of the app.config to encapsulate all configuration properties.
6. [Client](https://github.com/davidjimenez92/VuelingExamen/tree/master/VuelingExamen.Client.HttpClient) this project is created to be able to upload that web service to azure devops using artifacts.
 
## Architecture Diagram
![UML DIAGRAM](https://github.com/davidjimenez92/VuelingExamen/blob/master/umlexam.png)
## Technology Stack
`Visual Studio 2022 Comunity Edition | C# | .NET Framework 4.8`
## Libraries
### Distributed Web Services
1. `Autofac 6.0.0`
2. `Autofac.Wcf 6.0.0` 
3. `Autofac.log4net 6.0.1`
4. `log4net 2.0.14`
5. `CustomValidationsIntegrationWCF 1.0.0`
6. `EnterpriseLibrary.Common 6.0.1304`
7. `EnterpriseLibrary.Validation 6.0.1304`
8. `AutoMapper 10.1.1`
### Application Services
1. `Autofac 6.0.0`
2. `log4net 2.0.14`
3. `AutoMapper 10.1.1`

## Azure Devops implementation.
Before starting to develop, a [YAML](https://github.com/davidjimenez92/VuelingExamen/blob/master/azure-pipelines.yml) file has been created that takes us to an azure devops pipeline where every time the develop branch is used we check that the project compiles.

![pipeline](https://github.com/davidjimenez92/VuelingExamen/blob/master/pipeline.png)

When the project is ready, the client is uploaded to artifacts.

![arfifacts-web](https://github.com/davidjimenez92/VuelingExamen/blob/master/artifact.png)
## Author
[David Jiménez Miguel](https://github.com/davidjimenez92)
