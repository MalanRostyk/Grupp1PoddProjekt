using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;
using System.IO;
using System.Xml.Serialization; 

namespace CCData_Access_Layer
{

    public class XmlRepository : IXmlRepository
    {
        public PodFeed pf;
        public XmlRepository(PodFeed pf)
        {
            this.pf = pf;
        }

        public async Task SerializePodFeed(PodFeed pf)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PodFeed));
            await using FileStream fs = new FileStream("podfeed.xml", FileMode.Create, FileAccess.Write);
            serializer.Serialize(fs, pf);
        }

        public async Task<PodFeed> DeserializePodFeed()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PodFeed));
            await using FileStream fs = new FileStream("podfeed.xml", FileMode.Open, FileAccess.Read);
            return (PodFeed)serializer.Deserialize(fs);
        }
    }
}
