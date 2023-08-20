using FSH.BlazorWebAssembly.Client.Infrastructure.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;

public interface IConversationRepository : IRepository<BaseConversationEntity, int>
{

}
public class ConversationRepository : Repository<BaseConversationEntity, int>, IConversationRepository
{
    public ConversationRepository(IJSRuntime jsRuntime, string storeName)
        : base(jsRuntime, storeName)
    {
    }
}