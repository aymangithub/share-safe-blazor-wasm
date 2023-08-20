using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.WebApi.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Entities;

public class TextMessageEntity : BaseMessageEntity
{
    public string Message { get; set; }
    public bool IsCopyable { get; set; }

}

public class ImageMessageEntity : BaseMessageEntity
{
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height{ get; set; }
    public int SizeInKB { get; set; }

}

public class AudioMessageEntity : BaseMessageEntity
{
    public string AudioUrl { get; set; }
    public int LengthInSeconds { get; set; }
}

public class FileMessageEntity : BaseMessageEntity
{
    public string FilePath { get; set; }
    public bool CanBeDownloaded { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int SizeInKB { get; set; }
    public string Extension { get; set; }

}

public class LocationMessageEntity : BaseMessageEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class BaseMessageEntity
{
    public long Id { get; set; }
    public int ConversationId { get; set; }
    public string MessageType { get; set; }
    public long Timestamp { get; set; }
    public string FromUserId { get; set; }
    public int ExpiryMinutes { get; set; }
    public int AllowedViewCount { get; set; }
}