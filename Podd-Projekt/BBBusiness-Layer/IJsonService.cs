using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace BBBusiness_Layer
{
    public interface IJsonService
    {
        Task SavePodFeedToJson(PodFeed pf);
        Task<PodFeed> LoadPodFeedFromJson();
    }
}
