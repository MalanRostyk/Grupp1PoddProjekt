using DDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public interface IService
    {
        Task<List<Pod>> ReadAllPodAsync(string link);
    }
}
