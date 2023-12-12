using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace UniBase.CORE
{
    public class JsonSerializerHelper
    {
        public string? JsonSerialize<T>(T result)
        {
            if (result != null)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                };
                string jsonString = JsonSerializer.Serialize(result, options);
                return jsonString;
            }
            else return null;
        }
    }
}
