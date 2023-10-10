# SvgTagHelper
This code provides a comprehensive solution for rendering SVG icons from both the Umbraco backoffice and the file system while efficiently caching them in memory. It also generates a combined SVG sprite for improved performance and reusability in web applications.

<br><br>

## TLDR;

**Render a Backoffice Icon**

```
<humble-icon name="facebook" />
```

**Render a SVG File**

```
<humble-icon path="~/icons/1password.svg" />
```

**Render the SVG Sprite**

```
<humble-sprite />
```

**Request the SVG Sprite as an Image**

```
<img src="/sprite.svg" />
```

<br><br>

## SvgIconTagHelper (Tag Helper for SVG Icons)

The SvgIconTagHelper is a custom HTML tag helper designed to render SVG icons within an HTML page. It can load SVG contents either from the Umbraco backoffice by providing a Name attribute or from the file system using a Path attribute.

**Dependencies**

- **IIconService**: An interface used to retrieve SVG icons from the Umbraco backoffice.
- **IMemoryCache**: Used for caching SVG contents in memory.
- **IUrlHelperFactory**: Provides URL generation capabilities.
- **IWebHostEnvironment**: Represents the hosting environment.

**Public Properties**

- `Name`: The name of the icon for loading SVG contents from the Umbraco backoffice.
- `Path`: The path of the icon file for loading SVG contents from the file system.

**Process Method**

The Process method is executed when the custom HTML tag (`<humble-icon>`) is encountered during rendering. It does the following:

1. Removes the custom HTML tag (`<humble-icon>`) from the output. 
2. Checks if either the Name or Path attribute is provided. 
3. If the Name attribute is provided, it retrieves the SVG content associated with the provided name from the Umbraco backoffice and converts it to a `<symbol>` element. 
4. If the Path attribute is provided, it reads the SVG content from the file system, converts it to a `<symbol>` element, and processes it. 
5. If neither attribute is provided, it suppresses the output.

**GetSvgContentForName Method**

1. Retrieves SVG content by name from the cache or the Umbraco backoffice. 
2. Converts the retrieved SVG content into a `<symbol>` element. 
3. Tracks the usage of the SVG icon.

**GetSvgContentForPath Method**

1. Retrieves SVG content by path from the cache or the file system. 
2. Converts the retrieved SVG content into a `<symbol>` element. 
3. Tracks the usage of the SVG icon.

**TrackSvgIconUse Method**

1. Tracks the usage of SVG icons in a hash set for caching.

**ConvertSvgToSymbol Method**

1. Converts an `<svg>` element into a `<symbol>` element while maintaining the viewBox attribute.

<br><br>

## SvgSpriteTagHelper (Tag Helper for SVG Sprite)

The **SvgSpriteTagHelper** is a custom HTML tag helper for rendering SVG icons as `<symbol>` elements within a hidden `<svg>` element. It collects and combines all SVG icons for use as a sprite.

**Dependencies**

- **IMemoryCache**: Used for caching SVG contents in memory. 

**Process Method** 

The Process method is executed when the custom HTML tag (`<humble-sprite>`) is encountered during rendering. It does the following:

1. Removes the custom HTML tag (`<humble-sprite>`) from the output. 
2. Creates an `<svg>` element with a display: none style attribute. 
3. Iterates over cached SVG icons and appends each one as a `<symbol>` element within the `<svg>`. 
4. Sets the generated SVG content as the TagHelper output.

<br><br>

## SvgSpriteController (Controller for SVG Sprite)

The SvgSpriteController is a controller responsible for rendering the sprite as an HTML view.

**Index Method**

1. Returns the `sprite.cshtml` view as an HTML response.

<br><br>

## SvgSpriteComposer (Composer for SVG Sprite)

The SvgSpriteComposer is responsible for configuring a custom route that maps `/sprite.svg` to the SvgSpriteController's Index action.