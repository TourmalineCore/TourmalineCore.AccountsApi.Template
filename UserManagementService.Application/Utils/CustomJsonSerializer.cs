using System.Text;
using Utf8Json;

namespace UserManagementService.Application.Utils
{
    public static class CustomJsonSerializer
    {
        public static string Serialize<T>(T data)
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(data));
        }

        public static T Deserialize<T>(string data)
        {
            if (data == string.Empty)
            {
                throw new JsonParsingException("Empty string!");
            }

            return JsonSerializer.Deserialize<T>(data);
        }
    }
}