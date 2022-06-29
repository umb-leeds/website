using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.UmbracoModels;
using YuzuDelivery.ViewModels;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using Umbraco.Core.Cache;

namespace UmbracoLeeds
{
    public class MeetupEventsResolver : IYuzuPropertyReplaceResolver<Events, List<vmSub_EventsItem>>
    {
        private readonly IAppPolicyCache runtimeCache;

        private const string CACHE_KEY = "umbleeds_meetupcache";

        public MeetupEventsResolver(AppCaches appCaches)
        {
            runtimeCache = appCaches.RuntimeCache;
        }

        public List<vmSub_EventsItem> Resolve(Events source, UmbracoMappingContext context)
        {
            var json = GetMeetingData();
            var data = JArray.Parse(json);
            var mfi = new DateTimeFormatInfo();

            return data.Take(3).Select(x =>
            {
                var obj = x as dynamic;
                DateTime date = DateTime.Parse(obj.local_date.ToString());

                return new vmSub_EventsItem()
                {
                    Date = new vmBlock_DataDate()
                    {
                        Day = date.Day.ToString(),
                        MonthYear = string.Format("{0}, {1}", mfi.GetMonthName(date.Month), date.Year)
                    },
                    Venue = "",
                    Title = obj.name,
                    Summary = GetFirstParagraph(obj.description.ToString()),
                    Link = new vmBlock_DataLink()
                    {
                        Href = obj.link,
                        Label = "Read more"
                    }
                };

            }).ToList();

        }

        private string GetMeetingData()
        {
            return runtimeCache.GetCacheItem(CACHE_KEY, () =>
            {
                return new WebClient().DownloadString("https://api.meetup.com/umbLeeds/events");
            }, TimeSpan.FromDays(1));
        }

        private string GetFirstParagraph(string htmltext)
        {
            Match m = Regex.Match(htmltext, @"<p>\s*(.+?)\s*</p>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
            {
                return htmltext;
            }
        }
    }
}
