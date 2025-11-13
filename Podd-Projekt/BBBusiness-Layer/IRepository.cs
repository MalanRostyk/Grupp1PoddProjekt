using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBusiness_Layer
{
    public interface IRepository<T>
    {
        //C
        Task AddAsync(T obj);
        //R
        Task<T?> GetOneAsync(string id);// SKA BORT
        //R
        Task<List<T>> GetAllAsync();
        //U
        Task<bool> UpdateAsync(T obj);
        //D
        Task DeleteAsync(string id);
    }
}
