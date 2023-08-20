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

    public long Id { get; set; }
    public int ConversationId { get; set; }
    public string MessageType { get; set; }
    public long Timestamp { get; set; }
    public DateTime CreatedDate { get; set; }
    public string FromUserId { get; set; }
    public int ExpiryMinutes { get; set; }
    public int AllowedViewCount { get; set; }



}

