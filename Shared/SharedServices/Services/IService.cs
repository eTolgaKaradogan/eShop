using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync(int page, int size);
        Task<TEntity> GetByIdAsync(int Id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int Id);
    }
}
