using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDModels
{
    public class PodFeed //Motsarigheten till en serie typ
    {
        public string Id { set; get; }
        public string Link { set; get; }
        public string Name { set; get; }
        public string Category { set; get; }

        public PodFeed() { }
    }
}
