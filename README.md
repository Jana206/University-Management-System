# University Management System

A full-stack university management web application built with ASP.NET Core MVC, Entity Framework Core, and SQL Server.

The project provides a simple interface for managing students and university departments while demonstrating core full-stack concepts such as MVC architecture, CRUD operations, database relationships, validation, filtering, and Entity Framework Core migrations.

## Features

### Student Management
- Create, view, edit, and delete students
- Search for students by ID
- Filter students by department and status
- View students who have passed
- Assign students to departments
- Track student status such as Active, Graduated, and Suspended
- Input validation for student information

### Department Management
- Create, edit, view, and delete departments
- View students belonging to a specific department
- Prevent deletion of departments that still have associated students

### Dashboard
- Total number of students
- Total number of departments
- Number of active students
- Number of graduated students
- Quick navigation to common actions

## Technologies

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views
- HTML
- CSS
- Bootstrap
- LINQ

## Architecture

The application follows the ASP.NET Core MVC pattern:

- **Models** represent application and database entities.
- **Views** provide the user interface using Razor, HTML, CSS, and Bootstrap.
- **Controllers** handle requests, application logic, and communication between the views and database.
- **Entity Framework Core** provides data access and maps C# entities to SQL Server tables.
- **Migrations** track and apply database schema changes.

## Database

The application contains a relationship between Students and Departments.

Each student can belong to a department through `DepartmentId`, which acts as a foreign key referencing the Departments table.

Entity Framework Core migrations are included in the repository so the database schema can be recreated locally.

## Screenshots

### Dashboard

![Dashboard](Screenshots/dashboard.png)

### Students

![Students](Screenshots/students.png)

### Departments

![Departments](Screenshots/departments.png)

### Department Details

![Department Details](Screenshots/department-details.png)

## Getting Started

### Prerequisites

To run the project locally, install:

- .NET SDK
- SQL Server or SQL Server Express
- Visual Studio with ASP.NET and web development tools

### Setup

1. Clone the repository.

2. Open the solution in Visual Studio.

3. Check the connection string in `appsettings.json`.

The default configuration uses SQL Server Express:

```text
Server=localhost\SQLEXPRESS;Database=StudentManagementDb;Trusted_Connection=True;TrustServerCertificate=True
```

Change it if your SQL Server instance uses a different name.

4. Open the Package Manager Console and run:

```powershell
Update-Database
```

This applies the included Entity Framework Core migrations and creates the database schema.

5. Run the application from Visual Studio.

## What I Practiced

This project was built as a hands-on full-stack learning project. It provided practice with:

- ASP.NET Core MVC architecture
- Controller actions
- Razor Views
- GET and POST requests
- Model binding
- Server-side validation
- Entity Framework Core
- LINQ queries
- SQL Server
- Database migrations
- Primary and foreign keys
- Entity relationships
- Dependency injection
- Asynchronous database operations
- Bootstrap and responsive UI design
- Git and GitHub project preparation

## Future Improvements

Possible future improvements include:

- Authentication and authorization
- User roles such as administrator, instructor, and student
- Course and enrollment management
- Pagination
- Advanced reporting
- REST API endpoints
- Automated testing

## Author

Jana Sawwan