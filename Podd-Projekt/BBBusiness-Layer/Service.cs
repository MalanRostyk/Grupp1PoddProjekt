using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCData_Access_Layer;
using DDModels;

namespace BBBusiness_Layer
{
    public class Service : IService
    {
        private RssPodClient podClient;

        public Service(RssPodClient client)
        {
            podClient = client;
        }


        public async Task<List<Pod>> ReadAllPodAsync(PodFeed pf) 
        {
            List<Pod> podList = await podClient.GetAllPodsAsync(pf.Link);
            foreach(var pod in podList)
            {
                pod.LinkRef = pf.Id;
                pod.Id = $"{pod.Link} tillhör {pf.Id}";//"Serien" som "episoden" tillhör, metaforsikt
                //Så vi vet vilkent feed podden tillhör
            }

            return podList;
        }
    }
}
