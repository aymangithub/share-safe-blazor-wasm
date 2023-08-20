using FSH.BlazorWebAssembly.Client.Infrastructure.Converter;
using FSH.BlazorWebAssembly.Client.Infrastructure.Entities;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Repositories;

public interface IChatMessageRepository : IRepository<BaseMessageEntity, int>
{
    Task<List<BaseMessageEntity>> GetConversationMessages(int conversationId);
}
public class ChatRepository : Repository<BaseMessageEntity, int>, IChatMessageRepository
{
    public ChatRepository(IJSRuntime jsRuntime, string storeName)
        : base(jsRuntime, storeName)
    {
    }
    public async Task<List<BaseMessageEntity>> GetConversationMessages(int conversationId)
    {
        var messageEntitiesJson = await _jsRuntime.InvokeAsync<string>("dexieService.getAllConversationMessages", new object[] { conversationId });

        Dictionary<string, Type> messageTypeMap = new Dictionary<string, Type>
    {
        { "text", typeof(TextMessageEntity) },
        { "audio", typeof(AudioMessageEntity) },
        { "image", typeof(ImageMessageEntity) },
        { "file", typeof(FileMessageEntity) },
        { "location", typeof(LocationMessageEntity) }
    };

        var jsonArray = JArray.Parse(messageEntitiesJson);
        var messageEntities = jsonArray.Select(item =>
        {
            var messageType = item["messageType"].Value<string>();
            if (!messageTypeMap.TryGetValue(messageType, out Type targetType))
            {
                throw new Exception($"Type {messageType} not supported");
            }

            return item.ToObject(targetType) as BaseMessageEntity;
        }).ToList();

        //var settings = new JsonSerializerSettings();
        //settings.Converters.Add(new MessageJsonConverter());

        //var messageEntities2 = JsonConvert.DeserializeObject<List<BaseMessageEntity>>(messageEntitiesJson, settings);
        return messageEntities;
    }


}