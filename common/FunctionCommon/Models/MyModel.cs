namespace FunctionCommon.Models
{
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;

    public class MyModel
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("age")]
        [JsonProperty("age")]
        public int Age { get; set; }
    }
}