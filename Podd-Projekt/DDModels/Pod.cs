using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDModels
{
    public class Pod //Motvarigheten till en episod
    {
        public string Id { set; get; }
        public string Titel{ set; get; }
        public string Description{ set; get; }
        public string Link { set; get; }
        public string? LinkRef { set; get; }//Det som säger att den tillhör en viss feed, typ FeedId

        public Pod() { }
    }
}
