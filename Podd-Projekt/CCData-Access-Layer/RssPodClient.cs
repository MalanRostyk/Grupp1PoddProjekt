using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Denna klass är till för att skapa c# objekt av flödet, dvs tolka flödet.

        public async Task<List<Pod>> GetAllPodsAsync(string link)
        {
            List<Pod> podList = new();

            //Stream stream = await httpClient.GetStreamAsync(link) = Hämtar stream från webben

            //XmlReader.Create(stream) = Formatera stremens data från Xml "språk" till något C# kan tolka

            //SyndicationFeed.Load(xmlReader) = Representerar tillfälligt data i minnet som
            //"Hela = SyncationFeed, dvs som en list", och varje "objekt = SyndicationItem"
            //Så sammasatt blir det som en List<SyndicationItem>

            try
            {
                using (Stream stream = await httpClient.GetStreamAsync(link))
                {
                    XmlReader xmlReader = XmlReader.Create(stream);
                    SyndicationFeed syndFeed = SyndicationFeed.Load(xmlReader);
                    foreach (SyndicationItem sItem in syndFeed.Items)
                    {
                        Pod newPod = new();
                        newPod.Id = sItem.Id;
                        newPod.Titel = sItem.Title.Text;
                        newPod.Description = sItem.Summary?.Text ?? "No info...";
                        newPod.PublishedDate = sItem.PublishDate;
                        newPod.Link = sItem.Links.First().Uri.ToString();
                        newPod.LinkRef = link;

                        podList.Add(newPod);
                    }
                }
            }catch(Exception e) { Debug.WriteLine(e.Message + "ENGINE E KAPUT!!!!"); }
            return podList;
        }
    }
}
