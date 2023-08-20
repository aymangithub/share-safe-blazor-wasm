namespace FSH.BlazorWebAssembly.Client.Services;

public interface ISoundService
{
    Task PlaySoundAsync(SoundEventTypes eventName);
}
