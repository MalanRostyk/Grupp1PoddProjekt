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
        Task<T?> GetOneAsync(string id);
        //R
        Task<List<T>> GetAllAsync();
        //U
        bool UpdateAsync(T obj);
        //D
        Task DeletAsync(string id);
    }
}
