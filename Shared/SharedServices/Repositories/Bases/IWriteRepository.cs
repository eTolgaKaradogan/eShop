﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.Repositories.Bases
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        bool RemoveRange(List<T> model);
        Task<bool> Remove(int id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
