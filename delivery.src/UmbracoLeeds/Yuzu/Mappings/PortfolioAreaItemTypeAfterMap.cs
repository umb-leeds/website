using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;

namespace UmbracoLeeds
{
    public class PortfolioAreaItemTypeAfterMap : IYuzuTypeAfterConvertor<PortfolioDetailPage, vmSub_PortfolioAreaItem>
    {
        public void Apply(PortfolioDetailPage source, vmSub_PortfolioAreaItem dest, UmbracoMappingContext context)
        {
            dest.Link = new vmBlock_DataLink()
            {
                Href = source.Url
            };
        }
    }
}