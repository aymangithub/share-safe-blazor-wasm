using AdminDashboard.Wasm.Models.ChattingMessage;
using FSH.BlazorWebAssembly.Client.Components.Chatting.ChatMessages;
using Microsoft.AspNetCore.Components;

namespace FSH.BlazorWebAssembly.Client.Services;

public class ChatComponentFactory : IChatComponentFactory
{
    public RenderFragment CreateComponent(BasicMessageViewModel messageViewModel)
    {
        switch (messageViewModel)
        {
            case TextMessageViewModel textMessageViewModel:
                return builder =>
                {
                    builder.OpenComponent(0, typeof(TextMessage));
                    builder.AddAttribute(1, "Message", textMessageViewModel);
                    builder.CloseComponent();
                };
            case FileMessageViewModel fileMessageViewModel:
                return builder =>
                {
                    builder.OpenComponent(0, typeof(FileMessage));
                    builder.AddAttribute(1, "Message", fileMessageViewModel);
                    builder.CloseComponent();
                };
            case ImageMessageViewModel imageMessageViewModel:
                return builder =>
                {
                    builder.OpenComponent(0, typeof(ImageMessage));
                    builder.AddAttribute(1, "Message", imageMessageViewModel);
                    builder.CloseComponent();
                };
            case GeoMessageViewModel geoMessageViewModel:
                return builder =>
                {
                    builder.OpenComponent(0, typeof(GeoMessage));
                    builder.AddAttribute(1, "Message", geoMessageViewModel);
                    builder.CloseComponent();
                };
            case AudioMessageViewModel audioMessageViewModel:
                return builder =>
                {
                    builder.OpenComponent(0, typeof(AudioMessage));
                    builder.AddAttribute(1, "Message", audioMessageViewModel);
                    builder.CloseComponent();
                };

            default:
                throw new ArgumentException($"Unknown ViewModel type: {messageViewModel.GetType()}");
        }
    }
}

