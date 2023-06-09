# Vending Machine

A prototype of a virtual vending machine, which provides an API for developers to build a UI.  The features available allow users to insert money, get a list of all products, purchase products and cash-out.

The solutions focuses on the backend and has been built using a clean architecture pattern similar to [Jason Taylors clean architecture template](https://github.com/jasontaylordev/CleanArchitecture)

## Tech

* ASP.Net 7
* Node Latest LTS (18+)
* MediatR
* FluentValidation

## Running the App
* Navigate to the WebUI directory in a CLI tool
* run dotnet run

OR

* Open in visual studio or rider
* Set WebUI as startup project run app

Then

* View swagger docs https://localhost:7067/swagger/index.html
* Or import the postman collection from - VendingMachine.postman_collection.json

## Feature completeness

### Limited Implementation

* Sample tests have been written for domain entities, and one command handler
* The repository has been implemented using an in memory list and will be reset after each application start

### Missing Features

* The UI has been excluded from this due to time constraints. The UI sill exists for the default ASP.net react template and has not been updated or extended to use the vending machine API's.
* The exception handling middleware is not currently handling domain exceptions eg: ProductUnavailableException
* Logging and Monitoring - Exception middle ware is currently catching some exception but no logging as been added, in either the middle ware or information logging for application events.

## Security

A vending machine is intended to be used by anonymous uses so an anonymous session is used maintain the transaction state
* The transaction starts when money is inserted
* The transaction ends when the user cashes out

## Scalability 

* To scale the app the in memory data store needs to be, replaced/re-implemented to use a distributed and durable data store. eg: Database Redis 