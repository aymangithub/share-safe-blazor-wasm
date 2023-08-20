using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Services;
//public interface IServiceT<TDto>
//{
//    Task<IEnumerable<TDto>> GetAllAsync();
//    Task<TDto> GetAsync(int id);
//    Task<TDto> CreateAsync(TDto dto);
//    Task<TDto> UpdateAsync(TDto dto);
//    Task DeleteAsync(int id);
//}

//public class MessageService : IServiceT<BaseMessageDto>
//{
//    public Task<BaseMessageDto> CreateAsync(BaseMessageDto dto)
//    {
//        throw new NotImplementedException();
//    }

//    public Task DeleteAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<IEnumerable<BaseMessageDto>> GetAllAsync()
//    {
//        return Task.FromResult<IEnumerable<BaseMessageDto>>(new List<BaseMessageDto>() {
//        //new TextMessageDto(){CreatedDate=DateTime.Now,FromUserFullName="me",FromUserId="30106c2a-acb3-4b75-8550-8f6279af9567",FromUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal",Id=1,Message="Hi, how are you. please I want to check my bank account according to complete my university process", ToUserFullName="samak",ToUserId="1",ToUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal" },
//        //new TextMessageDto(){CreatedDate=DateTime.Now,FromUserFullName="partner",FromUserId="234346c2a-acb3-4b75-8550-8f6279af9534",FromUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal",Id=2,Message="Hi Ayman, can you please send me your location and your valid passport", ToUserFullName="ayman",ToUserId="2",ToUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal" },

//        //    new FileMessageDto(){CreatedDate=DateTime.Now,FromUserFullName="partner",FromUserId="30106c2a-acb3-4b75-8550-8f6279af9567",FromUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal",Id=2,Message="", ToUserFullName="ayman",ToUserId="2",ToUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal" },


//        //    new GeoMessageDto(){CreatedDate=DateTime.Now,FromUserFullName="partner",FromUserId="30106c2a-acb3-4b75-8550-8f6279af9567",FromUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal",Id=2,Message="Thanks ayman for sharing. let back to you after  seconds.", ToUserFullName="ayman",ToUserId="2",ToUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal" },
//        //    new ImageMessageDto(){CreatedDate=DateTime.Now,FromUserFullName="partner",FromUserId="30106c2a-acb3-4b75-8550-8f6279af9567",FromUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal",Id=2,Message="", ToUserFullName="ayman",ToUserId="2",ToUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal" },
//        //new TextMessageDto(){CreatedDate=DateTime.Now,FromUserFullName="partner",FromUserId="234346c2a-acb3-4b75-8550-8f6279af9534",FromUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal",Id=2,Message="Thanks ayman. i will back to you ", ToUserFullName="ayman",ToUserId="2",ToUserImageURL="https://graph.facebook.com/1234567890/picture?type=normal" },

//            //new ImageMessageDto(){ },
//    });




//    }

//    public Task<BaseMessageDto> GetAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<BaseMessageDto> UpdateAsync(BaseMessageDto dto)
//    {
//        throw new NotImplementedException();
//    }
//}

//public class VaultService : IServiceT<VaultDto>
//{

//    public Task<VaultDto> CreateAsync(VaultDto dto)
//    {
//        throw new NotImplementedException();
//    }

//    public Task DeleteAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<IEnumerable<VaultDto>> GetAllAsync()
//    {
//        return Task.FromResult<IEnumerable<VaultDto>>(new List<VaultDto>() {
//        new VaultDto(){EmailAddress="ahmedsamak@ssafe.com",FirstName="123 569 654",Id="1",IsOnline=true,LastName="",ProfilePictureDataUrl="https://cdn-icons-png.flaticon.com/128/6142/6142823.png",UserName="samak", CreatedDate= DateTime.Now },
//        new VaultDto(){EmailAddress="ayman@ssafe.com",FirstName="741 589 569",Id="2",IsOnline=false,LastName="",ProfilePictureDataUrl="https://cdn-icons-png.flaticon.com/128/684/684849.png",UserName="ayman", CreatedDate= DateTime.Now },
//        //new VaultDto(){ },

//    });
//    }

//    public Task<VaultDto> GetAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<VaultDto> UpdateAsync(VaultDto dto)
//    {
//        throw new NotImplementedException();
//    }
//}

