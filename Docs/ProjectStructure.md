# Solution

A C# solution can have multiple projects

# Files in a CS Project

MVC project in .NET core will have following files

- Project File
- Dependencies folder
- Properties folder
- appsettings.json
- Program.cs
- wwwroot

## Project File Content

The project file will have the following details

- Version of the .NET in which this project is built
- Nullable - enable/disable
- ImplicitUsing - enable/disable
  - Used to specify if the default C# usings should be explicitly added or not

Project file can be edited by either double clicking on the project name or _Right Click -> Edit Project File_

## Dependencies

Dependencies will have the following,

- Analyzers
- Frameworks
- Packages - Nuget Packages
- Projects - Other projects
- Model - Contains all the classes that represents data
- Views - Contains the user interface related files
- Controller - Heart of the application, interface between model and views.

## Properties Folder

This has the _launchSettings.json_ file, this defines the following

- Settings corresponding to IIS and other Profiles
- The profile can be selected using button in the toolbar
  ![launchSettings.json](images\LaunchSettings.png)
- The settings have details about

  - Port
  - URL
  - Environment Variable - Environment variables can be added here and be used in the code

  ## Program.cs

  This is the starting point, we can add services and configure the _request pipeline_

  Request pipeline takes care of how requests are handled by the service.
  ![Program.cs](images/Programcs.PNG)

  Service used by default for MVC projects are _AddControllerWithViews_

  Common app configurations,

  1. app.UseHttpsRedirection -
  2. app.UseStaticFiles - Configures **wwwroot** and all the static files from there will be accessible in our application
  3. app.UseRouting -
  4. app.UseAuthorization -
  5. app.MapControllerRoute - Defines the default route to be followed when explicit routes are not configured. By default the control will go to _Home Controller -> Index Action_
  6. app.run - Runs the project

Note: Service is added to **builder** and **middleware** are added to application

## Controller Folder

- This folder contains all the controller files of the MVC pattern
  - Controller class files inherit from the `Controller` class
- Controller files should only be present in the _Controller_ folder
- Name of the controller should end with the name _Controller_
- Name before _Controller_ will be the route
  </br>Example: `HomeController.cs` - In this case, the requests with route _home_ will be routed to this file

## Model Folder

- This folder contains normal _cs_ files which are used to represent data

## Views Folder

### Controller Views

- This contains a sub-folder corresponding to each of the controller,
  name of the sub-folder should match the controller name
- The sub-folder contains files of type `.cshtml`
- In the controller, when an Action simply returns view without specifying the name, the name of the view (cshtml) file corresponding to the Action will be returned.
- In the below example, when Index action is called, `Index.cshtml` will be returned and when privacy action is called `Privacy.cshtml` will be returned. But custom view names could also be passed, hence the name of files in View needn't always match the Action methods.
  <br/> Example: ![ControllerWithDefaultViews](images/Controller.PNG)

### Shared Views

- The _Shared_ sub-folder inside the Views folder contains the component that are shared among all the views.
- This has - _Layout - This is the master file that is launched, which has the header, footer and which loads the individual pages using `@RenderBody()` function - \_ValidationScriptPartial - This contains the different scripts that will be used for basic client side validation. - Error - Displays the error message
  The "_" is not essential but a common convention to denote these are common components and are partial files (files that cannot be rendered by itself, that will be consumed by the main view)

### Other View Files

- \_ViewStart.cshtml - Denotes what is the master page or default layout
- \_ViewImports.cshtml - This contains the using statements that are common for all the views. This is like a global import file
