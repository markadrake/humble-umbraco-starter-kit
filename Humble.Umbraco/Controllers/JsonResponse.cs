using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Humble.Umbraco.Controllers
{
	public class JsonResponse
	{

		public DateTime CreateDate { get; set; }
		public int Id { get; set; }
		public string ItemType { get; set; }
		public Guid Key { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public IEnumerable<JsonProperty> Properties { get; set; }
		public int SortOrder { get; set; }

		public JsonResponse(ContentModel contentModel)
		{
			var c = contentModel.Content;

			CreateDate = c.CreateDate;
			Id = c.Id;
			ItemType = c.ItemType.ToString();
			Key = c.Key;
			Name = c.Name;
			Path = c.Path;
			Properties = GetJsonProperties(c.Properties);
			SortOrder = c.SortOrder;
		}

		private IEnumerable<JsonProperty> GetJsonProperties(IEnumerable<IPublishedProperty> properties)
		{
			var jsonProperties = new List<JsonProperty>();

			properties.ForEach(prop => {
				jsonProperties.Add(new JsonProperty(prop));
			});

			return jsonProperties;
		}
	}

	public class JsonProperty
	{
		public string Alias { get; set; }
		public object Value { get; set; }
		public string DataType { get; set; }

		public JsonProperty(IPublishedProperty property)
		{
			var p = property;

			Alias = p.Alias;
			DataType = p.PropertyType.DataType.EditorAlias;

			switch(DataType)
			{
				case "Umbraco.Label":
				case "Umbraco.TextBox":
					Value = p.GetValue().ToString();
					break;
				case "Umbraco.BlockList":
					SetValue(p.GetValue() as BlockListModel);
					break;
				case "Umbraco.MediaPicker":
					SetValue(p.GetValue() as Image);
					break;
			}
		}

		private void SetValue(BlockListModel Model)
		{
			if (Model == null) return;
			if (!Model.Any()) return;

			List<IPublishedElement> settings = new List<IPublishedElement>();
			List<object> content = new List<object>();

			foreach(BlockListItem item in Model)
			{
				settings.Add(item.Settings);
				content.Add(GetValue(item.Content));
			}

			Value = new
			{
				settings,
				content
			};
		}

		private void SetValue(Image Model)
		{
			var m = Model;

			Value = new
			{
				Copyright = m.CopyrightInfo,
				ContentType = m.ContentType.Alias,
				File = m.UmbracoFile,
				Width = m.UmbracoWidth,
				Height = m.UmbracoHeight
			};
		}

		private object GetValue(IPublishedElement Model)
		{
			var m = Model;

			var o = new
			{
				Key = m.Key,
				ContentType = m.ContentType.Alias,
				Properties = m.Properties.Select(p => p.GetValue().ToString())
			};

			return o;
		}

		private object GetValue(IPublishedProperty Model)
		{
			return Model.GetValue();
		}
	}

}
