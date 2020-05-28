using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;

namespace UmbracoLeeds
{
    public class BreadcrumbTypeFactory : IYuzuTypeFactory<vmBlock_Breadcrumb>
    {
        private readonly IMapper mapper;

        public BreadcrumbTypeFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public vmBlock_Breadcrumb Create(UmbracoMappingContext context)
        {
            var title = string.Empty;
            var crumbs = new List<vmBlock_DataLink>();

            if (context.Model != null)
            {
                var node = context.Model;
                title = node.Name;

                while (node.Parent != null)
                {
                    if (node.TemplateId > 0)
                    {
                        crumbs.Add(mapper.Map<vmBlock_DataLink>(node));
                    }
                    node = node.Parent;
                }

                crumbs.Add(mapper.Map<vmBlock_DataLink>(node));
                crumbs.Reverse();
            }
            else
            {
                title = "Title";
                crumbs.Add(new vmBlock_DataLink() { Label = "Home" });
                crumbs.Add(new vmBlock_DataLink() { Label = "Example Breadcrumb" });
            }

            return new vmBlock_Breadcrumb()
            {
                Title = title,
                Crumbs = crumbs
            };
        }
    }
}