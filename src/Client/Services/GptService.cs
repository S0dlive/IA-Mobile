using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using System.Text.Json;

namespace Client.Services
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
            requestMessage.Headers.Add($"Authorization", "Bearer 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");
            ChatRequest chatRequest = new ChatRequest()
            {
                Messages = new List<Message>
                {
                    new Message
                    {
                        Role = "user",
                        Content = question
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
