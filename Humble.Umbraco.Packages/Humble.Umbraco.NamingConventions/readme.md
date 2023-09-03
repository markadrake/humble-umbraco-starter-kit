> [Humble Umbraco Starter Kit](../../readme.md) → Packages → Naming Conventions

# Naming Conventions

This package provides automatic alias naming and configuration for Umbraco CMS content types and data types.

## Features

### Automatic Alias Naming for Content Types

When a content type is saved, the `ContentTypeSavingHandler` sets its alias based on its hierarchy. This ensures that the alias is always consistent with the content type's position in the content tree.

The alias is built by concatenating the names of the content type and all its ancestors, separated by underscores. For example, if a content type named "Article" is a child of a content type named "Blog", its alias will be set to "Blog_Article".

### Automatic Configuration for Block List Data Types

When a data type is saved, the `DataTypeSavingHandler` sets some of its configuration values automatically if it is of type Block List. This saves time by eliminating the need to configure these values manually.

The automatic configuration includes:

- Setting a custom view for every block editor in the configuration.
- Setting a custom stylesheet for every block editor in the configuration.
- Setting a thumbnail image for every block editor in the configuration.