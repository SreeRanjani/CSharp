# Controller View Communication

## Updating View with Data from Controller

- For accessing C# data from view use `@`.
- To pass arguments from Controller to View when calling `View()` from controller, - Add `@model ModelDataType` Example: `@model List<Category>`
  This can then be accessed in the view using `@Model`
