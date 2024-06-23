# BlogTest
This is a simple blogging application built with .NET, designed to demonstrate CRUD operations and basic blog functionalities, Using CQRS Architecture pattern.
The entity relationship was extended to suit the requirement..
    - Blog and post  1 - Many relationship (originally from the question description)
    - Author and Blog has a 1 - Many relationship (extended to accommodate the crud operation to be performed)

## Prerequisites

- .NET SDK 6.0
- SQLite

  ## Git
  - Clone the application.
  - Open Developer PowerShell
  -The application has 4 branches
          - remotes/origin/CQRS_Implementation
          - remotes/origin/CQRS_UnitTesting
          - remotes/origin/CodeBaseSetup
          - remotes/origin/HEAD -> origin/master
          - remotes/origin/master
  - Master : Has the complete application with Unit Testing 
  - CodeBaseSetup : Has the initial code setup as per requirement "Task 1"
  - CQRS_Implementation : has the implementation of the CQRS architecture "Task 2"
  - CQRS_UnitTesting : has unit test  implementation "Tasks 3"

## Application Run
- Open the solution folder
- open the solution[BlogTest.sln] file in Visual Studio
- Open the Package Manager Console
      - dotnet Restore
- Inside the solution folder there is a sqlite document database file (Blogging.db)
    - There is an already exisitng data to help carry out the test (CRUD) operation
 
  ## Usage(CRUD)
  - In the Master branch as well as the "CQRS_Testing"
  - Run the application to find the swagger page opened
  - you can carry out basic crud such as
            - Add Author from the POST endpoint
            - Query Author from the GET endpoint(to get author ID)
            - Add Blog from the POST endpoint(AuthorId gotten from the Author Get endpoint)
            - Query Blog from the Get endpoint
            - Add POST from the post endpoint
            - Get post by Blogs with the Get endpoint.
    
