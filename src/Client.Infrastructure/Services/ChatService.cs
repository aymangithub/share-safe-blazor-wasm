using AutoMapper;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Entities;
using FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Services;

public interface IChatService : IService<BaseMessageDto, int>
{
    Task<IEnumerable<BaseMessageDto>> GetConversationMessages(int conversationid);
}

public class ChatService : Service<BaseMessageEntity, BaseMessageDto, int>, IChatService
{
    private readonly IChatMessageRepository repository;

    public ChatService(IChatMessageRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
        this.repository = repository;
        Mapper = mapper;
    }

    public IMapper Mapper { get; }

    public async Task<IEnumerable<BaseMessageDto>> GetConversationMessages(int conversationid)
    {
        var messageEntities = await repository.GetConversationMessages(conversationid);

        var dtos = messageEntities.Select(messageDto => Mapper.Map<BaseMessageDto>(messageDto)).ToList();


        return dtos;
    }
}
