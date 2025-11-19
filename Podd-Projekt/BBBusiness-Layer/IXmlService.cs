using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;


namespace BBBusiness_Layer
{
    public interface IXmlService
    {
        Task SavePodFeedToXml(PodFeed pf);
        Task<PodFeed> LoadPodFeedFromXml();
    }
}
