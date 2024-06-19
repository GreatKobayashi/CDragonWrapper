using System.Text.Json;

namespace CDragonWrapper.EndPoints
{
    public class DataType
    {
        protected static HttpClient Client = new();

        protected static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
