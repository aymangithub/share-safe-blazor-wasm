
using AdminDashboard.Wasm.Models.ChattingMessage;
using AdminDashboard.Wasm.Models.Vault;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using global::AutoMapper;
namespace FSH.BlazorWebAssembly.Client.AutoMapper;

public class MappingProfile
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
           

            CreateMap<BasicMessageDto, BasicMessageViewModel>()
           .Include<TextMessageDto, TextMessageViewModel>()
           .Include<FileMessageDto, FileMessageViewModel>()
           .Include<ImageMessageDto, ImageMessageViewModel>()
           .Include<GeoMessageDto, GeoMessageViewModel>();


            // add other Include lines for each subclass mapping

            CreateMap<BasicMessageDto, BasicMessageViewModel>();
            CreateMap<TextMessageDto, TextMessageViewModel>();
            CreateMap<FileMessageDto, FileMessageViewModel>();
            CreateMap<ImageMessageDto, ImageMessageViewModel>();
            CreateMap<GeoMessageDto, GeoMessageViewModel>();


        }
    }

    public class VaultProfile : Profile
    {
        public VaultProfile()
        {
            CreateMap<VaultDto, VaultViewModel>();

        }
    }

}

