using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;
using System.Globalization;

namespace UmbracoLeeds
{
    public class BlogListItemTypeConvertor : IYuzuTypeConvertor<BlogDetailPage, vmSub_BlogListItem>
    {
        private readonly IMapper mapper;

        public BlogListItemTypeConvertor(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public vmSub_BlogListItem Convert(BlogDetailPage source, UmbracoMappingContext context)
        {
            return new vmSub_BlogListItem()
            {
                Title = source.SummaryTitle,
                Summary = source.SummarySummary,
                Link = new vmBlock_DataLink()
                {
                    Href = source.Url,
                    Label = "Read more"
                },
                Image = mapper.Map<vmBlock_DataImage>(source.SummaryImage), 
                Date = new vmBlock_DataDate()
                {
                    Day = source.CreateDate.Day.ToString(),
                    MonthYear = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(source.CreateDate.Month)}, {source.CreateDate.Year}"
                }
            };
        }
    }
}