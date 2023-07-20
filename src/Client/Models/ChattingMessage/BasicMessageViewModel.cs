using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.BlazorWebAssembly.Client.Models.ChattingMessage;
using FSH.WebApi.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Wasm.Models.ChattingMessage;
public class BasicMessageViewModel : IMessageViewModel
{

    public MessageType MessageType { get; set; }
    public VaultDto Vault { get; set; }
    public long Id { get; set; }
    public string FromUserId { get; set; }
    public string FromUserImageURL { get; set; }
    public string FromUserFullName { get; set; }
    public string ToUserId { get; set; }
    public string ToUserImageURL { get; set; }
    public string ToUserFullName { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    


}

