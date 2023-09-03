using System.Text.RegularExpressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using System.Reflection;
using NUglify.Helpers;

namespace Humble.Umbraco.UI.Extensions;

public static class ParseImplementation
{
    // Pattern to find all placeholders within a string.
    private static readonly Regex ReplacePattern = new Regex(@"{{([a-zA-Z]+)}}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

    /// <summary>
    /// Checks if the provided value and content are not null or empty.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <param name="content">The content to be checked.</param>
    /// <returns>Returns true if both value and content are not null or empty, otherwise false.</returns>
    private static bool HasValues<T>(T value, IPublishedContent content)
    {
        if (value == null || value.ToString().IsNullOrWhiteSpace())
            return false;
        if (content == null)
            return false;
        return true;
    }

    /// <summary>
    /// Replaces placeholders in the value with the corresponding properties from the content.
    /// </summary>
    /// <param name="value">The string containing placeholders.</param>
    /// <param name="content">The content with properties to replace placeholders.</param>
    /// <returns>Returns a new string with replaced values.</returns>
    private static string ReplaceValues<T>(T value, IPublishedContent content)
    {
        // Exit: values not provided.
        if (!HasValues(value, content)) return "";

        // Find matches
        MatchCollection matches = ReplacePattern.Matches(value.ToString());

        // Exit: no matches
        if (matches.Count.Equals(0)) return value.ToString();

        // Build new string from model data
        var type = content.GetType();
        string newContents = value.ToString();

        // Begin replacing values
        foreach (Match match in matches)
        {
            string key = match.Groups[1].Value;
            PropertyInfo typeProperty = type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

            if (typeProperty != null)
            {
                newContents = newContents.Replace(match.Value, typeProperty.GetValue(content, null).ToString());
                continue;
            }

            var contentProperty = content.GetProperty(key);
            if (contentProperty == null) continue;

            object objValue = contentProperty.GetValue();
            if (objValue == null) continue;

            newContents = newContents.Replace(match.Value, objValue.ToString());
        }

        // Return replaced values
        return newContents;
    }

    /// <summary>
    /// Extension method for string. Replaces placeholders in the value with the corresponding properties from the content.
    /// </summary>
    /// <param name="value">The string containing placeholders.</param>
    /// <param name="content">The content with properties to replace placeholders.</param>
    /// <returns>Returns a new string with replaced values.</returns>
    public static string Parse(this string value, IPublishedContent content)
    {
        return ReplaceValues(value, content);
    }

    /// <summary>
    /// Extension method for IHtmlEncodedString. Replaces placeholders in the value with the corresponding properties from the content.
    /// </summary>
    /// <param name="html">The IHtmlEncodedString containing placeholders.</param>
    /// <param name="content">The content with properties to replace placeholders.</param>
    /// <returns>Returns a new IHtmlEncodedString with replaced values.</returns>
    public static IHtmlEncodedString Parse(this IHtmlEncodedString html, IPublishedContent content)
    {
        return new HtmlEncodedString(ReplaceValues(html, content));
    }
}