using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.UmbracoModels;
using YuzuDelivery.ViewModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace UmbracoLeeds
{
    public class PortfolioNavigationMemberResolver : IYuzuPropertyReplaceResolver<Portfolio, vmSub_PortfolioNavigation>
    {
        private readonly IMapper mapper;

        public PortfolioNavigationMemberResolver(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public vmSub_PortfolioNavigation Resolve(Portfolio source, UmbracoMappingContext context)
        {
            var model = context.Model;
            if (model != null)
            {
                var siblings = model.Siblings().ToList();
                var prev = siblings.LastOrDefault(x => x.SortOrder < model.SortOrder);
                var next = siblings.FirstOrDefault(x => x.SortOrder > model.SortOrder);

                return new vmSub_PortfolioNavigation()
                {
                    Next = GetLink(next, "Next"),
                    Back = GetLink(model, "Back"),
                    Previous = GetLink(prev, "Previous")
                };
            }
            else
                return new vmSub_PortfolioNavigation()
                {
                    Next = new vmBlock_DataLink() { Label = "Next" },
                    Back = new vmBlock_DataLink() { Label = "Back" },
                    Previous = new vmBlock_DataLink() { Label = "Previous" }
                };
        }

        public vmBlock_DataLink GetLink(IPublishedContent content, string label)
        {
            if (content != null)
                return new vmBlock_DataLink()
                {
                    Href = content.Url,
                    Label = label
                };
            else
                return null;
        }
    }
}