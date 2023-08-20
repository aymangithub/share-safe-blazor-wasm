//using BlazorHero.CleanArchitecture.Application.Models.Chat;
//using BlazorHero.CleanArchitecture.Application.Responses.Identity;
//using BlazorHero.CleanArchitecture.Client.Extensions;
//using BlazorHero.CleanArchitecture.Shared.Constants.Application;
using AdminDashboard.Wasm.Models;
using AdminDashboard.Wasm.Models.ChattingMessage;
using AdminDashboard.Wasm.Models.Vault;
using AdminDashboard.Wasm.ModelsAdminDashboard.Wasm.Models;
using AutoMapper;
using FSH.BlazorWebAssembly.Client.Components.Dialogs;
using FSH.BlazorWebAssembly.Client.Components.Dialogs.Custom;
using FSH.BlazorWebAssembly.Client.Infrastructure.ApiClient;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
using FSH.BlazorWebAssembly.Client.Infrastructure.Services;
using FSH.BlazorWebAssembly.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using BlazorHero.CleanArchitecture.Application.Interfaces.Chat;
//using BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Communication;
//using BlazorHero.CleanArchitecture.Shared.Constants.Storage;

namespace FSH.BlazorWebAssembly.Client.Pages.Communication;


public partial class Chat
{
    //[Inject]
    //private IServiceT<VaultDto> VaultService { get; set; }
    //[Inject]
    //private IServiceT<BaseMessageDto> MessageService { get; set; }
    [Inject]


    public IMapper Mapper { get; set; }
    [Inject]
    private IChatService ChatService { get; set; }
    //[Inject]
    //private IConversationService ConversationService { get; set; }

