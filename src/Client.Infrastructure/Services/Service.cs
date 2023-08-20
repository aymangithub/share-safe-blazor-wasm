using AutoMapper;
using FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Services;
public class Service<TEntity, TEntityDto, TKey> : IService<TEntityDto, TKey>
    where TEntity : class
    where TEntityDto : class
{
    private readonly IRepository<TEntity, TKey> _repository;
    private readonly IMapper _mapper;

    public Service(IRepository<TEntity, TKey> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TEntityDto> GetAsync(TKey id)
    {
        var entity = await _repository.GetAsync(id);

        var dd = _mapper.Map<TEntityDto>(entity);
        return dd;


    }

    public async Task AddAsync(TEntityDto entityDto)
    {
        var entity = _mapper.Map<TEntity>(entityDto);
        await _repository.AddAsync(entity);

    }

    public async Task<IEnumerable<TEntityDto>> GetAllAsync()
    {
        var enitityList = await _repository.GetAllAsync();
        enitityList.Select(entity => _mapper.Map<TEntityDto>(entity)).ToList();
        return _mapper.Map<List<TEntityDto>>(enitityList);
    }
}