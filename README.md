# Movie Management App

## Overview

This is a RESTful Web API built using ASP.NET Core for managing movies.
It supports CRUD operations, search functionality, and role-based authorization.

## Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server (LocalDB)
* AutoMapper
* xUnit & Moq (for testing)
* Angular (v21, for frontend - separate project - seperate README)

## Setup Instructions

### 1. Clone the repository

```bash
git clone <repo-url>
cd MovieApp
```

### 2. Configure Database

Update `appsettings.json`:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MovieDb;Trusted_Connection=True;"
}

### 3. Run Migrations

```bash
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

API will be available at:

```
https://localhost:44385
```
Swagger UI will be available at:
```
https://localhost:44385/swagger
```

## Features

* Get all movies
* Get latest movies
* Get movie by ID
* Add movie (Admin only)
* Update movie (Admin only)
* Delete movie (Admin only)
* Search movies (by title / genre / year)

## Testing

Run tests using:

```bash
dotnet test
```

Includes:

* Service layer unit tests
* Controller tests using Moq

## Notes

* Database is seeded with initial movie data using DbSeeder
* AutoMapper is used for DTO mapping
* Clean architecture with Repository + Service pattern

