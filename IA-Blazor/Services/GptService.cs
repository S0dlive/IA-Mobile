using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IA_Blazor.Models;
using System.Text.Json;

namespace IA_Blazor.Services
{
    public class GptService
    {
        public GptService()
        {

        }

        public async Task<string> SendQuestion(string question)
        {
            using HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("https://api.openai.com/v1/chat/completions");
            requestMessage.Headers.Add($"Authorization", "Bearer yourkey"); // Last key dosnt work ( i'm not idiot ) 
            ChatRequest chatRequest = new ChatRequest()
            {
                Messages = new List<Message>
                {
                    new Message
                    {
                        Role = "user",
                        Content = question,
                    }
                },
                Model = "gpt-3.5-turbo-0301"
            };
            string json = JsonSerializer.Serialize(chatRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            requestMessage.Content = httpContent;
            var response = await client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
