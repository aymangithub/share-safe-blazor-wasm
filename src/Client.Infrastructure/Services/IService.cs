using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Services;
public interface IService<TEntityDto, TKey>
    where TEntityDto : class
{
    Task<TEntityDto> GetAsync(TKey id);
    Task AddAsync(TEntityDto entityDto);
    Task<IEnumerable<TEntityDto>> GetAllAsync();

}
