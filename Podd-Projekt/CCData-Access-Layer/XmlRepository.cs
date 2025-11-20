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
        private readonly string Path = @"..\..\..\..\CCData-Access-Layer\podfeed.xml";
        public XmlRepository() { }

        public async Task SerializePodFeed(PodFeed pf)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PodFeed));
            await using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);
            serializer.Serialize(fs, pf);
        }

        public async Task<PodFeed> DeserializePodFeed()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PodFeed));
            await using FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
            return (PodFeed)serializer.Deserialize(fs);
        }
    }
}