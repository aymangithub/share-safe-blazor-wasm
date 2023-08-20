using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;
public interface IRepository<TEntity, TKey>
    where TEntity : class

{
    Task AddAsync(TEntity item);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task DeleteAsync(TKey id);
    Task<TEntity> GetAsync(TKey id);

}
