# .NET-Auth0-Angular-Template

# DotNet7 with Angular 16 Auth0 Template

This is a template application that demonstrates how to integrate Auth0 authentication in a .NET 7 backend with an Angular 16 frontend. It follows the Clean Architecture structure and provides endpoints to test Auth0 authorization. The Angular frontend is set up to interact with these endpoints and demonstrates how to use bearer tokens for authorization.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Backend](#SetupBackEnd)
- [Frontend](#SetUpFrontEnd)

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

## SetUpBackEnd

1. Clone this repository to your local machine:

   ```sh
   git clone https://github.com/yourusername/dotnet7-angular16-auth0-template.git

2. Run .NET
  Make sure to have Dotnet version 7 installed first
   ```sh
   dotnet run
   or
   (CTRL + F5) On Visual Studio (Purple One)

3. Adding your Auth0 data

   ```sh
   In AppSettings, modify the following from the info of your auth0 project. 
     "Auth0": {
    "Authority": "YOUR_DOMAIN",
    "Audience": "YOUR_AUD",
    "ClientSecret": "CLIENT SECRET FOUND IN Applications/Application/[Applicationame]/Settings/Client-Secret"
   }

## SetUpFrontEnd
1. Run
   ```sh
   npm install

2. Setup SSL Certificate
    I suggest creating your own certificates by running
   ```sh
   openssl req -newkey rsa:2048 -new -nodes -x509 -days 3650 -keyout key.pem -out cert.pem
   
4. Run angular with SSL enabled 
   ```sh
    ng serve --ssl true
