using IA_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Choice
    {
        [JsonPropertyName("index")]
        public int index { get; set; }

        [JsonPropertyName("message")]
        public Message message { get; set; }

        [JsonPropertyName("finish_reason")]
        public string finish_reason { get; set; }
    }
    public class ChatResponse
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("object")]
        public string @object { get; set; }

        [JsonPropertyName("created")]
        public int created { get; set; }

        [JsonPropertyName("choices")]
        public List<Choice> choices { get; set; }

        [JsonPropertyName("usage")]
        public Usage usage { get; set; }
    }

    public class Usage
    {
        [JsonPropertyName("prompt_tokens")]
        public int prompt_tokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int completion_tokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int total_tokens { get; set; }
    }

}
