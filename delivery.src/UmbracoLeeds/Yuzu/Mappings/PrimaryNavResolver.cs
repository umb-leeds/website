using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.UmbracoModels;
using YuzuDelivery.ViewModels;
using YuzuDelivery.Core;

namespace UmbracoLeeds
{
    public class PrimaryNavResolver : IYuzuPropertyReplaceResolver<Template, vmBlock_SiteNav>
    {
        private readonly IMapper mapper;

        public PrimaryNavResolver(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public vmBlock_SiteNav Resolve(Template source, UmbracoMappingContext context)
        {
            return new vmBlock_SiteNav()
            {
                Items = source.HeaderLinks.Select(x => new vmSub_SiteNavItem
                {
                    Link = mapper.Map<vmBlock_DataLink>(x)
                }).ToList()
            };
        }
    }
}