# Parsing

These utilities provide methods for parsing content in Umbraco. Discovered placeholders will be replaced with corresponding properties from the content.

**Overview**

This library consists of two main components:

- `HumbleParserTagHelper`: A tag helper for parsing and replacing placeholders in content.
- `ParseImplementation`: A set of utility classes for parsing content.

## TLDR;

```
<humble-parser 
    content="@(yourHtmlEncodedString)" />
```

```
<humble-parser 
    content="@(yourString)" />
```

<br><br>

## HumbleParserTagHelper

**Usage**

The HumbleParserTagHelper allows you to replace placeholders in your content with values from Umbraco content nodes. To use it, follow these steps:

1. Add the `<humble-parser>` tag to your HTML content where you want to parse and replace placeholders.
1. In your controller or Razor view, set the **ContentToParse** property with your content that contains placeholders. This excepts types of `string` and `HtmlEncodedString`.
1. The **HumbleParserTagHelper** will automatically replace the placeholders with values from your Umbraco content.