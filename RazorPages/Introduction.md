# Introduction

This is similar to MVC, but the code is in code behind file similar to Win Forms. This follows MVVM (Model, View, Model-View). There are no controllers here.

There is a `.cshtml` file which is the HTML file (View), it has a code behind file of type `.cshtml.cs` file (View-model)

The code behind file supports `OnGet()` and `OnPut()` methods which are called on the respective methods. Each view can have only one of the above 2 operations.

- OnGet() - renders the page, called when the page is loaded
- OnPost() - run when we post data to a page

## Page Details

- @page, @model, @{} are razor syntax
- @Model - this is the view model or code behind

## Data Input

- Added as properties to the model, this can be used in the page as `@Model.PropertyName`
- If we want to be writable, by using `[BindProperty]`. When added this can be used in post.
- To use it in get as query parameter we can use `[BindProperty(SupportsGet - true)]`
