using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using AdminDashboard.Wasm.Models.ChattingMessage;

namespace FSH.BlazorWebAssembly.Client.Components.Chatting.ChatMessages;

public class BaseMessageComponent<TMessage> : ComponentBase
    where TMessage : BasicMessageViewModel
{
    [Parameter]
    public TMessage Message { get; set; }

    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    public bool IsUserMessage { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadUserData();
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
    }

    protected async Task LoadUserData()
    {
        var user = (await AuthState).User;

        if (user.Identity?.IsAuthenticated == true)
        {

            IsUserMessage = user.GetUserId() == Message.FromUserId;
        }
    }
}

