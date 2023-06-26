namespace FunctionCommon.Models
{
    using System.Text.Json.Serialization;

    public class MyModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}