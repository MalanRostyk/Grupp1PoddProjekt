using DDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCData_Access_Layer
{
    public interface IRepository<T>
    {
        Task AddAsync(T obj);
        Task<T?> GetAsync(string id);
        Task<T?> GetTempAsync();
        Task<List<T>> GetAllAsync();
        Task<bool> UpdateAsync(T obj);
        Task ChangeRecentlyAsync(T tempPf);
        Task DeleteAsync(string id);

    }
}
