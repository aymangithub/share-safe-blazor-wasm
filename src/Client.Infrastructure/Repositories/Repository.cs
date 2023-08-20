using FSH.BlazorWebAssembly.Client.Infrastructure.Converter;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;
public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{
    public readonly IJSRuntime _jsRuntime;
    private readonly string _storeName;
    public Repository(IJSRuntime jsRuntime, string storeName)
    {
        _jsRuntime = jsRuntime;
        _storeName = storeName;
    }
    public async Task AddAsync(TEntity item)
    {
        await _jsRuntime.InvokeVoidAsync("dexieService.addItem", _storeName, item);
    }

    public async Task DeleteAsync(TKey id)
    {
        await _jsRuntime.InvokeVoidAsync("dexieService.deleteItem", _storeName, id);

    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _jsRuntime.InvokeAsync<IEnumerable<TEntity>>("dexieService.getAllItems", _storeName);


        //var entitiesJson = await _jsRuntime.InvokeAsync<string>("dexieService.getAllItems");

        //var settings = new JsonSerializerSettings();
        //settings.Converters.Add(new MessageJsonConverter());

        //var messageEntities = JsonConvert.DeserializeObject<List<TEntity>>(entitiesJson, settings);

        //return messageEntities;
    }

    public async Task<TEntity> GetAsync(TKey id)
    {
        return await _jsRuntime.InvokeAsync<TEntity>("dexie.getItem", _storeName, id);



    }
}
