# ASP.NET Core Web API Development# 

This project demonstrates the development of a RESTful API using ASP.NET Core and Entity Framework Core. It provides CRUD operations for managing books and authors in a library system.

## Features

- **CRUD Operations**:
  - Create, Read, Update, and Delete operations for books.
- **Query Support**:
  - Fetch all books or a specific book by ID, including related author.
- **Data Storage**:
  - Uses Entity Framework Core with SQL Server Local db.

## Endpoints

### BooksController

| HTTP Method | Endpoint                  | Description                                      |
|-------------|---------------------------|--------------------------------------------------|
| GET         | /api/books                | Retrieves a list of all books.                  |
| GET         | /api/books/{id}           | Retrieves details of a specific book by ID.     |
| POST        | /api/books                | Creates a new book entry.                       |
| PUT         | /api/books/{id}           | Updates an existing book entry by ID.           |
| DELETE      | /api/books/{id}           | Deletes a book entry by ID.                     |

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Running the Project

1. Clone the repository:
   
```shell
   git clone <repository-url>
   cd APIDevelopment.WithEFCore
   
```

2. Restore dependencies:
   
```shell
   dotnet restore
   
```

3. Run the application:
   
```shell
   dotnet run
   
```

4. The API will be available at `https://localhost:{port}/api/books`.

### Testing the API

You can test the API using in-built Scalar UI

## Project Structure

- **Controllers**:
  - `BooksController`: Handles API endpoints for managing books.
- **Data**:
  - `LibraryContext`: Entity Framework Core DbContext for managing database interactions.
- **Models**:
  - `Book` and `Author`: Represent the data entities.
- **DTOs**:
  - `BookDto` and `AuthorDto`: Data Transfer Objects for API responses.

