# WAD_CW_12907


"This application was developed for Web
Application module, as coursework portfolio project @ WIUT by student ID: 00012907" 


**Prerequisites
*************************Backend***********************
.NET Core Web API (https://dotnet.microsoft.com/en-us/download)
Entity Framework Core (https://learn.microsoft.com/en-us/ef/core/)
SQL Server (or compatible database)
Frontend:
Node.js and npm (or yarn) (https://nodejs.org/en)
Angular Framework (https://angular.io/)
Technologies Used
Backend:
C# for server-side development
ASP.NET Core MVC for web API development
Repository Pattern for data access abstraction 
Entity Framework Core for data access and database interaction
****************Frontend******************************
TypeScript for development
Angular Framework for building the single-page application
Communication with the backend API using Angular HttpClient
Database Design
The database utilizes two tables linked with foreign keys:

Recipes: Stores recipe details (name, ingredients, instructions, etc.)
Categories: Stores recipe categories (e.g., breakfast, dessert)
A recipe can belong to one category using a foreign key relationship.

Features
CRUD (Create, Read, Update, Delete) operations for recipes:
Add new recipes
View existing recipes
Edit recipe details
Delete recipes


**Before running the RecipeBook Web App, ensure you have the following prerequisites installed:
**
Node.js: Install Node.js from nodejs.org according to your operating system.

Angular CLI: Install Angular CLI globally by running the following command in your terminal
npm install -g @angular/cli

Database Setup: Ensure you have a database system installed and running. The RecipeBook Web App requires a database with support for foreign keys. PostgreSQL or MySQL are recommended options.

Running the Application
To run the RecipeBook Web App:

Clone the repository: git clone <repository-url>
Navigate to the project directory: cd recipe-book
Install dependencies: npm install
Start the Angular development server: ng serve
Access the application in your browser at http://localhost:4200
