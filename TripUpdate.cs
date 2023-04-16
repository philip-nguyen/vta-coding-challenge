using System;
using System.Text.Json.Serialization;

public sealed record class TripUpdateRecord(
    [property: JsonPropertyName("id")] String Id,
    [property: JsonPropertyName("tripId")] int TripId,
    [property: JsonPropertyName("vehicle")] int vehicleId,
    [property: JsonPropertyName("timestamp")] String timestamp
)
{

}

public sealed record class StopTimeUpdateRecord(
    [property: JsonPropertyName("tripUpdateId")] String tripUpdateId,
    [property: JsonPropertyName("stopSequence")] int stopSequence,
    [property: JsonPropertyName("arrival")] String arrivalTime,
    [property: JsonPropertyName("stopId")] String stopId,
    [property: JsonPropertyName("scheduleRelationship")] String scheduleRelationship
)
{

}

// startTime, startDate, scheduleRelationship, routeId, and directionId can be its own table
public sealed record class TripRecord(
    [property: JsonPropertyName("tripId")] int TripId,
    [property: JsonPropertyName("startTime")] String startTime, 
    [property: JsonPropertyName("startDate")] String startDate,
    [property: JsonPropertyName("scheduleRelationship")] String scheduleRelationship,
    [property: JsonPropertyName("routeId")] String routeId,
    [property: JsonPropertyName("directionId")] int directionId
)
{

}