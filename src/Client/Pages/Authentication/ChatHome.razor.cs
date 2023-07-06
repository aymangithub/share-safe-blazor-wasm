using FSH.BlazorWebAssembly.Client.Components.Common;
using FSH.BlazorWebAssembly.Client.Components.EntityTable;
using FSH.BlazorWebAssembly.Client.Infrastructure.ApiClient;
using FSH.BlazorWebAssembly.Client.Infrastructure.Auth;
using FSH.BlazorWebAssembly.Client.Shared;
using FSH.WebApi.Shared.Multitenancy;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Extensions;

namespace FSH.BlazorWebAssembly.Client.Pages.Authentication;

public partial class ChatHome
{
    [CascadingParameter]
    public Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    public IAuthenticationService AuthService { get; set; } = default!;

    private CustomValidation? _customValidation;

    public bool BusySubmitting { get; set; }

    private readonly TokenRequest _tokenRequest = new();
    private string TenantId { get; set; } = string.Empty;
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

        if (await ApiHelper.ExecuteCallGuardedAsync(
            () => AuthService.LoginAsync(TenantId, _tokenRequest),
            Snackbar,
            _customValidation))
        {
            Snackbar.Add($"Logged in as {_tokenRequest.Email}", Severity.Info);
        }

        BusySubmitting = false;
    }
    //private async Task InvokeJoinChatModal()
    //{
    //    var joinChatModel = new JoinChatModel();

    //    var parameters = new DialogParameters
    //{
    //    { nameof(JoinChatModel.Code), joinChatModel }
    //};
      
    //    parameters.Add(nameof(JoinChatModel.Code), " as dasd asds");

    //    var dialogResult = await DialogService.ShowModalAsync<JoinChatModel>(parameters);

    //    if (!dialogResult.Cancelled)
    //    {
    //        // Access the entered chat code and user ID from the model
    //        string code = joinChatModel.Code;
    //        string userId = joinChatModel.UserId;

    //        // Handle the join chat logic using the chat code and user ID
    //       // await JoinChatAsync(code, userId);
    //    }
    //}








}


//public class JoinChatModel : ComponentBase
//{
//    public string Code { get; set; }
//    public string UserId { get; set; }
//}