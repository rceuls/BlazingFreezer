# Blazing Freezer

Blazing Freezer is a proof of concept, using the following technologies:

* .NET Core
* GRPC
* Blazor
* MongoDB

The basic concept is that of a freezer management app - as we have multiple freezers at home we need a way to manage our inventory.

## Architecture

### BlazingFreezer.API

Contains the backend code. This is a basic ASP.NET project with GRPC enabled.

### BlazingFreezer.Web

Contains the frontend code; written using blazor (wasm).

### BlazingFreezer.Shared

This contains shared code, the most important being the `.proto` files

## Developing/running the project

You need .NET Core SDK (3.1.x) for compiling and running the project. In the future deploys will be simplified (probably using Docker), but for now you need to run each project separately (via `dotnet watch run`) in it's own subfolder. You also need a mongodb database; a `docker-compose.yml` with some data is provided in the root folder of the project.