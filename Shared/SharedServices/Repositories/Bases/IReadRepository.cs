﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.Repositories.Bases
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        bool IsExist(Expression<Func<T, bool>> expression, bool tracking = true);
    }
}
