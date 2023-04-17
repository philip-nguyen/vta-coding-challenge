// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes; // deserialize subsections
using System;
using System.Linq;

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


            /*
            tripUpdate in tripUpdatesArr: 
            {
                "id": "3286619_169_52920",
                "tripUpdate": {
                    "trip": {
                    "tripId": "3286619",
                    "startTime": "14:42:00",
                    "startDate": "20230414",
                    "scheduleRelationship": "SCHEDULED",
                    "routeId": "60",
                    "directionId": 1
                    },
                    "stopTimeUpdate": [...],
                    "vehicle": {
                    "id": "169"
                    },
                    "timestamp": "1681511743"
                }
            }
            ** if scheduleRelationship == "CANCELLED", then there is no "stopTimeUpdate" or "vehicle" data

            stopTimeUpdate in stopTimeUpdates
            {
                "stopSequence": 33,
                "arrival": {
                "time": "1681511752"
                },
                "stopId": "2751",
                "scheduleRelationship": "SCHEDULED"
            }
            */
            // Start DB instance
            using var db = new TripUpdatesContext();

            foreach(JsonNode? tripUpdate in tripUpdatesArr)
            {
                JsonNode tripUpdateData = tripUpdate["tripUpdate"]["trip"]["scheduleRelationship"];
                //JsonNode tripUpdateRow = tripUpdateData
                Console.WriteLine($"tripUpdateId : {tripUpdate["id"]}\t\tscheduleRelationship : {tripUpdateData}");
                JsonNode stopTimeUpdates = tripUpdate["tripUpdate"]["stopTimeUpdate"]!.AsArray();

                // add tripUpdate to db
                if(db.TripUpdates.Any(c =? c.TripUpdateId == tripUpdate["id"].ToString()))
                {
                    // add TripUpdate
                }
                db.Add(new TripUpdate {
                    TripUpdateId = tripUpdate["id"].ToString(),
                    TripId = tripUpdate["tripUpdate"]["trip"]["tripId"].ToString(),
                    VehicleId = tripUpdate["tripUpdate"]["trip"]["vehicle"]["id"].ToString(),
                    TimeStamp = tripUpdate["tripUpdate"]["timestamp"].ToString()
                });
                db.Add(new Trip {
                    TripId = tripUpdate["tripUpdate"]["trip"]["tripId"].ToString(),
                    StartTime = tripUpdate["tripUpdate"]["trip"]["startTime"].ToString(),
                    StartDate = tripUpdate["tripUpdate"]["trip"]["startDate"].ToString(),
                    ScheduleRelationship = tripUpdate["tripUpdate"]["trip"]["scheduleRelationship"].ToString(),
                    RouteId = tripUpdate["tripUpdate"]["trip"]["routeId"].ToString(),
                    DirectionId = tripUpdate["tripUpdate"]["trip"]["directionId"].GetValue<int>();
                });
                // TODO: check if there is a stopTimeUpdate, then db.Add(new StopTimeUpdate)
            }
            int count = tripUpdatesArr.Count;
            Console.WriteLine($"TripUpdate Count: {count}");
        }
    }
}