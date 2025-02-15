﻿using FSH.BlazorWebAssembly.Client.Models.ChattingMessage;
using FSH.WebApi.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Wasm.Models.ChattingMessage;
public class TextMessageViewModel : BasicMessageViewModel
{
    public string Message { get; set; }
    public bool IsCopyable { get; set; }
}