/*
 * Ref: https://github.com/umbraco/Umbraco-CMS/blob/5bfab13dc5a268714aad2426a2b68ab5561a6407/src/Umbraco.Core/Templates/HtmlLocalLinkParser.cs
 * Ref: https://stackoverflow.com/questions/36977442/how-to-to-transform-a-string-of-property-names-into-an-objects-property-values
 */
using System.Text.RegularExpressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using System.Reflection;
using Umbraco.Cms.Web.Common;

namespace Humble.Umbraco.Parsers
{
	public static class IHtmlEncodedStringExtensions
	{
		private static readonly Regex ReplacePattern = new Regex(@"{{([a-zA-Z]+)}}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

		public static IHtmlEncodedString Parse(this IHtmlEncodedString Html, IPublishedContent Content)
		{
			// Exit: string contents are null or empty
			if (Html == null) return Html;

			// Exit: no current asigned content item
			if (Content == null) return Html;

			// Find matches
			MatchCollection matches = ReplacePattern.Matches(Html.ToString());

			// Exit: no matches
			if (matches.Count.Equals(0)) return Html;

			// Build new string from model data
			var type = Content.GetType();
			string newContents = Html.ToString();
			
			// Begin replacing values
			foreach (Match match in matches)
			{
				string key = match.Groups[1].Value;
				PropertyInfo typeProperty = type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

				if (typeProperty != null)
				{
					newContents = newContents.Replace(match.Value, typeProperty.GetValue(Content, null).ToString());
					continue;
				}

				var contentProperty = Content.GetProperty(key);
				if (contentProperty == null) continue;

				object value = contentProperty.GetValue();
				if (value == null) continue;

				newContents = newContents.Replace(match.Value, value.ToString());
			}

			// Return replaced values
			return new HtmlEncodedString(newContents);
		}
	}
}
