## Library Management Tests

### Project Overview

This project contains NUnit tests for the LibraryManagement system. It tests: 
- Book: borrowing, returning, availability
- Patron: borrowing and returning books
- Library: adding/removing books and patrons, searching books and borrowing and returning books

The tests ensure the core logic works correctly.

### Running the project
1. Clone the repository

    ``` git clone <repo-url> ```
2. Navigate to the project

    ``` cd LibraryManagement.Tests ```
3. Ensure the test project references the main project

    ``` dotnet add reference <path-to-main-project-csproj-in-LibraryManagement> ```

4. Restore dependencies and build

    ``` dotnet restore ```
    
    ``` dotnet build ```

5. Run the tests

    ``` dotnet test ```