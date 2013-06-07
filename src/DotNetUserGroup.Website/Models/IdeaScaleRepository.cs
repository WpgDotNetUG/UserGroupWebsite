using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace DotNetUserGroup.Website.Models
{
    public class IdeaScaleRepository : IRepository<FutureTopicInfo>
    {
        private const string URL = "http://wpgdotnet.ideascale.com/userimages/accounts/90/909119/ideascale_top_20115.xml";

        public IEnumerable<FutureTopicInfo> All()
        {
            return Request();
        }

        private static IEnumerable<FutureTopicInfo> Request()
        {
            var feed = XmlReader.Create(URL);
            var topics = SyndicationFeed.Load(feed);
	    feed.Close();

            if (topics != null)
            {
                return topics.Items.Select(x => new FutureTopicInfo()
                    {
                        Topic = x.Title.Text,
			Url = x.Links[0].Uri.ToString(),
                        Votes = 0,
                    });
            }

            return Enumerable.Empty<FutureTopicInfo>();
        }
    }
}