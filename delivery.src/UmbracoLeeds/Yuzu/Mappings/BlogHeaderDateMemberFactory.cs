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
    public class BlogHeaderDateMemberFactory : IYuzuTypeFactory<vmBlock_DataDate>
    {
        public vmBlock_DataDate Create(UmbracoMappingContext context)
        {
            return new vmBlock_DataDate()
            {
                Day = context.Model.CreateDate.Day.ToString(),
                MonthYear = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(context.Model.CreateDate.Month)}, {context.Model.CreateDate.Year}"
            };
        }
    }
}