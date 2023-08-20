

using FSH.BlazorWebAssembly.Client.Infrastructure.Dto;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.BlazorWebAssembly.Client.Infrastructure.Entities;
using global::AutoMapper;
namespace FSH.BlazorWebAssembly.Client.Infrastructure.AutoMapper;

public class MappingProfile
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {


            CreateMap<BaseMessageEntity, BaseMessageDto>()
           .Include<TextMessageEntity, TextMessageDto>()
           .Include<FileMessageEntity, FileMessageDto>()
           .Include<ImageMessageEntity, ImageMessageDto>()
           .Include<LocationMessageEntity, GeoMessageDto>()
           .Include<AudioMessageEntity, AudioMessageDto>();


            CreateMap<BaseMessageEntity, BaseMessageDto>();
            CreateMap<TextMessageEntity, TextMessageDto>();
            CreateMap<FileMessageEntity, FileMessageDto>();
            CreateMap<ImageMessageEntity, ImageMessageDto>();
            CreateMap<LocationMessageEntity, GeoMessageDto>();
            CreateMap<AudioMessageEntity, AudioMessageDto>();


            CreateMap<BaseMessageDto, BaseMessageEntity>()
    .Include<TextMessageDto, TextMessageEntity>()
    .Include<FileMessageDto, FileMessageEntity>()
    .Include<ImageMessageDto, ImageMessageEntity>()
    .Include<GeoMessageDto, LocationMessageEntity>()
    .Include<AudioMessageDto, AudioMessageEntity>();

            CreateMap<TextMessageDto, TextMessageEntity>();
            CreateMap<FileMessageDto, FileMessageEntity>();
            CreateMap<ImageMessageDto, ImageMessageEntity>();
            CreateMap<GeoMessageDto, LocationMessageEntity>();
            CreateMap<AudioMessageDto, AudioMessageEntity>();


        }
    }

    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<BaseConversationEntity, BaseConversationDto>()
          .Include<ConversationEntity, ConversationDto>();


            CreateMap<BaseConversationEntity, BaseConversationDto>();
            CreateMap<ConversationEntity, ConversationDto>();


        }
    }

}

