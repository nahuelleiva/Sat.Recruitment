## Refactoring

* The project has been divided into different layers: Controller, Business Logic, and Data
  * DataService is in charge of persisting and reading information about users
  * DomainManager manages the business logic of the current application
  * UsersController manages the HTTP requests
* Interfaces and implementations were decoupled. Now they are used through dependency injection
* DTO has been added to transfer the information from the API to the Business Logic layer
* AutoMapper has been added to map DTO objects to Business Logic model objects
* Static classes with constant values have been added to handle roles and application error messages
* Serilog has been added to log information from the application

### API
The standard OpenApi has been followed to create the endpoints and to manage the HTTP code responses from requests.

Endpoints:
* POST /Users/add-user

### Gifts
* The gift logic has been included in the AutoMapper mapping logic to be calculated based on the user Role
* This way the logic can be easily handled. It can be included in the User model or configured wherever is needed

### Tests
* Tests have been updated accordingly

### Possible enhancements
This is a basic use case, implementations were not deeply developed to avoid adding unnecessary complexity. Depending on the complexity of the project, growth, or if the scope changes other approaches and tools can be used, for example:

* Using MediatR library: CQRS pattern can be implemented in order to decouple Read operations (queries) from Create/Update/Delete operations (commands)
* Making methods asynchronous
* Adding logs in the Domain layer to persist its own error/debug messages
* Developing and implementing a custom Exception handler
