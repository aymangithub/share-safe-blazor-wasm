using AdminDashboard.Wasm.Models.ChattingMessage;
using Microsoft.AspNetCore.Components;

namespace FSH.BlazorWebAssembly.Client.Services;

public interface IChatComponentFactory
{
    RenderFragment CreateComponent(BasicMessageViewModel messageViewModel);
}

