﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.IApiProviders
{
    /// <summary>
    ///     Define generic contract of the external Insurance providers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiProvider<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task AddAsync(T t);
    }
}