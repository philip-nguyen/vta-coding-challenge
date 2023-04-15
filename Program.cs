// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes; // deserialize subsections

namespace HelloWorld
{
    class Program
    {
        // change void to async Task to allow for await GET request 
        static async Task Main(string[] args)
        {
            // Use an HttpClient object to send GET Request
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "59af72683221a1734f637eae7a7e8d9b");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            await ProcessTripUpdatesAsync(client);
        }

        static async Task ProcessTripUpdatesAsync(HttpClient client)
        {
            // TODO: (EC) create command to accept args for API_KEY and GET params (format=json) 
            var json = await client.GetStringAsync(
                "https://api.goswift.ly/real-time/vta/gtfs-rt-trip-updates?format=json"
            );

            //Console.Write(json);
            // Parse all of the JSON
            JsonNode tripNode = JsonNode.Parse(json)!;

            // Get the header subsection
            JsonNode headerObject = tripNode!["header"]; 
            Console.WriteLine($"header={headerObject.ToJsonString()}");

            // Get the entity subsection
            JsonArray tripUpdatesArr = tripNode!["entity"]!.AsArray();

            int count = tripUpdatesArr.Count;

            foreach(JsonNode? tripUpdate in tripUpdatesArr)
            {
                JsonNode tripUpdateData = tripUpdate["tripUpdate"]["trip"]["scheduleRelationship"];
                //JsonNode tripUpdateRow = tripUpdateData
                Console.WriteLine($"tripUpdateId : {tripUpdate["id"]}\t\tscheduleRelationship : {tripUpdateData}");
            }
            
            Console.WriteLine($"TripUpdate Count: {count}");
        }
    }
}