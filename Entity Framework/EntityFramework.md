# What is EntityFramework

- It is a Framework that helps to access any SQL Database using code.

# Pre-requisites

- Any SQL Database Server. We can use MS SQL as example. Link - https://www.microsoft.com/en-IN/sql-server/sql-server-downloads
- Management system/studio for the SQL Database. We are consider MS SQL Management Studio - https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

## Dependency Packages

- To use Entity framework with DB, 3 Nuget packages needs to be added to the project
  1. Microsoft.EntityFrameworkCore
  2. Microsoft.EntityFrameworkCore.Tools - This is required to work with migration related commands
  3. Microsoft.EntityFrameworkCore.SqlServer

# Interacting with DB

## Connection String

- To connect to SQL DB, we need its connection string. Connection string consists of server name and DB name
  - Server Name: This can be obtained by launching SSMS. Launch SSMS, a connect to server window will be opened which will have the connection string ![SSMSConnectToServer](./Images/SSMSServerConnection.PNG)
  - DB Name: Any DB name can be given
- Connection string needs to be mentioned in the `appsettings.json` file with the below syntax. In addition to Server Name and DB Name, `Trusted_Connection` and `TrustServerCertificate` needs to be set to true.

```csharp
"ConnectionStrings":
{
    "DefaultConnection":"Server=<serverName>; Database=<DatabaseName>; Trusted_Connection=True; TrustServerCertificate=True"
}
```

# DBContext

- To communicate with SQL DB, we should use a `DBContext` parent class and do migration.
- Steps to setup DBContext

  1. Create a class which inherits from `DBContext`.

  - Suggestion is to create this in a folder called as `Data` parallel to Controller and name this as `ApplicationDbContext.cs`
  - Add a constructor which takes in `DbContextOptions<ApplicationDbContext>` as argument and passes it to the base
    ![ApplicationDBContext](./Images/ApplicationDbContext.PNG)

  2. Add DBContext to the services in `Program.cs` <br/>

  - When adding the DBContext to services, set option to use SQLServer <br/>
  - Pass the connection string property as argument to this
    ![ProgramCSWithAppDBContext](./Images/ProgramCSWithDbContext.PNG)

# Creating DB

- After setting up the `ApplicationDBContext` and `Program.cs`, open `Package Manger Console(PM Console)` by using `Tools -> Package Manager Console` and run the command `update-database`
- A table called `_EFMigrationHistory` will be present in the database which will track any migration that is being performed
- This should be run in the project having DbContext
- This will create the Database with name mentioned in the connection string

# Creating Tables

## Creating Models

- To create tables in SQL using Entity Framework, we needn't directly do it. We can create a table and entity Framework will take care of creating it in the DB during migration process.

### Rules for Creating Models for Tables

- Model corresponding to each table should create a _Primary Key_ property. There are three ways to make a property primary key
  1. By naming it `Id`
  2. By naming it `{ModelName}Id`
  3. If the above 2 cannot be done, you can give any convenient name and use the annotation `[Key]`
- If a column in DB should be made `Non-nullable`, then use the attribute `[Required]` for the corresponding property

### Creating Tables using PM Console

- After creating the required model, add a property of type `DbSet<>` corresponding to the model in the `ApplicationDbContext`
- Format

```csharp
    DbSet<Name of the model> Name of the table {get; set;};
```

Example:

```csharp
    DbSet<Category> Categories {get; set;};
```

- After adding this, open the PM Console and add a migration using the command `add-migration {Name}`. This step will create a _Migration_ folder if not present and add the current migration with date time to this folder.
- Then run the `update-database` command in the PM Console. This will apply the migration to database. Hence a table corresponding to the collection will be added to DB.
