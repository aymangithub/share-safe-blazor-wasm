using FSH.BlazorWebAssembly.Client.Infrastructure.Auth;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace FSH.BlazorWebAssembly.Client.Components.Dialogs;
public partial class ChatSettings
{
    private SettingsModel _settingsModel = new SettingsModel();

    protected override async Task OnInitializedAsync()
    {
        // If you need to load initial settings you can do it here.
        // _settingsModel = await _settingsService.GetSettingsAsync();
    }

    private async Task SaveSettingsAsync()
    {
        // Call the service to save the settings
        // await _settingsService.SaveSettingsAsync(_settingsModel);
    }

    public class SettingsModel
    {
        public string Duration { get; set; } = "off";
        public bool SaveChats { get; set; } = false;
    }

}
