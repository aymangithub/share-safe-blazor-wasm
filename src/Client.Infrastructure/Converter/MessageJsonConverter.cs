using FSH.BlazorWebAssembly.Client.Infrastructure.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Converter;
public class MessageJsonConverter : Newtonsoft.Json.JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        //return (objectType == typeof(BaseMessageEntity));
        return typeof(BaseMessageEntity).IsAssignableFrom(objectType) || typeof(BaseConversationEntity).IsAssignableFrom(objectType);

    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        if (typeof(BaseMessageEntity).IsAssignableFrom(objectType))
        {

            var messageType = jsonObject["messageType"].Value<string>();

            switch (messageType)
            {
                case "text":
                    return jsonObject.ToObject<TextMessageEntity>(serializer);
                case "audio":
                    return jsonObject.ToObject<AudioMessageEntity>(serializer);
                case "image":
                    return jsonObject.ToObject<ImageMessageEntity>(serializer);
                case "file":
                    return jsonObject.ToObject<FileMessageEntity>(serializer);
                case "location":
                    return jsonObject.ToObject<LocationMessageEntity>(serializer);
                default:
                    throw new Exception($"Type {messageType} not supported");
            }
        }
        else if (typeof(BaseConversationEntity).IsAssignableFrom(objectType))
        {

            var messageType = jsonObject["conversationType"].Value<string>();

            return jsonObject.ToObject<ConversationEntity>(serializer);
        }

        throw new Exception($"Unsupported type {objectType}");

    }

    public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

