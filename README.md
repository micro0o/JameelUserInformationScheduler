# JameelUserInformationScheduler

This project is a .NET Core API application that saves user information into a database using a scheduled Hangfire job. Once the user's data is saved, SignalR broadcasts the data and it becomes visible in a front-end table view.

## Features

- **User Information Input**: Users can input their First Name, Last Name, Date of Birth, Phone Number, and Address.
- **Scheduled Saving**: User information is saved to the database after 5 minutes via a scheduled Hangfire job.
- **Real-time Updates**: Once the user information is saved, SignalR broadcasts the data, and it becomes visible in a front-end table view.
- **State Management**: The application uses state management for managing user information.

## Tech Stack

- Front End: Angular
- Back End: .NET Core API
- Job Scheduling: Hangfire
- Real-time Communication: SignalR
- ORM: Entity Framework
## Getting Started

**Prerequisites**

Make sure you have installed all of the following prerequisites on your development machine:

- .NET Core SDK (latest version)
- Node.js and NPM (latest version)
- Angular CLI (latest version)

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

  
