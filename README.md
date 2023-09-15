# JameelUserInformationScheduler

This project is a .NET Core API application that saves user information into a database using a scheduled Hangfire job. Once the user's data is saved, SignalR broadcasts the data and it becomes visible in a front-end table view.

## Features
- **User Information Input**: Users can input their First Name, Last Name, Date of Birth, Phone Number, and Address.
- **Scheduled Saving**: User information is saved to the database after 5 minutes via a scheduled Hangfire job.
- **Real-time Updates**: Once the user information is saved, SignalR broadcasts the data, and it becomes visible in a front-end table view.
- **State Management**: The application uses state management for managing user information.
- **Server Status**: The application shows an indicator for the server status whether it is online or offline.
- **Reactive Form**: The application uses the Angular's reactive form to handle the form inputs and validate it.

## Tech Stack
- Front End: Angular (16.2.0)
- Back End: .NET Core API (.Net 6.0)
- Job Scheduling: Hangfire (Hangfire.AspNetCore 1.8.5)
- Real-time Communication: SignalR
- ORM: Entity Framework (7.0.11)

## Getting Started
**Prerequisites**

Make sure you have installed all of the following prerequisites on your development machine:

- .NET Core SDK (6.0)
- Angular CLI: 16.2.2
- Node: 18.17.1
- Package Manager: npm 9.6.7

**Installing**

- Clone the repo to your local machine: `git clone https://github.com/micro0o/JameelUserInformationScheduler.git`
- Navigate to the project directory: `cd JameelUserInformationScheduler`
- Install the ASP.NET Core dependencies: `dotnet restore`
- Execute the following query to create the Hangfire DB in SQL Server: `CREATE DATABASE Jameel_Scheduler_Hangfire`
- Build the solution: `dotnet build`
- Navigate to the API directory: `cd .\JUIS.Presentation\` 
- Run the API: `dotnet run`
- In a new terminal, navigate to the Angular app directory and install Angular dependencies: `cd .\JUIS.Presentation\ClientApp && npm install `
- Run the Angular app: `ng serve`

  
