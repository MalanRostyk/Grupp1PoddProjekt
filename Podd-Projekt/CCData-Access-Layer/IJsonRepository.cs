using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace CCData_Access_Layer
{
    public interface IJsonRepository
    {
        Task SerializePodFeedJson(PodFeed pf);
        Task<PodFeed> DeserializePodFeedJson();
    }
}
