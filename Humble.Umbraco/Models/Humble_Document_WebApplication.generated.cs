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
	/// <summary>Web Application</summary>
	[PublishedModel("Humble_Document_WebApplication")]
	public partial class Humble_Document_WebApplication : PublishedContentModel, IHumble_Composition_HasBlockEditor, IHumble_Composition_HasNavigation, IHumble_Composition_HasOpenGraph, IHumble_Composition_HasSeo, IHumble_Composition_HasWebApplicationSettings
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		public new const string ModelTypeAlias = "Humble_Document_WebApplication";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<Humble_Document_WebApplication, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public Humble_Document_WebApplication(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Media
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("media")]
		public virtual global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent Media => this.Value<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>(_publishedValueFallback, "media");

		///<summary>
		/// Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("content")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel Content => global::Umbraco.Cms.Web.Common.PublishedModels.Humble_Composition_HasBlockEditor.GetContent(this, _publishedValueFallback);

		///<summary>
		/// Navigation: (Recommended)
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("navigationItems")]
		public virtual global::Umbraco.Cms.Core.Models.Blocks.BlockListModel NavigationItems => global::Umbraco.Cms.Web.Common.PublishedModels.Humble_Composition_HasNavigation.GetNavigationItems(this, _publishedValueFallback);

		///<summary>
		/// openGraphLabel: Placeholder for open graph properties.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("openGraphLabel")]
		public virtual string OpenGraphLabel => global::Umbraco.Cms.Web.Common.PublishedModels.Humble_Composition_HasOpenGraph.GetOpenGraphLabel(this, _publishedValueFallback);

		///<summary>
		/// seoLabel: Placeholder for SEO properties.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("seoLabel")]
		public virtual string SeoLabel => global::Umbraco.Cms.Web.Common.PublishedModels.Humble_Composition_HasSeo.GetSeoLabel(this, _publishedValueFallback);

		///<summary>
		/// Canonical Domain: (Optional) Provide the canonical domain for this web application.{br}{br}{strong}Example:{/strong} {code}google.com{/code}
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("canonicalDomain")]
		public virtual string CanonicalDomain => global::Umbraco.Cms.Web.Common.PublishedModels.Humble_Composition_HasWebApplicationSettings.GetCanonicalDomain(this, _publishedValueFallback);

		///<summary>
		/// Window Title Format: (Optional) Customize the formatting of the browser window title.{br}{br}{code}{{page-title}}{/code}{br}{code}{{site-title}}{/code}
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.4.3+192eb2699ba4131addbb08236f60eb031707f751")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("windowTitleFormat")]
		public virtual string WindowTitleFormat => global::Umbraco.Cms.Web.Common.PublishedModels.Humble_Composition_HasWebApplicationSettings.GetWindowTitleFormat(this, _publishedValueFallback);
	}
}
