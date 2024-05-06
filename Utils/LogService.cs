using System.Text.Json;

public class LogService
{
    public void LogResponse(HttpResponseMessage response)
    {
        Console.WriteLine($"Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
        Console.WriteLine("Response Headers:");
        foreach (var header in response.Headers)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }

        response.Content.ReadAsStringAsync().ContinueWith(task =>
        {
            var content = task.Result;
            try
            {
                // Parse and format the JSON content for better readability
                var formattedContent = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(content), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                Console.WriteLine("Response Content:");
                Console.WriteLine(formattedContent);
            }
            catch (JsonException)
            {
                // If content is not in valid JSON format, just print it directly
                Console.WriteLine("Response Content:");
                Console.WriteLine(content);
            }
        });
    }
}
