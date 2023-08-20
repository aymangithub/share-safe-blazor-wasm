using AutoMapper;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Entities;
using FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Services;
public interface IConversationService : IService<BaseConversationDto, int>
{

}
public class ConversationService : Service<BaseConversationEntity, BaseConversationDto, int>, IConversationService
{
    public ConversationService(IConversationRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}

