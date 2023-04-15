using System;
using System.Text.Json.Serialization;

public sealed record class TripUpdate(
    [property: JsonPropertyName("id")] String Id,
    [property: JsonPropertyName("tripId")] int TripId,
    [property: JsonPropertyName("startTime")] String startTime,
    [property: JsonPropertyName("startDate")] String startDate,
    [property: JsonPropertyName("scheduleRelationship")] String scheduleRelationship,
    [property: JsonPropertyName("routeId")] String routeId,
    [property: JsonPropertyName("directionId")] int directionId
)
{
    
}