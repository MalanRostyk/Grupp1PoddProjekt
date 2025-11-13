using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DDModels;

namespace CCData_Access_Layer
{
    public class FeedRepository
    {
        public List<SyndicationItem> nyaPods { get; private set; } = new();

        private readonly string path = "C:\\PodXml\\MyCurrent.xml";


        public FeedRepository() { }

        public async Task<SyndicationFeed> GetSyndicationFeed(string rssUrl)
        {
            XmlReader xmlReader = XmlReader.Create(rssUrl);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
            return syndicationFeed;
        }

        //public async Task SerialiseraFeed(string rssUrl)
        //{
        //    XmlSerializer xmlSer = new(typeof(SyndicationFeed));
        //    await using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

        //    await using var enWriter = XmlWriter.Create(fs, new XmlWriterSettings()
        //    {
        //        Indent = true
        //    });

        //    var formaterare = new Rss20FeedFormatter(await GetSyndicationFeed(rssUrl));
        //    formaterare.WriteTo(enWriter);
        //    await enWriter.FlushAsync();
        //}

        //public async Task SerialiseraFeed(string rssUrl)
        //{
        //    XmlSerializer xmlSer = new(typeof(SyndicationFeed));
        //    using (FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        xmlSer.Serialize(fs, await GetSyndicationFeed(rssUrl));
        //    }
        //}

        //public async Task AddSyndicationFeedToNyaPodsList()
        //{
        //    SyndicationFeed sFeed = GetSyndicationFeed();
        //    nyaPods.Add(sFeed.); //måste lägga till enstaka syndicationitems
        //}

        //public SyndicationFeed GetSyndicationFeed()//Kolla hur man gör asynkront!
        //{
        //    XmlReader xmlReader = XmlReader.Create("https://blog.spreaker.com/feed/");
        //    SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
        //    return syndicationFeed;
        //}

        //public async Task SerialiseraFeed(SyndicationFeed feed)
        //{
        //    XmlSerializer xmlSer = new(typeof(SyndicationItem)); //XmlSerialiser ska inte användas
        //    using (FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        await xmlSer.Serialize(fs, );
        //    }
        //}
    }
}
