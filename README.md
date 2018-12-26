# NaturaShop

Natura shop is a personal project intended to help women tracking their catalog products sells.

## Motivation

This project has started as a vehicle to practice react and create an integration with .net core, entity framework core. Besides helping my wife tracking her sells :).

## Getting Started

NaturaShop solution is the one used to create all the database interactions using entity framework, but the main project to run the solution is the Web Project which is one created using [create-react-app](https://github.com/facebook/create-react-app).

If one wants to create a new migration to the database named jointable, it should be done typing the following command in the command line while located
in the Persistence project:

```
dotnet ef --startup-project ../NaturaShop migrations add jointable
```

## Prerequisites

dotnet core [sdk](https://dotnet.microsoft.com/download).
node.js -> [node package manager](https://nodejs.org/en/download/).

## Installation

Look for the connection string key in the appsettings.json file in the NaturaShop project -> (MVC).

```
"NaturaShopDatabase": "Initial Catalog=NaturaSale;Integrated Security=SSPI;Persist Security Info=False;Data Source=M3078483\\SQLEXPRESS"
```

Change the source value to the sql server instance on your local machine.
Run npm install in ClientApp folder within Web project.

## Build With

- AspNet.Core
- Entity Framework Core
- React
- Redux
- Npm

## Authors

- **Juan Sebastian Ramirez** - [juanramirezcastaneda](https://github.com/juanramirezcastaneda)
