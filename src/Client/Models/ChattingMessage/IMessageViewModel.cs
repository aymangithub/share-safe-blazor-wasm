using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.WebApi.Shared.Enums;

namespace AdminDashboard.Wasm.Models.ChattingMessage;

public interface IMessageViewModel
{
    public long Id { get; set; }
    public int ConversationId { get; set; }
    public string MessageType { get; set; }
    public long Timestamp { get; set; }
    public string FromUserId { get; set; }
    public int ExpiryMinutes { get; set; }
    public int AllowedViewCount { get; set; }
}


