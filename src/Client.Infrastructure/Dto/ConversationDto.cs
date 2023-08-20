using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Dto;

public class BaseConversationDto
{
    public long Id { get; set; }
    public long Timestamp { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public bool Deleted { get; set; }
}
public class ConversationDto : BaseConversationDto
{
}