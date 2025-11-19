using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace CCData_Access_Layer
{
    public interface IXmlRepository
    {
        Task SerializePodFeed(PodFeed pf);
        Task<PodFeed> DeserializePodFeed();
    }
}
