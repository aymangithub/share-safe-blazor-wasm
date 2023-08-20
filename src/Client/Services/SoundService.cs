using Microsoft.JSInterop;

namespace FSH.BlazorWebAssembly.Client.Services;

public class SoundService : ISoundService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly Dictionary<string, string> _eventSoundMap;
    public SoundService(IJSRuntime jsRuntime)
    {
        this._jsRuntime = jsRuntime;
        this._eventSoundMap = new Dictionary<string, string>
        {
            [SoundEventTypes.NewVaultCreated.ToString()] = "sounds/vault-created.mp3",
            [SoundEventTypes.IJoined.ToString()] = "sounds/user-joined-successfully.mp3",
            [SoundEventTypes.MessageSent.ToString()] = "sounds/message-sent.mp3",

        };
    }
    public async Task PlaySoundAsync(SoundEventTypes eventName)
    {
        if (_eventSoundMap.TryGetValue(eventName.ToString(), out var soundFile))
        {
            await _jsRuntime.InvokeVoidAsync("playSound", soundFile);
        }
    }
}
