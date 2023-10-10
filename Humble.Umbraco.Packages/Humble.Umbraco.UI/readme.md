> [Humble Umbraco Starter Kit](../../readme.md) → Packages → UI

# User Interface

Welcome to the User Interface (UI) section of the Humble Umbraco Starter Kit! This section provides various UI enhancements and utilities to improve your Umbraco CMS experience.

To use the Humble Umbraco Starter Kit User Interface features, follow these steps:

1. Install the `Humble.Umbraco.UI` NuGet package in your Umbraco project:
   ```shell
   dotnet add package Humble.Umbraco.UI
   ```
2. Reference `Humble.Umbraco.UI` from `/Views/_ViewImports.cshtml` file to take advantage of the tag helpers:
   ```csharp
   @addTagHelper *, Humble.Umbraco.UI.TagHelpers
   ```
3. Optionally, create a razor view at `/Views/sprite.cshtml`:
   ```csharp
   @{
      Layout = null;
      Context.Response.ContentType = "image/svg+xml";
   }
   <humble-sprite />
   ```
   
<br><br>

## Features

### Brand Icons

- Adds 2,678+ brand icons to the Umbraco backoffice, powered by [Simple Icons](https://simpleicons.org/). 
- These icons can be used throughout the backoffice to enhance the user experience.

### SVG Icon Rendering

- Simplifies the rendering of SVG icons in your Umbraco content. 
- Provides tag helpers to easily embed SVG icons using a clean and efficient syntax. 
- Refer to [SVG Icon Rendering Documentation](./svgs.md) for detailed usage instructions.

### String Interpolation

- Offers a powerful utility for parsing and replacing placeholders in content strings. 
- Allows you to replace placeholders with corresponding properties from Umbraco content nodes. 
- Streamlines the process of dynamically injecting content into your templates. 
- Refer to [String Interpolation Documentation](./parsing.md) for detailed usage instructions.

### Responsive Images (Work in Progress)

- (Work in Progress) Introduces a tag helper to simplify the rendering of responsive <picture> elements in your Umbraco templates. 
- Easily create and manage responsive images for various screen sizes and resolutions.