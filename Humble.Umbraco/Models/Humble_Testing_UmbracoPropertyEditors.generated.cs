//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v9.4.3+192eb2699ba4131addbb08236f60eb031707f751
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Umbraco Property Editors</summary>
	[PublishedModel("Humble_Testing_UmbracoPropertyEditors")]
	public partial class Humble_Testing_UmbracoPropertyEditors : PublishedContentModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		public new const string ModelTypeAlias = "Humble_Testing_UmbracoPropertyEditors";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<Humble_Testing_UmbracoPropertyEditors, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public Humble_Testing_UmbracoPropertyEditors(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Checkbox List
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("checkboxList")]
		public virtual global::System.Collections.Generic.IEnumerable<string> CheckboxList => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "checkboxList");

		///<summary>
		/// Color Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("colorPicker")]
		public virtual string ColorPicker => this.Value<string>(_publishedValueFallback, "colorPicker");

		///<summary>
		/// Content Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("contentPicker")]
		public virtual global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent ContentPicker => this.Value<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>(_publishedValueFallback, "contentPicker");

		///<summary>
		/// Date Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[ImplementPropertyType("datePicker")]
		public virtual global::System.DateTime DatePicker => this.Value<global::System.DateTime>(_publishedValueFallback, "datePicker");

		///<summary>
		/// Date Picker with Time
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[ImplementPropertyType("datePickerWithTime")]
		public virtual global::System.DateTime DatePickerWithTime => this.Value<global::System.DateTime>(_publishedValueFallback, "datePickerWithTime");

		///<summary>
		/// Decimal
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[ImplementPropertyType("decimal")]
		public virtual decimal Decimal => this.Value<decimal>(_publishedValueFallback, "decimal");

		///<summary>
		/// Dropdown
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("dropdown")]
		public virtual string Dropdown => this.Value<string>(_publishedValueFallback, "dropdown");

		///<summary>
		/// Email Address
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("emailAddress")]
		public virtual string EmailAddress => this.Value<string>(_publishedValueFallback, "emailAddress");

		///<summary>
		/// Eye Dropper Color Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("eyeDropperColorPicker")]
		public virtual string EyeDropperColorPicker => this.Value<string>(_publishedValueFallback, "eyeDropperColorPicker");

		///<summary>
		/// File Upload: Only accepts the following: [gif, jpeg, jpg, png, webp]
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("fileUpload")]
		public virtual string FileUpload => this.Value<string>(_publishedValueFallback, "fileUpload");

		///<summary>
		/// Grid Layout
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("gridLayout")]
		public virtual global::Newtonsoft.Json.Linq.JToken GridLayout => this.Value<global::Newtonsoft.Json.Linq.JToken>(_publishedValueFallback, "gridLayout");

		///<summary>
		/// Image Cropper
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("imageCropper")]
		public virtual global::Umbraco.Cms.Core.PropertyEditors.ValueConverters.ImageCropperValue ImageCropper => this.Value<global::Umbraco.Cms.Core.PropertyEditors.ValueConverters.ImageCropperValue>(_publishedValueFallback, "imageCropper");

		///<summary>
		/// Markdown Editor
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("markdownEditor")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString MarkdownEditor => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "markdownEditor");

		///<summary>
		/// Media Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("mediaPicker")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.MediaWithCrops> MediaPicker => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.MediaWithCrops>>(_publishedValueFallback, "mediaPicker");

		///<summary>
		/// Member Group Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("memberGroupPicker")]
		public virtual string MemberGroupPicker => this.Value<string>(_publishedValueFallback, "memberGroupPicker");

		///<summary>
		/// Member Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("memberPicker")]
		public virtual global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent MemberPicker => this.Value<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>(_publishedValueFallback, "memberPicker");

		///<summary>
		/// Multinode Treepicker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("multinodeTreepicker")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent> MultinodeTreepicker => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>>(_publishedValueFallback, "multinodeTreepicker");

		///<summary>
		/// Multi URL Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("multiURLPicker")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.Link> MultiUrlpicker => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.Link>>(_publishedValueFallback, "multiURLPicker");

		///<summary>
		/// Numeric
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[ImplementPropertyType("numeric")]
		public virtual int Numeric => this.Value<int>(_publishedValueFallback, "numeric");

		///<summary>
		/// Radio Button List
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("radioButtonList")]
		public virtual string RadioButtonList => this.Value<string>(_publishedValueFallback, "radioButtonList");

		///<summary>
		/// Repeatable Textstrings
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("repeatableTextstrings")]
		public virtual global::System.Collections.Generic.IEnumerable<string> RepeatableTextstrings => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "repeatableTextstrings");

		///<summary>
		/// Richtext Editor
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("richtextEditor")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString RichtextEditor => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "richtextEditor");

		///<summary>
		/// Slider
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[ImplementPropertyType("slider")]
		public virtual decimal Slider => this.Value<decimal>(_publishedValueFallback, "slider");

		///<summary>
		/// Tags
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("tags")]
		public virtual global::System.Collections.Generic.IEnumerable<string> Tags => this.Value<global::System.Collections.Generic.IEnumerable<string>>(_publishedValueFallback, "tags");

		///<summary>
		/// Textarea
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("textarea")]
		public virtual string Textarea => this.Value<string>(_publishedValueFallback, "textarea");

		///<summary>
		/// Text String
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("textString")]
		public virtual string TextString => this.Value<string>(_publishedValueFallback, "textString");

		///<summary>
		/// True / False
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[ImplementPropertyType("trueFalse")]
		public virtual bool TrueFalse => this.Value<bool>(_publishedValueFallback, "trueFalse");

		///<summary>
		/// User Picker
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("userPicker")]
		public virtual object UserPicker => this.Value(_publishedValueFallback, "userPicker");
	}
}
