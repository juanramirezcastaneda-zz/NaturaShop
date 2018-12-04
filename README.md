# NaturaShop

Natura shop is a personal project intended to help women tracking their catalog products sells.

## Getting Started

NaturaShop solution is the one used to create all the database interactions using entity framework, but the main project to run the solution is the Web Project which is one created using [create-react-app](https://github.com/facebook/create-react-app).

If one wants to create a new migration to the database named jointable, it should be done like the following:

```
dotnet ef --startup-project ../NaturaShop migrations add jointable
```

## Prerequisites

dotnet core [sdk](https://dotnet.microsoft.com/download).
node.js -> [node package manager](https://nodejs.org/en/download/).

## Installation

Run npm install in ClientApp folder within Web Project

## Build With

- AspNet.Core
- Entity Framework Core
- React
- Redux
- Npm

## Authors

- **Juan Sebastian Ramirez** - [juanramirezcastaneda](https://github.com/juanramirezcastaneda)
