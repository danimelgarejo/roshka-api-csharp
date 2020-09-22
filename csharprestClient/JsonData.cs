using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharprestClient
{
    public class JsonData
    {
        public string _id { get; set; }
        public List<string> _website_urls { get; set; }
        public Description description { get; set; }
        public DateTime display_date { get; set; }
        public Headlines headlines { get; set; }
        public List<PromoItems> promo_items { get; set; }
        public DateTime publish_date { get; set; }
        public Subheadlines subheadlines { get; set; }
        public List<Taxonomy> taxonomy { get; set; }
    }
}
