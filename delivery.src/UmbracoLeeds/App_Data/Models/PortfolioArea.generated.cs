//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.6.1
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace YuzuDelivery.UmbracoModels
{
	/// <summary>PortfolioArea</summary>
	[PublishedModel("portfolioArea")]
	public partial class PortfolioArea : PublishedElementModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const string ModelTypeAlias = "portfolioArea";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<PortfolioArea, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public PortfolioArea(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Filters
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("filters")]
		public global::System.Collections.Generic.IEnumerable<global::YuzuDelivery.UmbracoModels.PortfolioAreaFilter> Filters => this.Value<global::System.Collections.Generic.IEnumerable<global::YuzuDelivery.UmbracoModels.PortfolioAreaFilter>>("filters");

		///<summary>
		/// Items
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("items")]
		public global::System.Collections.Generic.IEnumerable<global::Umbraco.Core.Models.PublishedContent.IPublishedContent> Items => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Core.Models.PublishedContent.IPublishedContent>>("items");

		///<summary>
		/// Mode
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("mode")]
		public string Mode => this.Value<string>("mode");

		///<summary>
		/// Testimonials
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("testimonials")]
		public global::YuzuDelivery.UmbracoModels.Testimonials Testimonials => this.Value<global::YuzuDelivery.UmbracoModels.Testimonials>("testimonials");

		///<summary>
		/// Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("title")]
		public global::YuzuDelivery.UmbracoModels.SectionHeading Title => this.Value<global::YuzuDelivery.UmbracoModels.SectionHeading>("title");
	}
}
