using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DDModels;

namespace CCData_Access_Layer
{
    public class RssPodClient
    {
        private HttpClient httpClient;

        public RssPodClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Pod>> GetAllPodsAsync(string link)
        {
            Stream stream = await this.httpClient.GetStreamAsync(link);
            XmlReader xmlReader = XmlReader.Create(stream);
            SyndicationFeed syndFeed = SyndicationFeed.Load(xmlReader);
            xmlReader.Dispose();
            stream.Dispose();

            List<Pod> podList = new();

            foreach(SyndicationItem sItem in syndFeed.Items)
            {
                Pod newPod = new();
                newPod.Id = sItem.Id;
                newPod.Titel = sItem.Title.Text;
                newPod.Link = sItem.Links.First().Uri.ToString();

                podList.Add(newPod);
            }

            return podList;
        }
    }
}
