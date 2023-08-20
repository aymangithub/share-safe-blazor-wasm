using FSH.BlazorWebAssembly.Client.Models.ChattingMessage;
using FSH.WebApi.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
public class FileMessageDto : BaseMessageDto
{
    public string FilePath { get; set; }
    public bool CanBeDownloaded { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int SizeInKB { get; set; }
    public string Extension { get; set; }

}

