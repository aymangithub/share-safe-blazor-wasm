using FSH.BlazorWebAssembly.Client.Models.ChattingMessage;
using FSH.WebApi.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Wasm.Models.ChattingMessage;
public class ImageMessageViewModel : BasicMessageViewModel
{
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int SizeInKB { get; set; }
}

