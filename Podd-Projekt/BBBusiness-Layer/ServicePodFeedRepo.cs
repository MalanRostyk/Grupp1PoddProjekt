using DDModels;
using CCData_Access_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public class ServicePodFeedRepo: IServicePodFeedRepo
    {
        private readonly IRepository<Pod> podRepo;

        public ServicePodFeedRepo(IRepository<Pod> podRepo)
        {
            this.podRepo = podRepo;
        }


        public void AddOnePod(Pod pod)
        {
            if(pod != null)
            {
                podRepo.AddAsync(pod);
            }
        }
        public Pod? GetOnePod(string id)
        {
            return podRepo.GetOneAsync(id).Result;
        }

        public List<Pod> GetAllPods()
        {
            List<Pod> list = new List<Pod>();
            List<Pod> pods = podRepo.GetAllAsync().Result;

            int i = 0;
            while (i < pods.Count)
            {
                list.Add(pods[i]);
                i++;
            }

            return pods;
        }

        public bool UpdateOnePod(Pod pod)
        {
            if(pod == null) return false;
           
            return podRepo.UpdateAsync(pod).Result;
        }

        public void DeleteOnePod(string id)
        {
            podRepo.DeletAsync(id);
        }   
    }
}
