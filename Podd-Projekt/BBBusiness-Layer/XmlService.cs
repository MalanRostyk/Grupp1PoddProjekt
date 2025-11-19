using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCData_Access_Layer;
using DDModels;

namespace BBBusiness_Layer
{
    public class XmlService : IXmlService
    {
        private IXmlRepository xmlRepo;

        public XmlService(IXmlRepository xmlRepository)
        {
            xmlRepo = xmlRepository;
        }


        public async Task SavePodFeedToXml(PodFeed pf)
        {
            await xmlRepo.SerializePodFeed(pf);
        }

        public async Task<PodFeed> LoadPodFeedFromXml()
        {
            return await xmlRepo.DeserializePodFeed();
        }
    }
}