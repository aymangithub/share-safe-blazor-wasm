
using AdminDashboard.Wasm.Models.ChattingMessage;
using AdminDashboard.Wasm.Models.Vault;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.BlazorWebAssembly.Client.Models;
using global::AutoMapper;
namespace FSH.BlazorWebAssembly.Client.AutoMapper;

public class MappingProfile
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {


            CreateMap<BaseMessageDto, BasicMessageViewModel>()
           .Include<TextMessageDto, TextMessageViewModel>()
           .Include<FileMessageDto, FileMessageViewModel>()
           .Include<ImageMessageDto, ImageMessageViewModel>()
           .Include<GeoMessageDto, GeoMessageViewModel>()
           .Include<AudioMessageDto, AudioMessageViewModel>();


            CreateMap<BaseMessageDto, BasicMessageViewModel>()
                    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeMilliseconds(src.Timestamp).DateTime));
            ;
            CreateMap<TextMessageDto, TextMessageViewModel>();
            CreateMap<FileMessageDto, FileMessageViewModel>();
            CreateMap<ImageMessageDto, ImageMessageViewModel>();
            CreateMap<GeoMessageDto, GeoMessageViewModel>();
            CreateMap<AudioMessageDto, AudioMessageViewModel>();



        }
    }

    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<VaultDto, VaultViewModel>();

            CreateMap<BaseConversationDto, BaseConversationViewModel>()
           .Include<ConversationDto, ConversationViewModel>();

            CreateMap<BaseConversationDto, BaseConversationViewModel>()
                    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeMilliseconds(src.Timestamp).DateTime));
            CreateMap<ConversationDto, ConversationViewModel>();




        }
    }

}

