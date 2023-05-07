# Vending Machine


A prototype of a virtual vending machine, which provides an API for developers to build a UI.  The features available allow users to insert money, get a list of all products, purchase products and cashout.


The solutions focuses on the backend and has been built using a clean architecture pattern similar to [Jason Taylors clean architecture template](https://github.com/jasontaylordev/CleanArchitecture)


## Tech


* ASP.Net 7
* Node Latest LTS (18+)
* MediatR
* FluentValidation


## Feature completeness


### Missing Features


* The UI has been excluded from this due to time constraints. The UI sill exists for the default ASP.net react template and has not been updated or extended to use the vending machine API's.
* The exception handling middleware is not currently handling domain exceptions eg: ProductUnavailableException


### Limited Implementation


* Sample tests have been written for domain entities, and one command handler
* The repository has been implemented using an in memory list and will be reset after each application start


## Security


A vending machine is intended to be used by anonymous uses so an anonymous session is used maintain the transaction state
* The transaction starts when money is inserted
* The transaction ends when the user cashes out