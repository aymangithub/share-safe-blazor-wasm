﻿using FSH.BlazorWebAssembly.Client.Models.ChattingMessage;
using FSH.WebApi.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
public class AudioMessageDto : BaseMessageDto
{
    public string AudioUrl { get; set; }
    public int LengthInSeconds { get; set; }
}

