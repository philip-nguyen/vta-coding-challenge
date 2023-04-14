// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Net.Http.Headers;

// Use an HttpClient object to send GET Request
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Add("Authorization", "59af72683221a1734f637eae7a7e8d9b");
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


await ProcessTripUpdatesAsync(client);

static async Task ProcessTripUpdatesAsync(HttpClient client)
{
    // TODO: (EC) create command to accept args for API_KEY and GET params (format=json) 
    var json = await client.GetStringAsync(
        "https://api.goswift.ly/real-time/vta/gtfs-rt-trip-updates?format=json"
    );

    Console.Write(json);
}
