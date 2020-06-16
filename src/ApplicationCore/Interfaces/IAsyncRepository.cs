﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
        //Expression<Func<T, bool>> predicate
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
        