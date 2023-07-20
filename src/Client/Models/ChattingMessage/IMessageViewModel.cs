using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.WebApi.Shared.Enums;

namespace AdminDashboard.Wasm.Models.ChattingMessage;

public interface IMessageViewModel
{
    public long Id { get; set; }
    public string FromUserId { get; set; }
    public string FromUserImageURL { get; set; }
    public string FromUserFullName { get; set; }
    public string ToUserId { get; set; }
    public string ToUserImageURL { get; set; }
    public string ToUserFullName { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public MessageType MessageType { get; set; }
    public VaultDto Vault { get; set; }
}


