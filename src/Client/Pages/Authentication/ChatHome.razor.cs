using FSH.BlazorWebAssembly.Client.Components.Common;
using FSH.BlazorWebAssembly.Client.Components.Dialogs;
using FSH.BlazorWebAssembly.Client.Components.EntityTable;
using FSH.BlazorWebAssembly.Client.Infrastructure.ApiClient;
using FSH.BlazorWebAssembly.Client.Infrastructure.Auth;
using FSH.BlazorWebAssembly.Client.Shared;
using FSH.WebApi.Shared.Multitenancy;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Extensions;
using System;

namespace FSH.BlazorWebAssembly.Client.Pages.Authentication;

public partial class ChatHome
{
    [CascadingParameter]
    public Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    public IAuthenticationService AuthService { get; set; } = default!;
    [Inject]
    public IJSRuntime JSRuntime { get; set; }
    private CustomValidation? _customValidation;

    public bool BusySubmitting { get; set; }
    public bool Joining { get; set; }
    public bool IsThereSubmitting
    {
        get
        {
            return Joining || BusySubmitting;
        }
    }

    private readonly TokenRequest _tokenRequest = new()
    {
        Email = "ayman.sharkawy609@gmail.com",
        Password = "123Pa$$word!"

    };
    private string TenantId { get; set; } = "root";
    private bool _passwordVisibility;
    private InputType _passwordInput = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    protected override async Task OnInitializedAsync()
    {
        if (AuthService.ProviderType == AuthProvider.AzureAd)
        {
            AuthService.NavigateToExternalLogin(Navigation.Uri);
            return;
        }

        var authState = await AuthState;
        if (authState.User.Identity?.IsAuthenticated is true)
        {
            Navigation.NavigateTo("/");
        }
    }

    private void TogglePasswordVisibility()
    {
        if (_passwordVisibility)
        {
            _passwordVisibility = false;
            _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
            _passwordInput = InputType.Password;
        }
        else
        {
            _passwordVisibility = true;
            _passwordInputIcon = Icons.Material.Filled.Visibility;
            _passwordInput = InputType.Text;
        }
    }

    private void FillAdministratorCredentials()
    {
        _tokenRequest.Email = MultitenancyConstants.Root.EmailAddress;
        _tokenRequest.Password = MultitenancyConstants.DefaultPassword;
        TenantId = MultitenancyConstants.Root.Id;
    }

    private async Task SubmitAsync()
    {
        BusySubmitting = true;
        await Task.Delay(2000);
        BusySubmitting = false;
        await LoginAsync();
        Navigation.NavigateTo("/chat");
        await SoundService.PlaySoundAsync(SoundEventTypes.NewVaultCreated);

    }
    public async Task JoinChat()
    {
        string deleteContent = L["Please enter the code from the chat owner."];
        var parameters = new DialogParameters();

        parameters.Add(nameof(JoinChatConfirmation.ContentText), deleteContent);


        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };

        var dialog = DialogService.Show<JoinChatConfirmation>(L["JoinChatConfirmation"], parameters, options);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            Joining = true;
            await Task.Delay(2000);
            Joining = false;

            var endCoderesult = await DialogService.ShowMessageBox("End Joining Code", "(859) This share the code with the vault owner.", yesText: "Done", cancelText: "Cancel");
            if (endCoderesult == true)
            {
                await LoginAsync();
                Navigation.NavigateTo("/chat");
                await SoundService.PlaySoundAsync(SoundEventTypes.IJoined);

            }



        }
    }
    private async Task LoginAsync()
    {
        BusySubmitting = true;

        if (await ApiHelper.ExecuteCallGuardedAsync(
            () => AuthService.LoginFakeAsync(TenantId, _tokenRequest),
            Snackbar,
            _customValidation))
        {
            Snackbar.Add($"Welcome! You are currently logged in as an anonymous user.", Severity.Info);
        }

        BusySubmitting = false;
    }
    private async Task ShowTermsAndPrivacyDialog()
    {


        var parameters = new DialogParameters();


        var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        var dialog = DialogService.Show<TermsPrivacy>(L["TermsPrivacy"], parameters, options);



    }
    private async Task ShowInPrintDialog()
    {


        var parameters = new DialogParameters();


        var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = false, CloseOnEscapeKey = true };

        var dialog = DialogService.Show<ImPrint>(L["InPrint"], parameters, options);



    }


}