    private Timer _timer;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _timer = new Timer(SomeOneJoined, null, 5000, Timeout.Infinite);
        }
    }
    private DotNetObjectReference<Chat> dotNetReference;

    public void Dispose()
    {
        _timer?.Dispose();
        dotNetReference?.Dispose();
    }

    private List<BasicMessageViewModel> _messagesViewModels = new List<BasicMessageViewModel>();
    private List<BaseConversationViewModel> baseConversationViewModels = new List<BaseConversationViewModel>();


    public List<VaultViewModel> _vaultList = new List<VaultViewModel>();

    [Parameter] public string CFullName { get; set; }
    [Parameter] public string CId { get; set; } = "1";
    [Parameter] public string CUserName { get; set; }
    [Parameter] public string CImageURL { get; set; }


    private Color GetUserStatusBadgeColor(bool isOnline)
    {
        switch (isOnline)
        {
            case false:
                return Color.Error;
            case true:
                return Color.Success;
        }
    }

    //[Inject] private IChatManager ChatManager { get; set; }

    [CascadingParameter] private HubConnection HubConnection { get; set; }
    [Parameter] public string CurrentMessage { get; set; }
    [Parameter] public string CurrentUserId { get; set; }
    [Parameter] public string CurrentUserImageURL { get; set; }




    //private async Task SubmitAsync()
    //{
    //    if (!string.IsNullOrEmpty(CurrentMessage) && !string.IsNullOrEmpty(CId))
    //    {
    //        //Save Message to DB
    //        var chatHistory = new ChatHistory<IChatUser>
    //        {
    //            Message = CurrentMessage,
    //            ToUserId = CId,
    //            CreatedDate = DateTime.Now
    //        };
    //        var response = await ChatManager.SaveMessageAsync(chatHistory);
    //        if (response.Succeeded)
    //        {
    //            var state = await _stateProvider.GetAuthenticationStateAsync();
    //            var user = state.User;
    //            CurrentUserId = user.GetUserId();
    //            chatHistory.FromUserId = CurrentUserId;
    //            var userName = $"{user.GetFirstName()} {user.GetLastName()}";
    //            await HubConnection.SendAsync(ApplicationConstants.SignalR.SendMessage, chatHistory, userName);
    //            CurrentMessage = string.Empty;
    //        }
    //        else
    //        {
    //            foreach (var message in response.Messages)
    //            {
    //                _snackBar.Add(message, Severity.Error);
    //            }
    //        }
    //    }
    //}
    private bool IsDrawerOpen;
    private async Task OnKeyPressInChat(KeyboardEventArgs e)
    {
        //if (e.Key == "Enter")
        //{
        //    await SubmitAsync();
        //}
    }
    public async Task DeleteChat()
    {
        var parameters = new DialogParameters
        {
            { nameof(Confirmation.ContentText), "this will delete vault from your device. Are you sure ?" },
            { nameof(Confirmation.Title), "Deleting vault" }

        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
        var dialog = DialogService.Show<Confirmation>(L["Deleting Value"], parameters, options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            //_profileModel.DeleteCurrentImage = true;
            //await UpdateProfileAsync();
        }
    }
    public async Task LeaveChat()
    {
        var parameters = new DialogParameters
        {
            { nameof(Confirmation.ContentText), "this will leave vault from your device. Are you sure ?" },
            { nameof(Confirmation.Title), "Leaving vault" }

        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
        var dialog = DialogService.Show<Confirmation>(L["Leaving Value"], parameters, options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            //_profileModel.DeleteCurrentImage = true;
            //await UpdateProfileAsync();
        }
    }
    public async Task GenerateQR()
    {
        var parameters = new DialogParameters
        {
            { nameof(QRGeneration.ContentText), "Your partner can join by scanning this qr image" },
            { nameof(QRGeneration.Title), "Chat QR Code" }

        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
        var dialog = DialogService.Show<QRGeneration>(L["Qr Code"], parameters, options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            //_profileModel.DeleteCurrentImage = true;
            //await UpdateProfileAsync();
        }
    }
    public async Task ShowSettingsDialog()
    {
        var parameters = new DialogParameters
        {
            { nameof(Confirmation.ContentText), "Here you can change all your chat settings." },
            { nameof(Confirmation.Title), "Closing vault" }

        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
        var dialog = DialogService.Show<ChatSettings>(L["Closing Value"], parameters, options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            Snackbar.Add($"Custom chat settings saves successfully.", Severity.Success);
        }
    }
    public void CopyCode()
    {
        Snackbar.Add($"Chat code copied to clipboard", Severity.Info);

    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("initializeScrollCheck", dotNetReference);
            //await JSRuntime.InvokeVoidAsync("initializeMap", "map", 37.7749, -122.4194, 10);
        }
        await base.OnAfterRenderAsync(firstRender);
    }




    private bool showFab = true;
    [JSInvokable("UpdateShowFab")]
    public async Task UpdateShowFab()
    {
        showFab = !(await JSRuntime.InvokeAsync<bool>("isScrollAtBottom"));
        StateHasChanged();
    }


    public async Task SendTxtMessageAsync()
    {
        await JSRuntime.InvokeVoidAsync("scrollToBottom");
        await SoundService.PlaySoundAsync(SoundEventTypes.MessageSent);

        await ChatService.AddAsync(new TextMessageDto
        {
            Id = 1,
            ConversationId = 1, // Assuming 'id' is defined elsewhere in your code
            Message = "Hello, this is your bank. How may I assist you today?",
            Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(), // Assuming you're using a compatible date type
            IsCopyable = true,
            MessageType = "text",
            FromUserId = "30106c2a-acb3-4b75-8550-8f6279af9567",
            ExpiryMinutes = 30,
            AllowedViewCount = 5
        }
);

    }
    public async Task ScrollBottom()
    {
        await JSRuntime.InvokeVoidAsync("scrollToBottom");
    }
    protected override async Task OnInitializedAsync()
    {
        //var vaultDtoList = await VaultService.GetAllAsync();
        //var messagesDtoList = await MessageService.GetAllAsync();
        var messagesDtoList = await ChatService.GetConversationMessages(1);
       // MapData(vaultDtoList);

        _messagesViewModels = messagesDtoList.Select(messageDto => Mapper.Map<BasicMessageViewModel>(messageDto)).ToList();

        //var list = await ConversationService.GetAllAsync();

    }

    private void MapData(IEnumerable<VaultDto> vaultDtos)
    {
        _vaultList = Mapper.Map<List<VaultViewModel>>(vaultDtos);

        //_messagesViewModels = messageDtos.Select(messageDto => Mapper.Map<BasicMessageViewModel>(messageDto)).ToList();


    }
    //protected override async Task OnInitializedAsync()
    //{
    //    HubConnection = HubConnection.TryInitialize(_navigationManager, _localStorage);
    //    if (HubConnection.State == HubConnectionState.Disconnected)
    //    {
    //        await HubConnection.StartAsync();
    //    }
    //    HubConnection.On<string>(ApplicationConstants.SignalR.PingResponse, (userId) =>
    //    {
    //        var connectedUser = UserList.Find(x => x.Id.Equals(userId));
    //        if (connectedUser is { IsOnline: false })
    //        {
    //            connectedUser.IsOnline = true;
    //            //_snackBar.Add($"{connectedUser.UserName} {_localizer["Logged In."]}", Severity.Info);
    //            StateHasChanged();
    //        }
    //    });
    //    HubConnection.On<string>(ApplicationConstants.SignalR.ConnectUser, (userId) =>
    //    {
    //        var connectedUser = UserList.Find(x => x.Id.Equals(userId));
    //        if (connectedUser is {IsOnline: false})
    //        {
    //            connectedUser.IsOnline = true;
    //            _snackBar.Add($"{connectedUser.UserName} {_localizer["Logged In."]}", Severity.Info);
    //            StateHasChanged();
    //        }
    //    });
    //    HubConnection.On<string>(ApplicationConstants.SignalR.DisconnectUser, (userId) =>
    //    {
    //        var disconnectedUser = UserList.Find(x => x.Id.Equals(userId));
    //        if (disconnectedUser is {IsOnline: true})
    //        {
    //            disconnectedUser.IsOnline = false;
    //            _snackBar.Add($"{disconnectedUser.UserName} {_localizer["Logged Out."]}", Severity.Info);
    //            StateHasChanged();
    //        }
    //    });
    //    HubConnection.On<ChatHistory<IChatUser>, string>(ApplicationConstants.SignalR.ReceiveMessage, async (chatHistory, userName) =>
    //     {
    //         if ((CId == chatHistory.ToUserId && CurrentUserId == chatHistory.FromUserId) || (CId == chatHistory.FromUserId && CurrentUserId == chatHistory.ToUserId))
    //         {
    //             if ((CId == chatHistory.ToUserId && CurrentUserId == chatHistory.FromUserId))
    //             {
    //                 _messages.Add(new ChatHistoryResponse { Message = chatHistory.Message, FromUserFullName = userName, CreatedDate = chatHistory.CreatedDate, FromUserImageURL = CurrentUserImageURL });
    //                 await HubConnection.SendAsync(ApplicationConstants.SignalR.SendChatNotification, string.Format(_localizer["New Message From {0}"], userName), CId, CurrentUserId);
    //             }
    //             else if ((CId == chatHistory.FromUserId && CurrentUserId == chatHistory.ToUserId))
    //             {
    //                 _messages.Add(new ChatHistoryResponse { Message = chatHistory.Message, FromUserFullName = userName, CreatedDate = chatHistory.CreatedDate, FromUserImageURL = CImageURL });
    //             }
    //             await _jsRuntime.InvokeAsync<string>("ScrollToBottom", "chatContainer");
    //             StateHasChanged();
    //         }
    //     });
    //    await GetUsersAsync();
    //    var state = await _stateProvider.GetAuthenticationStateAsync();
    //    var user = state.User;
    //    CurrentUserId = user.GetUserId();
    //    CurrentUserImageURL = await _localStorage.GetItemAsync<string>(StorageConstants.Local.UserImageURL);
    //    if (!string.IsNullOrEmpty(CId))
    //    {
    //        await LoadUserChat(CId);
    //    }

    //    await HubConnection.SendAsync(ApplicationConstants.SignalR.PingRequest, CurrentUserId);
    //}



    //private async Task LoadUserChat(string userId)
    //{
    //    _open = false;
    //    var response = await _userManager.GetAsync(userId);
    //    if (response.Succeeded)
    //    {
    //        var contact = response.Data;
    //        CId = contact.Id;
    //        CFullName = $"{contact.FirstName} {contact.LastName}";
    //        CUserName = contact.UserName;
    //        CImageURL = contact.ProfilePictureDataUrl;
    //        _navigationManager.NavigateTo($"chat/{CId}");
    //        //Load messages from db here
    //        _messages = new List<ChatHistoryResponse>();
    //        var historyResponse = await ChatManager.GetChatHistoryAsync(CId);
    //        if (historyResponse.Succeeded)
    //        {
    //            _messages = historyResponse.Data.ToList();
    //        }
    //        else
    //        {
    //            foreach (var message in historyResponse.Messages)
    //            {
    //                _snackBar.Add(message, Severity.Error);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        foreach (var message in response.Messages)
    //        {
    //            _snackBar.Add(message, Severity.Error);
    //        }
    //    }
    //}

    //private async Task GetUsersAsync()
    //{
    //    //add get chat history from chat controller / manager
    //    var response = await ChatManager.GetChatUsersAsync();
    //    if (response.Succeeded)
    //    {
    //        UserList = response.Data.ToList();
    //    }
    //    else
    //    {
    //        foreach (var message in response.Messages)
    //        {
    //            _snackBar.Add(message, Severity.Error);
    //        }
    //    }
    //}

    private bool _open;
    private Anchor ChatDrawer { get; set; }

    private void OpenDrawer(Anchor anchor)
    {
        ChatDrawer = anchor;
        _open = true;
    }

    private async void SomeOneJoined(object state)
    {
        string textContent = L["Please enter the partnet join code."];
        var parameters = new DialogParameters();

        parameters.Add(nameof(AdmitJoinRequest.ContentText), textContent);


        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };

        var dialog = DialogService.Show<AdmitJoinRequest>(L["AdmitJoinRequest"], parameters, options);
        var result = await dialog.Result;


    }


}
