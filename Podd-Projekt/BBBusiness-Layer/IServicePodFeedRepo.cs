using DDModels;
using CCData_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
     public interface IServicePodFeedRepo
    {
        void AddOnePod(Pod pod);

        Pod? GetOnePod(string id);

        List<Pod> GetAllPods();

        bool UpdateOnePod(Pod pod);

        void DeleteOnePod(string id);

    }
}
